using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPortal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Check");
        if (other.gameObject.CompareTag("Player"))
        {
            Application.Quit();
        }
    }
}
