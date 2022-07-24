using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int currentHealth;
    Animator anim;
    [SerializeField] GameObject attackDetector;
    [SerializeField] PlayerMovement player;
    public GameObject treasure;
    bool isSpawned;
    public bool isDead;
    BoxCollider _collider;
    public Health playerHealth;
    public int damage = 20;

    public ProgressBar progressBar;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        _collider = (BoxCollider)GetComponent("BoxCollider");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spell")
        {
            currentHealth -= damage;
            progressBar.UpdateProgress(0.1f);

            if (currentHealth <= 0)
            {
                isDead = true;
                _collider.enabled = false;
                anim.SetTrigger("Die");
                anim.SetBool("Attack", false);
                Invoke("Disapppear", 3);
                

                if (!isSpawned)
                {
                    Invoke("SpawnTreasure", 1.3f);
                }
                
            }

            else
            {
                anim.SetBool("Attack", true);
            }
        }
    }

    void SpawnTreasure()
    {
        ItemWorld.spawnItemWorld(transform.position, new Item { itemType = Item.ItemType.Treasure, itemAmount = 0 });
        isSpawned = true;
    }

    void Disapppear()
    {
        this.gameObject.SetActive(false);
    }

}
