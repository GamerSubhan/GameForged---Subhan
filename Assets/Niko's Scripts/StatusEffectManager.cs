using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    [SerializeField] float burnDelay;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem fireVFX;
    private Health _health;
    private Animator _animator;

    private void Start()
    {
        _health = GetComponent<Health>();
        _animator = GetComponent<Animator>();
    }

    public void ApplyBurn(int ticks)
    {
        StartCoroutine(Burn(ticks));
    }

    private IEnumerator Burn(int ticks)
    {
        EnableFireVFX();
        for (int i = 0; i < ticks; i++)
        {
            _animator.SetTrigger("Damage");
            _health.DecreaseHealth(damage);
            if (i == 3)
            {
                DisableFireVFX();
            }
            yield return new WaitForSeconds(burnDelay);
        }
    }

    private void DisableFireVFX()
    {
        fireVFX.gameObject.SetActive(false);
        fireVFX.Stop();
    }

    private void EnableFireVFX()
    {
        fireVFX.gameObject.SetActive(true);
        fireVFX.Play();
    }
}
