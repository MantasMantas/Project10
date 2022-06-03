using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandPointer : MonoBehaviour
{

    public UnityEngine.EventSystems.OVRInputModule _OVRInputModule;

    public OVRRaycaster _OVRRaycaster;

    public OVRHand _OVRHand;


    void Start()
    {

        _OVRInputModule.rayTransform = _OVRHand.PointerPose;
        _OVRRaycaster.pointer = _OVRHand.PointerPose.gameObject;

    }

    void Update()
    {
        _OVRInputModule.rayTransform = _OVRHand.PointerPose;
        _OVRRaycaster.pointer = _OVRHand.PointerPose.gameObject;
    }

}
