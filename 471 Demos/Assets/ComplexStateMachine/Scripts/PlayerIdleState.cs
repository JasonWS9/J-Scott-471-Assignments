using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{


    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm Idling!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //What are we doing during this state
        //Nothing

        //On what conditions do we leave this state
        if (Input.GetButtonDown("Jump"))
        {
            player.SwitchState(player.jumpChargeState);
        }

        if (player.movement.magnitude > 0.1)
        {


            if (!player.isJumping)
            {
                if (player.isSneaking)
                {
                    player.SwitchState(player.sneakState);
                }
                else if (player.isSprinting)
                {
                    player.SwitchState(player.sprintState);
                }
                else
                {
                    player.SwitchState(player.walkState);

                }
            }
            
           



        }

    }




}
