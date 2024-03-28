using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : PlayerState
{

    public PlayerDieState(PlayerController owner) : base(owner) { }

    public override void Enter()
    {
        //사망애니메이션 실행
        //사망 UI 실행
    }
    public override void Exit()
    {

    }
    public override void Transition()
    {
        //재시작시 Idle 상태로 전환?
    }
    public override void Update()
    {
        Debug.Log("die");
    }
    public override void LateUpdate()
    {

    }
    public override void FixedUpdate()
    {

    }
}
