using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMonster : MonoBehaviour
{
    public MonsterStateMachine fsm { get; private set; }


    private void Awake()
    {
        fsm = new MonsterStateMachine();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
