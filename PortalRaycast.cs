using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PortalRaycast : MonoBehaviour
{
    public Text m_portalName;
    public TMP_Text headertext;
    public Image m_portalBackground;
    public int m_raycastLayer;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, (1 << m_raycastLayer)))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            ChangeScene portalData = hit.collider.gameObject.GetComponent<ChangeScene>();
            m_portalName.text = portalData.m_sceneName;
            m_portalBackground.color = portalData.m_portalColor;
            m_portalBackground.gameObject.SetActive(true);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            m_portalBackground.gameObject.SetActive(false);
        }
    }
}
