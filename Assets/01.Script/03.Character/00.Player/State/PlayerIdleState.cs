using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerIdleState : PlayerState
{

    public PlayerIdleState(PlayerController owner) : base(owner) { }

    public override void Enter() 
    {
        
    }
    public override void Exit() 
    { 
    
    }
    public override void Transition() 
    {
        if (controller.PlayerMove.MoveInput.x != 0 || controller.PlayerMove.MoveInput.z != 0)
        {
            stateMachine.ChangeState(PlayerController.State.Run);
        }
        if (controller.PlayerMove.isRolling)
        {
            stateMachine.ChangeState(PlayerController.State.Rolling);
        }
        if (controller.PlayerAttack.IsAttacking)
        {
            stateMachine.ChangeState(PlayerController.State.Attack);
        }

        //스킬
        //체인지
        if (controller.hp <= 0)
        {
            stateMachine.ChangeState(PlayerController.State.Die);
        }

    }
    public override void Update() 
    {
        Debug.Log("idle");
    }
    public override void LateUpdate() 
    { 
    
    }
    public override void FixedUpdate() 
    { 
    
    }
}
