using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;

public class PlayerMove : MonoBehaviour
{
    CharacterController controller;
    private Vector3 moveInput;
    public Vector3 MoveInput { get { return moveInput; } }
    [SerializeField] float moveSpeed;

    //확인용
    public bool isRolling;
    

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Move();
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        moveInput.x = input.x;
        moveInput.z = input.y;
    }

    public void Move()
    {
        //낙하속도
        controller.Move(transform.up * Physics.gravity.y * Time.deltaTime);
        //기본 움직임
        controller.Move(transform.forward * moveInput.z * moveSpeed * Time.deltaTime);
        controller.Move(transform.right * moveInput.x * moveSpeed * Time.deltaTime);
    }

    private void OnRolling(InputValue value)
    {
        StartCoroutine(Rolling());
    }

    //확인용
    IEnumerator Rolling()
    {
        isRolling = true;
        yield return new WaitForSeconds(0.5f);
        isRolling = false;
    }

}
