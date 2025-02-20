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
    }




}
