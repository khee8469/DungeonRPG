using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    Vector3 mouseInput;
    [SerializeField] float mouseSpeed;
    [SerializeField] Transform cameraRoot;
    float xRotation;


    private void Update()
    {
        Rotation();
    }


    private void OnRotation(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        mouseInput.x = input.x;
        mouseInput.y = input.y;
    }

    private void Rotation()
    {
        //좌우 회전
        transform.Rotate(Vector3.up, mouseInput.x * mouseSpeed * Time.deltaTime);
        //위아래 회전
        /*xRotation -= mouseInput.y * mouseSpeed * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -10f, 10f);
        cameraRoot.localRotation = Quaternion.Euler(xRotation, 0, 0);*/
    }
}
