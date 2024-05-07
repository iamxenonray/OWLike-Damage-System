using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 This is the main class you want to edit
 Your custom behaviour goes here
 */

public class Health : MonoBehaviour
{

    [Header("Health Options")]
    // Do not add to this yourself!
    public HealthData health = new HealthData();
    public float naturalRegenerationRate = 20f;
    public float shieldRegenerationRate = 20f;
    public float combatTimeThreshold = 2f;

    private bool inCombat = false;
    private float combatTimer = 0f;
    private List<Damage> incomingDamage = new List<Damage>();
    private List<Healing> incomingHealing = new List<Healing>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inCombat) combatTimer -= Time.deltaTime;
        if (incomingDamage.Count > 0)
        {
            inCombat = true;
            combatTimer = combatTimeThreshold;
        }

        if (combatTimer <= 0f)
        {
            inCombat = false;
            health.ProcessHealing(new Healing(naturalRegenerationRate * Time.deltaTime));
            if (health.HasHealthType(HealthTypes.SHIELD))
            {
                health.HealAtIndex(health.GetFirstNotFullOfType(HealthTypes.SHIELD), new Healing(shieldRegenerationRate * Time.deltaTime), HealthTypes.SHIELD);
            }
        }

        foreach (Healing h in incomingHealing)
        {
            health.ProcessHealing(h);
        }

        foreach (Damage d in incomingDamage)
        {
            health.ProcessDamage(d);
        }
        health.Tick(Time.deltaTime);

        // All incoming damage/healing is processed on a per-tick basis
        incomingDamage.Clear();
        incomingHealing.Clear();
    }

    public void AddDamageInstance(Damage inDamage)
    {
        incomingDamage.Add(inDamage);
    }

    public void AddHealingInstance(Healing inHealing)
    {
        incomingHealing.Add(inHealing);
    }

    // If you have specialised damage/healing, you can add functions to deal with them here
}
