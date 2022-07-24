using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityHolder : MonoBehaviour
{
    [SerializeField] enum AbilityState { ready, onCooldown }
    [SerializeField] KeyCode key;
    [SerializeField] Ability[] abilities;
    Ability currentAbility;
    float cooldownTime;
    AbilityState state = AbilityState.ready;

    private void Start()
    {
        currentAbility = abilities[0];
    }

    void Update()
    {
        GetCurrentAbility();
        AbilityInvoker(currentAbility);
    }

    private void GetCurrentAbility()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentAbility = abilities[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentAbility = abilities[1];
        }
    }

    private void AbilityInvoker(Ability currentAbility)
    {
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key))
                {
                    currentAbility.Activate(gameObject);
                    state = AbilityState.onCooldown;
                    cooldownTime = currentAbility.cooldownTime;
                }
                break;
            case AbilityState.onCooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
            default:
                break;
        }
    }
}
