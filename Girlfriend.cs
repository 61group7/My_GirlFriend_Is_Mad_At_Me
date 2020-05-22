using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Girlfriend : MonoBehaviour
{
    private OVRPlayerController m_player;
    public float waitTime;
    public AudioClip Hahaha;
    GameManager gameManager;
    bool hasPlayGameOverSound = false;
    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_player = FindObjectOfType<OVRPlayerController>();
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Hahaha;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collide with player");

            gameManager.isGameOver = true;
            StartCoroutine(WaitAndLoadScene());

        }
    }
    IEnumerator WaitAndLoadScene()
    {
        m_player.SetMoveScaleMultiplier(0);
        if (!hasPlayGameOverSound)
            AudioManager.instance.Play("GameOverSound");
        hasPlayGameOverSound = true;
        //GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(3);
    }


}
