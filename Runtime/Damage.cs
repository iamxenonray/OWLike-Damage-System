using System;
using UnityEngine;

[Serializable]
// This is a base class, implement your own damage types inheriting this class.
public class Damage
{
    public float damageAmount = 0f;
    public GameObject owner = null;

    public Damage(float inDamageAmount, GameObject inOwner = null)
    {
        damageAmount = inDamageAmount;
        owner = inOwner;
    }
}
