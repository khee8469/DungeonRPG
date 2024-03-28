using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    //È®ÀÎ¿ë
    private bool isAttacking;
    public bool IsAttacking { get { return isAttacking; } }

    private void OnAttack(InputValue value)
    {
        StartCoroutine(Attacking());
    }

    IEnumerator Attacking()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.5f);
        isAttacking = false;
    }
}
