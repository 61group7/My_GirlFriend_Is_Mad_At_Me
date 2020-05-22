using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int m_sceneIndex;

    [Header("UI Element")]
    public string m_sceneName;
    public Color m_portalColor;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Check");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collide Player");
            SceneManager.LoadScene(m_sceneIndex);
        }
    }
}
