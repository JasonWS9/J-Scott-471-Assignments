using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{


    [HideInInspector] public PlayerBaseState currentState;

    [HideInInspector] public PlayerIdleState idleState = new PlayerIdleState();
    [HideInInspector] public PlayerWalkState walkState = new PlayerWalkState();
    [HideInInspector] public PlayerSneakState sneakState = new PlayerSneakState();


    public float defaultSpeed = 100f;
    [HideInInspector] public Vector2 movement;

    [HideInInspector] public bool isSneaking = false;

    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        

        SwitchState(idleState);
    }



    void Update()
    {
        currentState.UpdateState(this);
    }

    // Handle Input

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnSprint(InputValue sprintVal)
    {
        if (sprintVal.isPressed)
        {
            isSneaking = true;
        } else
        {
            isSneaking = false;
        }
    }

    // Helper Function

    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = new Vector3(moveX, 0, moveZ);
        controller.Move(actual_movement * speed * Time.deltaTime);
    }



    public void SwitchState(PlayerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }


}
