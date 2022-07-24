using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public float DestroyExplosion = 4.0f;
    public float DestroyChildren = 2.0f;
    public float lifeTime = 0.5f;
    public Vector2 Velocity;
    public float speed = 10f;
    Rigidbody rb;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * speed);
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            gameObject.SetActive(false);
            lifeTime = 0.5f;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject.name);
        ApplyDamageOverTime(col);
        DisplayHiteffect();
        DestroyGameObject();
    }

    private static void ApplyDamageOverTime(Collision col)
    {
        var statusEffectManager = col.gameObject.GetComponent<StatusEffectManager>();
        if (statusEffectManager != null)
        {
            statusEffectManager.ApplyBurn(4);
        }
    }

    private void DisplayHiteffect()
    {
        var exp = Instantiate(ExplosionPrefab, transform.position, ExplosionPrefab.transform.rotation);
        Destroy(exp, DestroyExplosion);
    }

    private void DestroyGameObject()
    {
        gameObject.SetActive(false);

        //Transform child = transform.GetChild(0);
        //transform.DetachChildren();
        //Destroy(child.gameObject, DestroyChildren);
        //Destroy(gameObject);
    }
}
