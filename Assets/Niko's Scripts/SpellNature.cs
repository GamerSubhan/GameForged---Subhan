using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.AI;
using Pathfinding;

[CreateAssetMenu]
public class SpellNature : Ability
{
    [SerializeField] float radius = 10;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] int deathDelay = 400;
    public ParticleSystem effect;
    public float range = 10;
    public float upRange = 3;
    private Vector3 hitPosition;

    public override void Activate(GameObject parent)
    {
        parent.GetComponent<Animator>().SetTrigger("CastSpell");
        parent.GetComponent<AIDestinationSetter>().target.position = parent.transform.position;
        DamageEnemies(parent);
    }

    async void DamageEnemies(GameObject parent)
    {
        hitPosition = parent.GetComponent<Transform>().localPosition + parent.GetComponent<Transform>().forward;
        Instantiate(effect, hitPosition + new Vector3(0, upRange, 0), Quaternion.identity);

        await Task.Delay(deathDelay);

        Collider[] hitEnemies = Physics.OverlapSphere(hitPosition, radius, enemyLayers);
        foreach (var item in hitEnemies)
        {
            Debug.Log(item.name);
            Destroy(item.gameObject);
        }
    }
}
