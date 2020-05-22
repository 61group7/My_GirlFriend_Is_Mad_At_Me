using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BubuAI : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEngine.AI.NavMeshAgent bubu;
    public Transform target;
    void Start()
    {
        bubu = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        bubu.SetDestination(target.position);
    }
}
