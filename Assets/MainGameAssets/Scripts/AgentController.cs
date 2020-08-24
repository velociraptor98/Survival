using System.Collections;
using System.Collections.Generic;
using System.Net.Configuration;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ApplyMovement movement;
    [SerializeField] private PlayerMovement input;
    private void OnEnable()
    {
        movement = GetComponent<ApplyMovement>();
        input = GetComponent<PlayerMovement>();
        input.OnJump+= movement.HandleJump;
    }

    // Update is called once per frame
    void Update()
    {
        movement.HandleMovement(input.MovementInputVector);
        movement.HandleMovementDirection(input.MovementDirectionVector); 
    }
    private void OnDisable()
    {
        input.OnJump -= movement.HandleJump;
    }
}
