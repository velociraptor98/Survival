﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 MovementInputVector { get; set; }    
    public Vector3 MovementDirectionVector { get; private set; }
    private Camera mainCamera;  
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        GetMovementInput();
        GetCameraDirection();
    }

    private void GetCameraDirection()
    {
        MovementInputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void GetMovementInput()
    {
        Vector3 cameraForward = mainCamera.transform.forward;
        MovementDirectionVector = Vector3.Scale(cameraForward,(Vector3.right+Vector3.forward));
    }
}