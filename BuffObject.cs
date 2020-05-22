using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuffObject : MonoBehaviour
{
    private OVRPlayerController m_player;
    private bool m_isUsed = false;
    public float m_moveScale = 1.0f;
    public float m_seconds = 0.0f;

    private void Start()
    {
        m_isUsed = false;
        m_player = FindObjectOfType<OVRPlayerController>();
    }

    private void Update() 
    {
        if (GetComponent<OVRGrabbable>().isGrabbed && !m_isUsed)
        {
            m_isUsed = true;
            StartCoroutine("SetBuff");
        }
    }

    void StartBuff()
    {
        StartCoroutine("SetBuff");
    }

    IEnumerator SetBuff()
    {
        m_player.SetMoveScaleMultiplier(m_moveScale);
        yield return new WaitForSecondsRealtime(m_seconds);
        m_player.SetMoveScaleMultiplier(1.0f);
        
    }
}
