using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 5f;
    Rigidbody rigid;
    Camera cam;
    public Vector3 camOffset;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    private void Update()
    {
        Move();
        FollowCam();
    }

    public void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0, v).normalized;

        rigid.velocity = dir * speed;

        transform.LookAt(transform.position + dir);
    }

    public void FollowCam()
    {
        cam.transform.position = transform.position + camOffset;
    }
}
