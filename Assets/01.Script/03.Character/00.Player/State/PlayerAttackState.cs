using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(PlayerController owner) : base(owner) { }

    public override void Enter()
    {

    }
    public override void Exit()
    {

    }
    public override void Transition()
    {

        if (!controller.PlayerAttack.IsAttacking)
        {
            stateMachine.ChangeState(PlayerController.State.Idle);
        }
        if (controller.PlayerMove.isRolling)
        {
            stateMachine.ChangeState(PlayerController.State.Rolling);
        }
        if (controller.hp <= 0)
        {
            stateMachine.ChangeState(PlayerController.State.Die);
        }
    }
    public override void Update()
    {
        Debug.Log("attack");
    }
    public override void LateUpdate()
    {

    }
    public override void FixedUpdate()
    {

    }
}
