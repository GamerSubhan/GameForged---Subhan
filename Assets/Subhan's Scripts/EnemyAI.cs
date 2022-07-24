using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform player;
    public float maxDistance;
    Animator anim_;
    Vector3 target;
    EnemyHealth enemyHealth;
    public bool opponentDead;

    void Start()
    {
        agent = (NavMeshAgent)GetComponent("NavMeshAgent");
        anim_ = (Animator)GetComponent("Animator");
        enemyHealth = (EnemyHealth)GetComponent("EnemyHealth");
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        agent.SetDestination(target);

        if (distance <= maxDistance && enemyHealth.isDead == false)
        {
            target = player.position;
            anim_.SetBool("Run", true);
        }

        else
        {
            target = transform.position;
        }

        if (distance <= 1.8f && enemyHealth.isDead == false)
        {
            transform.LookAt(player.position);
            target = transform.position;
            anim_.SetBool("Attack", true);
            anim_.SetBool("Run", false);
        }

        else if(distance <= 1.8f && enemyHealth.isDead == true)
        {
            this.enabled = false;
        }

        if (opponentDead == true)
        {
            anim_.SetBool("Attack", false);
        }

    }


    
}
