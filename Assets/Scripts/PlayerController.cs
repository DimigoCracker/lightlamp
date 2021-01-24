using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;

    public float cameraSpeedX, cameraSpeedY;
    public float cameraDist;

    private float camRotX, camRotY;

    public new Camera camera;
    public GameObject wagon;

    private new Rigidbody rigidbody;

    public bool usingWagon;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        camRotX = camera.transform.eulerAngles.x;
        camRotY = camera.transform.eulerAngles.y;
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space)) Wagon();
    }

    public void Move()
    {
        if (usingWagon)
        {
            Vector3 deltaPos = new Vector3(Input.GetAxisRaw("Vertical"), 0, 0);
            Vector3 w = wagon.transform.position;
            if ((deltaPos.x > 0 && w.x > 4) || (deltaPos.x < 0 && w.x < -5.3f)) deltaPos.x = 0;
            wagon.transform.position += deltaPos * playerSpeed * Time.deltaTime;
            transform.position = new Vector3(w.x - 2.2f, 1, w.z);

            camera.transform.position = transform.position + new Vector3(-3, 8, 0);
            rigidbody.rotation = Quaternion.Euler(0, 90, 0);
            camera.transform.rotation = Quaternion.Euler(50, 90, 0);
        }
        else
        {
            Vector3 deltaPos = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            deltaPos = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * deltaPos;
            transform.position += deltaPos * playerSpeed * Time.deltaTime;

            camRotX += Input.GetAxis("Mouse X") * cameraSpeedX;
            camRotY -= Input.GetAxis("Mouse Y") * cameraSpeedY;
            if (camRotY < -4) camRotY = -4;
            else if (camRotY > 85) camRotY = 85;
            Quaternion camRot = Quaternion.Euler(camRotY, camRotX, 0);
            Vector3 camPos = camRot * new Vector3(0, 0, -cameraDist) + transform.position;

            camera.transform.rotation = camRot;
            transform.rotation = Quaternion.Euler(0, camRotX, 0);
            camera.transform.position = camPos;

            RaycastHit hit;
            Physics.Raycast(transform.position, camRot * new Vector3(0, 0, -1), out hit, cameraDist);

            if (hit.point != Vector3.zero)
            {
                camera.transform.position = hit.point;
            }
            else
            {
                camera.transform.position = camPos;
            }
        }
    }

    public void Wagon()
    {
        if (usingWagon)
        {
            usingWagon = false;
        }
        else
        {
            Vector3 p = transform.position, w = wagon.transform.position;
            if (w.x > p.x && p.x > w.x - 3 && w.z - 1.25 < p.z && p.z < w.z + 1.25)
            {
                usingWagon = true;
            }
        }
    }
}
