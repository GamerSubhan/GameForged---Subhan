using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    [SerializeField] float attackSpeed = 0.5f;
    [SerializeField] float offSetY;
    [SerializeField] float offSetZ;
    [SerializeField] Transform parent;
    [SerializeField] Transform projectileHolder;
    private ObjectPooler _objectPooler;
    private SelectionManager _selectionManager;
    private Animator _animator;


    void Start()
    {
        _objectPooler = ObjectPooler.Instance;
        _selectionManager = FindObjectOfType<SelectionManager>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_selectionManager.selectedGameObject == null || _selectionManager.selectedGameObject.layer != 6)
            {
                Debug.Log("you are hitting nothing");
                return;
            }

            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        //_animator.SetTrigger("CastSpell");
        yield return new WaitForSeconds(0.2f);
        _objectPooler.SpawnFromPool("Basic Attack", projectileHolder.position, parent.transform.rotation);
        yield return new WaitForSeconds(attackSpeed);
    }
}
