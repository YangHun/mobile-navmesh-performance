using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAI : MonoBehaviour {

    enum Action { Pickup = 1, Wave = 2 }

    public NavMeshAgent agent;

    public float timer = 0.0f;
    public Animator animator;
    public Vector3 src;
    public Vector3 dir;

    public bool isMoving = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!animator.GetBool("Grounded"))
        {
            animator.SetBool("Grounded", true);
            agent.enabled = true;
            agent.isStopped = true;
        }   
    }

    private void Start()
    {
        if (!agent.isOnNavMesh)
            agent.enabled = false;
    }

    private void Update()
    {
        if (!animator.GetBool("Grounded") || !animator.GetBool("isIdle"))
            return;


        if (agent.isStopped)
        {
            src = transform.position;
            dir = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)) * 5.0f;
            agent.isStopped = false;
            animator.SetFloat("MoveSpeed", 1.0f);
            agent.SetDestination(src + dir);
        }

        else if (timer > 5.0f || agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetFloat("MoveSpeed", 0.0f);
            agent.isStopped = true;

            Action next = (Action)Random.Range(1, 2);

            switch (next)
            {
                case Action.Wave:
                    animator.SetTrigger("Wave");
                    break;
                case Action.Pickup:
                    animator.SetTrigger("Pickup");
                    break;
            }

            animator.SetBool("isIdle", false);

            timer = 0.0f;
            
            dir.Normalize();
            
        }
        
        timer += Time.deltaTime;        
    }
}
