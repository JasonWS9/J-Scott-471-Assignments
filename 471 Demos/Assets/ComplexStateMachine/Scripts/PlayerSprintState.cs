using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{


    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm Sprinting!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //What are we doing during this state
        player.MovePlayer(player.defaultSpeed * 2);

        //On what conditions do we leave this state
        if (player.movement.magnitude < 0.1)
        {
            player.SwitchState(player.idleState);
        }
        else if (player.isSprinting == false)
        {
            player.SwitchState(player.walkState);
        } else if (player.isSprinting == false && player.isSneaking == true)
        {
            player.SwitchState(player.sneakState);
        }
        if (Input.GetButtonDown("Jump"))
        {
            player.SwitchState(player.jumpChargeState);
        }
    }


}
