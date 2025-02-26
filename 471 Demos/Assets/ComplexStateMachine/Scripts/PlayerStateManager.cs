using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateManager : MonoBehaviour
{


    [HideInInspector] public PlayerBaseState currentState;

    [HideInInspector] public PlayerIdleState idleState = new PlayerIdleState();
    [HideInInspector] public PlayerWalkState walkState = new PlayerWalkState();
    [HideInInspector] public PlayerSneakState sneakState = new PlayerSneakState();
    [HideInInspector] public PlayerSprintState sprintState = new PlayerSprintState();
    [HideInInspector] public PlayerJumpChargeState jumpChargeState = new PlayerJumpChargeState();
    [HideInInspector] public PlayerJumpState jumpState = new PlayerJumpState();
    [HideInInspector] public PlayerFallState fallState = new PlayerFallState();


    public float defaultSpeed = 100f;
    [HideInInspector] public Vector2 movement;

    [HideInInspector] public bool isSneaking = false;
    [HideInInspector] public bool isSprinting = false;
    [HideInInspector] public bool isJumping = false;
    [HideInInspector] public bool isChargingJump = false;




    public float jumpHeight = 2f;
    public float jumpForce = 5f;
    public float gravity = -20f;
    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public bool isGrounded;

    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
      

        SwitchState(idleState);
    }


    void Update()
    {
        currentState.UpdateState(this);

        JumpAndGravity();
    }

    // Handle Input

    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnJump(InputValue jumpVal)
    {

    }

    void JumpAndGravity()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0.01)
        {
            velocity.y = -2f;
        }
    
    
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    public void ApplyJumpForce()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); // Jump physics formula
    }
    void OnSneak(InputValue sneakVal)
    {
        if (sneakVal.isPressed)
        {
            isSneaking = true;
        } else
        {
            isSneaking = false;
        }
    }

    void OnSprint(InputValue sprintVal)
    {
        if (sprintVal.isPressed)
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
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
