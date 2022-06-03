using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    // the animation is 1.083 seconds length over 24 frame rate
    // cut the length of animation to exactly 1 second
    // speed 1 is going to be 60 beats per minute as one beat takes one second and there are 60 seconds in one minute
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    [SerializeField]
    public void SetAnimationValues(float value) 
    {
        animator.SetFloat("Speed", value / 60f);
    }
}
