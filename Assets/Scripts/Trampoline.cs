using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private new Rigidbody rigidbody;
    bool willBounce = false;
    float bounceHeight = -0.7f;
    public Transform Player;
    float velo;

    private void Start()
    {
        
    }

    void Update()
    {
        Vector3 velocity = Player.GetComponent<Rigidbody>().velocity;
        if (velocity.y != 0)
            velo = velocity.y;
        if (willBounce)
        {
            Debug.Log(velo);
            Player.GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, 0, velocity.z);
            Player.GetComponent<Rigidbody>().AddForce(0, velo * bounceHeight, 0, ForceMode.Impulse);
            willBounce = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trampoline_tag")
        {
            willBounce = true;
        }

    }
}