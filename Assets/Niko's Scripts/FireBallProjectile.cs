using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FireBallProjectile : Ability
{
    [SerializeField] ParticleSystem fireBall;
    [SerializeField] float offSetY;
    [SerializeField] float offSetZ;

    public override void Activate(GameObject parent)
    {
        parent.GetComponent<Animator>().SetTrigger("CastSpell");
        parent.GetComponent<AIDestinationSetter>().target.position = parent.transform.position;
        Instantiate(fireBall, parent.transform.position + new Vector3(0, offSetY, offSetZ), parent.transform.rotation);
    }

}
