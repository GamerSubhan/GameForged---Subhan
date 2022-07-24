using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instace { get; private set; }

    private void Awake()
    {
        Instace = this;
    }

    public Transform pfItemWorld;

    public Sprite treasure;
    public Sprite vitalityBell;
}
