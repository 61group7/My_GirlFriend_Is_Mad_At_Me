using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIE : MonoBehaviour
{
    public Transform target;

    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime = 1f;

    UnityEngine.AI.NavMeshAgent nav;

    public float disToPlayer = 5.0f;

    private float randomStrafeStartTime;
    private float waitStrafeTime;
    public float t_minStrafe;
    public float t_maxStrafe;

    public Transform strafeRight;
    public Transform strafeLeft;
    private int randomStrafeDir;

    public float chaseRadius = 20f;

    public float facePlayerFactor = 20f;

    private void Awake()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nav.enabled = true;
    }


    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if ( distance > chaseRadius)
        {
            
            Patrol();
        }
        else if (distance <= chaseRadius)
        {
            ChasePlayer();

            FacePlayer();
        }
        
    }

    void Patrol()
    {
        if(moveSpots[randomSpot] == null)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
        else {
            nav.SetDestination(moveSpots[randomSpot].position);
            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                    //moveSpots[randomSpot] = null;

                    //Debug.Log(moveSpots[randomSpot].position);
                    //Debug.Log(moveSpots);
                    //Debug.Log(randomSpot);


                }
                else { waitTime -= Time.deltaTime; }
            }
        }
    }

    void ChasePlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= chaseRadius && distance > disToPlayer)
        {
            nav.SetDestination(target.position);
        }

        else if (nav.isActiveAndEnabled && distance<= disToPlayer)
        {
            randomStrafeDir = Random.Range(0, 2);
            randomStrafeStartTime = Random.Range(t_minStrafe, t_maxStrafe);

            if (waitStrafeTime <= 0)
            {
                if (randomStrafeDir == 0)
                {
                    nav.SetDestination(strafeLeft.position);

                }
                else if (randomStrafeDir == 1)
                {
                    nav.SetDestination(strafeRight.position);
                }
                waitStrafeTime = randomStrafeStartTime;
            }
            else
            {
                waitStrafeTime -= Time.deltaTime;
            }
        }
    }

    void FacePlayer()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
    }


}
