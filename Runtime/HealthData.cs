using System.Collections;
using System.Collections.Generic;
using System;


[Serializable]
public class HealthData
{
    public List<HealthInstanceData> healthInstances = new List<HealthInstanceData>();

    public float GetMaxHealth()
    {
        float maxhealth = 0f;
        foreach (HealthInstanceData h in healthInstances)
        {
            maxhealth += h.GetMaxHealth();
        }
        return maxhealth;
    }

    public float GetDisplayMaxHealth()
    {
        return MathF.Ceiling(GetMaxHealth());
    }

    public float GetCurrentHealth()
    {
        float currentHealth = 0f;
        foreach (HealthInstanceData h in healthInstances)
        {
            currentHealth += MathF.Max(h.healthAmount, 0f);
        }
        return (currentHealth < 0f ? 0f : currentHealth);
    }

    public float GetDisplayCurrentHealth()
    {
        return MathF.Ceiling(GetCurrentHealth());
    }

    private HealthInstanceData ValidIndex(int idx)
    {
        return (healthInstances[idx] != null ? healthInstances[idx] : null);
    }

    public HealthInstanceData GetTop()
    {
        return ValidIndex(healthInstances.Count-1);
    }

    public HealthInstanceData GetBottom()
    {
        return ValidIndex(0);
    }

    public void AddHealthInstance(HealthInstanceData inHealthInstance)
    {
        healthInstances.Add(inHealthInstance);
        SortHealthInstances();
    }

    private void SortHealthInstances()
    {
        healthInstances.Sort(delegate (HealthInstanceData x, HealthInstanceData y)
        {
            return ((int)x.healthType - (int)y.healthType);
        });
    }

    public bool HasHealthType(HealthTypes inType)
    {
        return healthInstances.Exists(x => x.healthType == inType);
    }

    public int GetFirstOfType(HealthTypes inType)
    {
        return healthInstances.FindIndex(x => x.healthType == inType);
    }

    public int GetFirstNotFullOfType(HealthTypes inType)
    {
        return healthInstances.FindIndex(x => (x.healthType == inType && x.recoverable && x.healthAmount < x.GetMaxHealth()));
    }

    public int GetLastOfType(HealthTypes inType)
    {
        return healthInstances.FindLastIndex(x => x.healthType == inType);
    }

    public int GetLastNotFullOfType(HealthTypes inType)
    {
        return healthInstances.FindLastIndex(x => (x.healthType == inType && x.healthAmount < x.GetMaxHealth()));
    }

    public void Tick(float dt)
    {
        for (int i = healthInstances.Count - 1; i >= 0; --i)
        {
            healthInstances[i].Tick(dt);
            if (healthInstances[i].GetDestroy()) healthInstances.RemoveAt(i);
        }
    }

    // Processing damage
    public void ProcessDamage(Damage inDamage)
    {
        for (int i = healthInstances.Count - 1; i >= 0; --i)
        {
            if (inDamage.damageAmount <= 0f) return;
            if (healthInstances[i].healthAmount <= 0) continue;
            healthInstances[i].ProcessDamage(inDamage);
        }
    }

    // Processing healing
    public void ProcessHealing(Healing inHealing)
    {
        for (int i = 0; i < healthInstances.Count; ++i)
        {
            if (healthInstances[i].recoverable)
            {
                // TODO: Maybe rework into instanced ProcessHealing?
                if (healthInstances[i].healthAmount >= healthInstances[i].GetMaxHealth()) continue;
                if (inHealing.healingAmount > (healthInstances[i].GetMaxHealth() - healthInstances[i].healthAmount))
                {
                    inHealing.healingAmount -= (healthInstances[i].GetMaxHealth() - healthInstances[i].healthAmount);
                    healthInstances[i].healthAmount = healthInstances[i].GetMaxHealth();
                }
                else
                {
                    healthInstances[i].healthAmount += inHealing.healingAmount;
                    inHealing.healingAmount = 0f;
                    return;
                }
            }
            else return;
        }
    }

    public void DamageAtIndex(int idx, Damage inDamage)
    {
        if (idx == -1) return;
        for (int i = idx; i >= 0; --i)
        {
            if (inDamage.damageAmount <= 0f) return;
            if (healthInstances[i].healthAmount <= 0) continue;
            healthInstances[i].ProcessDamage(inDamage);
        }
    }

    // Specify a health type for inRestriction if you wish to only heal that type of health
    public void HealAtIndex(int idx, Healing inHealing, HealthTypes inRestriction = HealthTypes.COUNT)
    {
        if (idx == -1) return;
        for (int i = idx; i < healthInstances.Count; ++i)
        {
            if (inRestriction != HealthTypes.COUNT && healthInstances[i].healthType != inRestriction) return;
            if (healthInstances[i].recoverable)
            {
                if (inHealing.healingAmount > healthInstances[i].GetMaxHealth())
                {
                    inHealing.healingAmount -= (healthInstances[i].GetMaxHealth() - healthInstances[i].healthAmount);
                    healthInstances[i].healthAmount = healthInstances[i].GetMaxHealth();
                }
                else
                {
                    healthInstances[i].healthAmount = MathF.Min(healthInstances[i].healthAmount + inHealing.healingAmount, healthInstances[i].GetMaxHealth());
                    inHealing.healingAmount = 0f;
                    return;
                }
            }
            else return;
        }
    }
}
