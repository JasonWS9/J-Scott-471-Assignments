using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm Walking!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //What are we doing during this state
        player.MovePlayer(player.defaultSpeed);

        //On what conditions do we leave this state
        if (Input.GetButtonDown("Jump"))
        {
            player.SwitchState(player.jumpChargeState);
        }
        if (player.movement.magnitude < 0.1 && !player.isJumping)
        {
            player.SwitchState(player.idleState);
        } else if (player.isSneaking == true && !player.isJumping)
        {
            player.SwitchState(player.sneakState);
        } else if (player.isSprinting == true && !player.isJumping)
        {
            player.SwitchState(player.sprintState);
        }

    }




}
