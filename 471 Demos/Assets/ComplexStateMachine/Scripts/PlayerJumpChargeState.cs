using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpChargeState : PlayerBaseState
{



    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm Charging Jump!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //What are we doing during this state
        player.MovePlayer(player.defaultSpeed * 0.5f);

        //On what conditions do we leave this state

        if (Input.GetButtonUp("Jump"))
        {

            player.ApplyJumpForce();

            player.SwitchState(player.jumpState);

        }




    }



}


