using System;
using System.Collections;
using UnityEngine;

public class EmphaticaManager : MonoBehaviour
{
    // server details
    public string hostName = "127.0.0.1";
    public int hostPort = 28000;
    public string deviceId = "A0329B";

    // helpers
    public bool debugLog,logging;
    public bool bvp, ibi, gsr;

    // Heart animation modifiers
    [Range(0f, 200f)]
    public float unsinchorinzedHeartRateMin, unsinchorinzedHeartRateMax;
    public AnimationCurve manipulationCurve; // use time indicator as the evaluation value
    [Range(0f, 100f)]
    public float manipulationCurveWeight;

    // dependencies
    public FloatEvent hrEvent;
    public FileName fileName;
    public Conditions conditions;
    public TimeToWait timeToWait;
    public ConditionDuration conditionDuration;

    private string loggingHeader = "Stream, Time Stamp, Data";

    private TCPConnection tcpConnection;
    private CSVTool csvTool;
    private bool Subscribed;

    public float manipulatedHR;
    public float actualHR;

    private void Start()
    {
        tcpConnection = new TCPConnection(hostName, hostPort);
        SetUp();
    }

    private void OnDestroy()
    {
        fileName.increment();   
    }


    private void Update()
    {
        if (tcpConnection.socketOn) 
        {
            tcpConnection.ConnectionHelper();
            string receive = tcpConnection.Receive();

            if (!receive.Equals("")) 
            {
                if (debugLog) 
                {
                    Debug.Log("[Server] " + receive);
                }

                if (Subscribed) 
                {

                    string[] dataEntry = receive.Split("\n", StringSplitOptions.RemoveEmptyEntries);

                    foreach(string entry in dataEntry) 
                    {
                        string[] temp = entry.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        if (temp[0].Equals("E4_Hr"))
                        {
                            actualHR = float.Parse(temp[2]);
                            SetVirtualHeartRate(float.Parse(temp[2]));

                            if(conditions.GetCondition() >= 1) 
                            {
                                csvTool.WriteNewLine("ManipulatedHR," + temp[1] + "," + manipulatedHR);

                            }
                        }
                    }
        
                    if (logging) 
                    {
                        csvTool.WriteLine(receive.Replace(" ", ",")); 
                    }
                }
          }
           
        }
    }

    private IEnumerator SetUpCoroutine() 
    {
        tcpConnection.SetUp();
        tcpConnection.Send("server_status"); 
        yield return new WaitForSeconds(0.1f);
        ConnectDevice();
        yield return new WaitForSeconds(0.1f);
        Subscribe();
        yield return new WaitForSeconds(0.1f);
        Pause();
    }

    public void SetUp() 
    {
        StartCoroutine(SetUpCoroutine());
    }

    public void ConnectDevice() 
    {
        tcpConnection.Send("device_connect " + deviceId);
    }

    public void Subscribe() 
    {
        StartCoroutine(SubsbribeToStreams());
    }

    public void Unsubscribe() 
    {
        StartCoroutine(UnsubsbribeFromStreams());
        Subscribed = false;
    }

    public void Disconect() 
    {
        tcpConnection.Send("device_disconnect");
        tcpConnection.CloseSocket();
    }

    public void Pause() 
    {
        tcpConnection.Send("pause ON");
        Subscribed = false;
    }

    public void Unpause() 
    {
        if (logging)
        {
            InitiateLogging();
        }

        tcpConnection.Send("pause OFF");
        Subscribed = true;

    }

    private IEnumerator SubsbribeToStreams() 
    {
        if(bvp) { tcpConnection.Send("device_subscribe bvp ON"); }
        yield return new WaitForSeconds(0.1f);
        if (ibi) { tcpConnection.Send("device_subscribe ibi ON"); }
        yield return new WaitForSeconds(0.1f);
        if (gsr) { tcpConnection.Send("device_subscribe gsr ON"); }
    }

    private IEnumerator UnsubsbribeFromStreams()
    {

        if (bvp) { tcpConnection.Send("device_subscribe bvp OFF"); }
        yield return new WaitForSeconds(0.1f);
        if (ibi) { tcpConnection.Send("device_subscribe ibi OFF"); }
        yield return new WaitForSeconds(0.1f);
        if (gsr) { tcpConnection.Send("device_subscribe gsr OFF"); }

    }

    private void InitiateLogging() 
    {
        csvTool = new CSVTool(fileName.Get() + "_Condition_" + conditions.GetCondition().ToString() + "_E", loggingHeader);   
    }

    private void SetVirtualHeartRate(float value) 
    {
        int condition = conditions.GetCondition();

        if (condition == 0)
        {
            hrEvent.raiseEvent(value);
        }
        if (condition == 1)
        {
            manipulatedHR = UnityEngine.Random.Range(unsinchorinzedHeartRateMin, unsinchorinzedHeartRateMax);
            hrEvent.raiseEvent(manipulatedHR);
            
        }
        if (condition == 2)
        {
            manipulatedHR = value + (manipulationCurve.Evaluate(timeToWait.GetTime() / conditionDuration.duration) * manipulationCurveWeight);
            hrEvent.raiseEvent(manipulatedHR);
        }
        
        
    }

}
