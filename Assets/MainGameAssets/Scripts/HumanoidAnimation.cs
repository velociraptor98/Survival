using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class HumanoidAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetMovementFloat(float value)
    {
        animator.SetFloat("move", value);
    }
    public float SetCorrectAnimation(float desiredRot,int angleThresh,int inputVerticalDirection)
    {
        float currAnimSpeed = animator.GetFloat("move");
        if(desiredRot > angleThresh || desiredRot <-angleThresh)
        {
            if(Mathf.Abs(currAnimSpeed) < 0.2f)
            {
                currAnimSpeed += inputVerticalDirection * Time.deltaTime * 2;
                currAnimSpeed = Mathf.Clamp(currAnimSpeed, -0.2f, 0.2f);
            }
            SetMovementFloat(currAnimSpeed);
        }
        else
        {
            if(currAnimSpeed < 1)
            {
                currAnimSpeed += inputVerticalDirection * Time.deltaTime * 2;
            }
            SetMovementFloat(Mathf.Clamp(currAnimSpeed,-1,1));
        }
        return Mathf.Abs(currAnimSpeed);
    }
}