using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollingState : PlayerState
{

    public PlayerRollingState(PlayerController owner) : base(owner) { }

    public override void Enter()
    {
        controller.Animator.SetTrigger("Rolling");
        //구르기중 데미지 안맞게
    }
    public override void Exit()
    {
        //구르기 애니메이션 종료
        //데미지 맞게
    }
    public override void Transition()
    {
        if (!controller.PlayerMove.isRolling)
        {
            stateMachine.ChangeState(PlayerController.State.Idle);
        }
    }
    public override void Update()
    {
        Debug.Log("rolling");
    }
    public override void LateUpdate()
    {

    }
    public override void FixedUpdate()
    {

    }
}
