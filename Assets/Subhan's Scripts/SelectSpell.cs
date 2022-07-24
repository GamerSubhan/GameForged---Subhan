using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSpell : MonoBehaviour
{
    public GameObject[] prefabs;
    public FireBall fireBall;

    public ParticleSystem effect;

    public void DarkSpell()
    {
        fireBall.spell = prefabs[0];
    }

    public void FireSpell()
    {
        fireBall.spell = prefabs[1];
    }

    public void FrostBellSpell()
    {
        fireBall.spell = prefabs[2];
    }

    public void whirlindspell()
    {
        fireBall.spell = prefabs[3];
    }

    public void rainSpell()
    {
        fireBall.spell = prefabs[4];
    }

    public void healSpell()
    {
        effect.Play();
        Invoke("stopSpell", 6);
    }

    void stopSpell()
    {
        effect.Stop();
    }
}
