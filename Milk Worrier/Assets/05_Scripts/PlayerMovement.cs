using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f, gravity = -9.8f;

    [HideInInspector] public Vector3 dir;
    CharacterController characterController;
    PlayerInput playerInput;

    public GameObject camPos;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }

    void PlayerMove()
    {
        dir = transform.forward * playerInput.moveDir.y + transform.right * playerInput.moveDir.x;
        characterController.Move(dir * moveSpeed * Time.deltaTime);
    }


    void PlayerRotate()
    {
        float mouseX = playerInput.mouseX;
        float mouseY = playerInput.mouseY;

        mouseY = Mathf.Clamp(mouseY, -60f, 60f);


        transform.eulerAngles = new Vector3(0, mouseX, 0);
        camPos.transform.eulerAngles = new Vector3(-mouseY, mouseX, 0);
    }
}
