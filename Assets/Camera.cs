using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject PlayerCharacter;
    public Transform CameraArm;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    void CameraControll() {
        Vector2 MouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector3 CameraAngles = CameraArm.rotation.eulerAngles;

        CameraArm.rotation = Quaternion.Euler(CameraAngles.x - MouseInput.y, CameraAngles.y + MouseInput.x, CameraAngles.z);
    }
}
