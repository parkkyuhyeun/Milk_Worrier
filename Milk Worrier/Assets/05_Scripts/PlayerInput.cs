using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private LayerMask whatIsGround;

    private Camera mainCam;

    public Vector2 moveDir { get; private set; }
    public float mouseX { get; private set; }
    public float mouseY { get; private set; }

    public bool isJump { get; private set; }

    public Vector3 mousePos { get; private set; }


    private void Awake()
    {
        mainCam = Camera.main;
        mouseX = 0f;
        mouseY = 0f;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveDir = new Vector2(x, y);

        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float depth = mainCam.farClipPlane;
        if (Physics.Raycast(ray, out hit, depth))
        {
            mousePos = hit.point;
        }
    }

    public bool GetMouseWorldPosition(out Vector3 hitPoint)
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        //스크린에 있는 마우스의 위치를 향하는 Ray를 만든다.
        RaycastHit hit;

        bool result = Physics.Raycast(ray, out hit, mainCam.farClipPlane);
        hitPoint = result ? hit.point : Vector3.zero;
        return result;
    }
}
