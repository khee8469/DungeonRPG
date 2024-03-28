using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State { Idle, Run, Rolling, Attack, Skill, Change, Die }

    private BaseStateMachine<State> stateMachine;

    private Animator animator;
    public Animator Animator { get { return animator; } }

    private PlayerMove playerMove;
    public PlayerMove PlayerMove { get { return playerMove; } }

    private PlayerAttack playerAttack;
    public PlayerAttack PlayerAttack { get { return playerAttack; } }

    //임시
    public int damage;
    public int hp;
    public int maxHp;


    private void Awake()
    {
        stateMachine = new BaseStateMachine<State>();
        animator = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();

        hp = 100;

        //상태클래스들에 상태머신지정, 상태머신 해시테이블에 저장
        stateMachine.AddState(State.Idle, new PlayerIdleState(this));
        stateMachine.AddState(State.Run, new PlayerRunState(this));
        stateMachine.AddState(State.Rolling, new PlayerRollingState(this));
        stateMachine.AddState(State.Attack, new PlayerAttackState(this));
        stateMachine.AddState(State.Die, new PlayerDieState(this));

        //초기상태설정
        stateMachine.Start(State.Idle);
    }

    private void Update()
    {
        stateMachine.Update();
    }
}





