using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{


    PlayerBaseState currentState;

    PlayerIdleState idleState = new PlayerIdleState();

    PlayerWalkState walkState = new PlayerWalkState();

    public Vector2 movement;
    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentState = walkState;

        currentState.EnterState(this);
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

    // Helper Function

    private float playerSpeed = 10f;

    public void MovePlayer()
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = new Vector3(moveX, 0, moveZ);
        controller.Move(actual_movement * playerSpeed * Time.deltaTime);
    }

}
