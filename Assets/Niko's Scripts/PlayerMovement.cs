using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] LayerMask enemyLayer;
    private AIPath _AIPath;
    private AIDestinationSetter _AIDestinationSetter;
    private Animator _animator;
    NavMeshAgent meshAgent;
    public Transform enemy;
    public float maxDistance, minDistance;
    public EnemyHealth enemyHealth;
    RaycastHit hit;
    public AudioSource coinSound;
    private Inventory inventory;
    Health health;

    [SerializeField] UI_Inventory ui_inventory;



    bool hasHit;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _AIDestinationSetter = GetComponent<AIDestinationSetter>();
        _AIPath = GetComponent<AIPath>();
        meshAgent = (NavMeshAgent)GetComponent("NavMeshAgent");
        health = GetComponent<Health>();

        _AIDestinationSetter.target.position = transform.position;

        inventory = new Inventory();
        ui_inventory.SetInventory(inventory);

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MoveToCursour();

        }

        AttackSystem();
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = _AIPath.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = Mathf.Abs(localVelocity.z);
        if (Mathf.Abs(transform.position.z - target.transform.position.z) <= 0.01f)
        {
            speed = 0;
        }
        _animator.SetFloat("ForwardSpeed", speed);
    }

    private void MoveToCursour()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(ray, out hit);

        if (hasHit)
        {
            if (hit.collider.gameObject.layer == 7)
            {
                target.transform.position = hit.point;
            }
            _AIDestinationSetter.target.position = hit.point;
        }
    }


    void AttackSystem()
    {
        float distance = Vector3.Distance(enemy.position, transform.position);

        if (distance <= maxDistance && distance >= minDistance && enemyHealth.isDead == false)
        {
            _AIDestinationSetter.target.position = enemy.position;
        }

        if (distance <= 1.8f && enemyHealth.isDead == false)
        {
            transform.LookAt(enemy.position);
            _AIDestinationSetter.target.position = transform.position;
            _animator.SetBool("CastSpell", true);
        }

        else if (distance <= 1.8f && enemyHealth.isDead == true)
        {
            _animator.SetBool("CastSpell", false);
            _AIDestinationSetter.target.position = hit.point;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        ItemWorld _itemWorld = other.GetComponent<ItemWorld>();

        if (_itemWorld != null)
        {
            inventory.AddItem(_itemWorld.GetItem());
        }

        if (other.tag == "Treasure")
        {
            Destroy(other.gameObject);
            coinSound.Play();
            inventory.AddItem(_itemWorld.GetItem());
        }
    }

    

    private void SetMeleeDamage(int damage)
    {

    }

}
