using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap 
{
    public Transform VRTarget, rigTarget;
    public Vector3 positionOffset, rotationOffset;
 
    public void Map() 
    {
        rigTarget.position = VRTarget.TransformPoint(positionOffset);
        rigTarget.rotation = VRTarget.rotation * Quaternion.Euler(rotationOffset);
    }
    

}
public class AvatarManager : MonoBehaviour
{
    public VRMap head, rightHand, leftHand;

    public Transform headConstraint;
    private Vector3 headBodyOffset;

    [Range(0f, 10f)]
    public float turnSmoothness, bodyDistance;

    private void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }


    private void LateUpdate()
    {
       
        Vector3 bodyPos = headConstraint.position + headBodyOffset;
        if(Vector3.Distance(bodyPos, transform.position) > bodyDistance) 
        {
            transform.position = bodyPos;
        }
        //transform.position = headConstraint.position + headBodyOffset;
        //transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(-headConstraint.up, -Vector3.up).normalized, Time.deltaTime * turnSmoothness);

       head.Map();
       rightHand.Map();
       leftHand.Map();
    }

}
