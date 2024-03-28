using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : BaseState<PlayerController.State>
{
    protected PlayerController controller;

    public PlayerState(PlayerController controller)
    {
        this.controller = controller;
    }

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Transition()
    {
        
    }
}
