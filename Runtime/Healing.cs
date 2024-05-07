using System;
using UnityEngine;

[Serializable]
// This is a base class, implement your own healing types inheriting this class.
public class Healing
{
    public float healingAmount = 0f;
    public GameObject owner = null;

    public Healing(float inHealingAmount, GameObject inOwner = null)
    {
        healingAmount = inHealingAmount;
        owner = inOwner;
    }
}
