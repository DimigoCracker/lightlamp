using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Light : MonoBehaviour
{
    public string clearSceneNmae;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("접촉");
            SceneManager.LoadScene(clearSceneNmae);
        }
    }
}
