using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] EnemyHealth enemyHealth;
    public Button meleeBt, spellBt, healBt, addSpellBt;

    public ProgressBar progressBar;
    public GameObject effect;
    public GameObject healSpell;

    private void Update()
    {
        if (progressBar.target == .5f)
        {
            spellBt.interactable = true;
            effect.SetActive(true);
            Invoke("effectDone", 6);
        }

        if (progressBar.target == 0)
        {
            spellBt.interactable = false;
        }
    }

    void effectDone()
    {
        effect.SetActive(false);
    }


    public void MeleeDamage()
    {
        enemyHealth.damage += 10;
        meleeBt.interactable = false;
        Invoke("meleeClicked", 8);
    }

    void meleeClicked()
    {
        meleeBt.interactable = true;
    }

    public void SpellPower()
    {
        progressBar.target -= .5f;
        enemyHealth.damage += 10;
        Invoke("spellClicked", 8);
        spellBt.interactable = false;
        progressBar.UpdateLevel(-1);
    }

    void spellClicked()
    {
        meleeBt.interactable = true;
    }

    public void IncreaseHealth()
    {
        health.currentHealth += 10;
        healBt.interactable = false;
        Invoke("HealClicked", 8);
    }

    void HealClicked()
    {
        healBt.interactable = true;
    }

    public void UnlockHealSpell()
    {
        healSpell.SetActive(true);
        addSpellBt.interactable = false;
    }
}
