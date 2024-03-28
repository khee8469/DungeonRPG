using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(PlayerController owner) : base(owner) { }

    public override void Enter()
    {
        //달리는 애니메이션 실행
    }
    public override void Exit()
    {
        //달리는 애니메이션 종료
    }
    public override void Transition()
    {

        if (controller.PlayerMove.MoveInput.x == 0 || controller.PlayerMove.MoveInput.z == 0)
        {
            stateMachine.ChangeState(PlayerController.State.Idle);
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
        Debug.Log("run");
        controller.PlayerMove.Move();
    }
    public override void LateUpdate()
    {

    }
    public override void FixedUpdate()
    {
        
    }
}
