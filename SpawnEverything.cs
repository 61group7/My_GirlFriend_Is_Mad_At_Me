using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnEverything : MonoBehaviour
{
    public GameObject[] prefabItem;
    Vector3[] positionArray = new[] { new Vector3(2f, 5f, 0f), new Vector3(-2f, 5f, 0f) };
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            //GameObject newGameObj = Instantiate(item);
            Instantiate(prefabItem[i], positionArray[i], Quaternion.identity);
            //Debug.Log(prefabItem[i]);
            //Debug.Log(positionArray[i]);
            //newGameObj.transform.position = GetNewPosition();
        }
    }

}

