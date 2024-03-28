using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MonsterEnum;

public class MonsterState : BaseState<BaseState>
{
    public bool isTransition = false;
    public override void Enter()
    {
        isTransition = false;
    }

    public override void Exit()
    {

    }

    public override void Transition()
    {
        if(isTransition)
        {
            ChangeState();
        }
    }
    public virtual void ChangeState()
    { }

}
