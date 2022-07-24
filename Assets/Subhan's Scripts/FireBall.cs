using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Transform stick;
    public GameObject spell;
    public float startTime, rateTime;
    public EnemyHealth enemyHealth;
    public Health playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            InvokeRepeating("Fire", startTime, rateTime);
        }

        if (enemyHealth.isDead == true || playerHealth.playerDead == true)
        {
            CancelInvoke("Fire");
        }
    }

    void Fire()
    {
        var clone = Instantiate(spell, transform.position, Quaternion.Euler(0, 90, 0));
        Destroy(clone, .6f);
    }
}
