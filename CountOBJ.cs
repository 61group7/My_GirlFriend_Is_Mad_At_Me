using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountOBJ : MonoBehaviour
{
    private bool isGrabbu = false;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.AddItem();
    }

    private void Update()
    {
        
        int numItem = gameManager.GetItemCount();

        if (GetComponent<OVRGrabbable>().isGrabbed && isGrabbu == false)
        {
            Debug.Log("Grab pa?");
            gameManager.RemoveItem();
            isGrabbu = true;
            AudioManager.instance.Play("ItemPickup");
            Destroy(this.gameObject);
        }
    }
}
