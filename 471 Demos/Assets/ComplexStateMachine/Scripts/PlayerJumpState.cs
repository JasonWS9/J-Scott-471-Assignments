using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private bool hasReachedApex = false;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Player is Jumping!");

        Vector3 currentVelocity = player.velocity;
        player.velocity = new Vector3(currentVelocity.x, player.jumpForce, currentVelocity.z);

        hasReachedApex = false;
    }

    public override void UpdateState(PlayerStateManager player)
    {
        // If the player is falling (negative Y velocity)
        if (player.velocity.y < 0)
        {
            hasReachedApex = true;
        }

        // Transition to falling state if at apex or falling
        if (hasReachedApex)
        {
            player.SwitchState(player.fallState);
            return;
        }

        // If player lands on the ground, switch to the appropriate movement state
        if (player.isGrounded)
        {
            if (player.isSneaking)
                player.SwitchState(player.sneakState);
            else if (player.isSprinting)
                player.SwitchState(player.sprintState);
            else
                player.SwitchState(player.walkState);
        }
    }
}
