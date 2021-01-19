using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private new Rigidbody rigidbody;
    public new Camera camera;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private Vector3 moveVector3;

    void Update()
    {
        moveVector3.x = Input.GetAxisRaw("Horizontal");
        moveVector3.z = Input.GetAxisRaw("Vertical");
        moveVector3 = moveVector3.normalized * speed;
        moveVector3 = Quaternion.Euler(Vector3.up * camera.transform.rotation.eulerAngles.y) * moveVector3;
    }

    void LateUpdate()
    {
        Move();
    }

    public void Move()
    {
        rigidbody.MovePosition(rigidbody.position + moveVector3 * Time.deltaTime);
    }
}
