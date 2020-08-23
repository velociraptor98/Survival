using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private ApplyMovement movement;
    [SerializeField] private PlayerMovement input;
    void Start()
    {
        movement = GetComponent<ApplyMovement>();
        input = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.HandleMovement(input.MovementInputVector);
        movement.HandleMovementDirection(input.MovementDirectionVector);
    }
}
