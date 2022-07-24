using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    public int currentHealth;
    Animator anim;
    [SerializeField] GameObject attackDetector;
    [SerializeField] EnemyAI enemyAI;
    public bool playerDead;


    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Weapon")
        {
            currentHealth -= 20;

            if (currentHealth <= 0)
            {
                anim.SetTrigger("Die");
                anim.SetBool("CastSpell", false);
                enemyAI.enabled = false;
                Destroy(attackDetector);
                playerDead = true;
            }

        }
    }

    public void DecreaseHealth(float damage)
    {

    }
}
