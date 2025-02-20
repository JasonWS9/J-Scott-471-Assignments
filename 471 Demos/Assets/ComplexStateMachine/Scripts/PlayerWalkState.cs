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
        player.MovePlayer();

        //On what conditions do we leave this state
    }




}
