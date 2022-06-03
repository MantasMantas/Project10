using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine;


public class TCPConnection
{
    private string host;
    private int port;

    private TcpClient mySocket;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;


    public bool socketOn;

    public TCPConnection(string host, int port) 
    {
        this.host = host;
        this.port = port;
    }

    public void SetUp() 
    {
        try 
        {
            mySocket = new TcpClient(host, port);
            stream = mySocket.GetStream();
            writer = new StreamWriter(stream);
            reader = new StreamReader(stream);
            mySocket.NoDelay = true;
            socketOn = true;
            Debug.Log("Socket was set up sucessfully");
        }
        catch(Exception e) 
        {
            Debug.LogException(e);
        }
    }

    public void CloseSocket() 
    {
        if (socketOn) 
        {
            writer.Close();
            reader.Close();
            mySocket.Close();
            socketOn = false;
        }
        else 
        {
            Debug.LogWarning("The socket is not set up!");
        }
    }

    public void ConnectionHelper() 
    {
        if(socketOn && !stream.CanRead) 
        {
            SetUp();
        }
    }

    public void Send(string msg) 
    {
        if (socketOn) 
        {
            string tmp = msg + "\r\n";
            writer.Write(tmp);
            writer.Flush();
        }
        else 
        {
            Debug.LogWarning("Socket is not set up!");
        }
    }

    public string Receive() 
    {
        string result = "";

        if (stream.DataAvailable) 
        {
            Byte[] inStream = new byte[mySocket.SendBufferSize];
            stream.Read(inStream, 0, inStream.Length);

            string temp = System.Text.Encoding.UTF8.GetString(inStream).TrimEnd('\0');

            if (!temp.Equals(""))
                result += System.Text.Encoding.UTF8.GetString(inStream).TrimEnd('\0') ;

        }
        
        return result;
        
        
    }

}
