using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Player is Falling!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        // Allow the player to move slightly while falling
        player.MovePlayer(player.defaultSpeed * 1f);

        // If the player lands on the ground, transition to an appropriate state
        if (player.isGrounded)
        {
            if (player.isSneaking)
                player.SwitchState(player.sneakState);
            else if (player.isSprinting)
                player.SwitchState(player.sprintState);
            else if (!player.isSneaking && !player.isSprinting)
                player.SwitchState(player.walkState);
            else
                player.SwitchState(player.idleState);

            return;
        }

        // Optional: Allow double jump if the game supports it

    }
}
