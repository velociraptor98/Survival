using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class ApplyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    protected CharacterController charaterController;
    [SerializeField]private float movementSpeed;
    [SerializeField]private float gravity;
    [SerializeField]private float rotateSpeed;
    protected Vector3 movementDirection = Vector3.zero;
    protected float desRotationAngle = 0;
    private int inputVerticalDirection = 0;
    [SerializeField] private float rotationThreshold;
    public void HandleMovement(Vector2 Input)
    {
        if(charaterController.isGrounded)
        {
            if(Input.y !=0)
            {
                if(Input.y>0)
                {
                    inputVerticalDirection = Mathf.CeilToInt(Input.y);
                }
                else
                {
                    inputVerticalDirection = Mathf.FloorToInt(Input.y);
                }
                movementDirection = Input.y * transform.forward * movementSpeed;    
            }
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }
    public void HandleMovementDirection(Vector3 input)
    {
        desRotationAngle = Vector3.Angle(transform.forward, input);
        float crossProduct = Vector3.Cross(transform.forward, input).y;
        if(crossProduct < 0)
        {
            desRotationAngle *= -1;
        }

    }
    void Start()
    {
        charaterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(charaterController.isGrounded)
        {
            if(movementDirection.magnitude>0)
            {
                RotateAgent();
            }
        }
        movementDirection.y -= gravity;
        charaterController.Move(movementDirection * Time.deltaTime * movementSpeed);
    }
    public void RotateAgent()
    {
        if(desRotationAngle > rotationThreshold || desRotationAngle < -rotationThreshold)
        {
            transform.Rotate(Vector3.up * desRotationAngle * rotateSpeed * Time.deltaTime);
        }
    }
}
