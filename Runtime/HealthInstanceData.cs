using System;

/*
 * You can modify this for your custom behaviour
 */
public enum HealthTypes
{
    HEALTH,
    ARMOR,
    SHIELD,
    OVERHEALTH,
    COUNT
}

[Serializable]
public class HealthInstanceData
{
    // Basic properties
    public float healthAmount = 0f;
    public float maxHealthAmount = 0f;
    public HealthTypes healthType = HealthTypes.HEALTH;

    /*
     Flag for recoverable health
     Recoverable health will not be removed once healthAmount <= 0.
     */
    public bool recoverable = true;

    private bool destroyFlag = false;

    public HealthInstanceData()
    {
        healthAmount = 0f;
        maxHealthAmount = 0f;
        healthType = HealthTypes.HEALTH;
        recoverable = true;
        destroyFlag = false;
    }

    public HealthInstanceData(float inHealth, HealthTypes inHealthType, bool inRecoverable)
    {
        healthAmount = maxHealthAmount = inHealth;
        healthType = inHealthType;
        recoverable = inRecoverable;
        destroyFlag = false;
    }

    public float GetMaxHealth()
    {
        return (recoverable ? maxHealthAmount : healthAmount);
    }

    public bool GetDestroy()
    {
        return destroyFlag;
    }

    public virtual void ProcessDamage(Damage inDamage)
    {
        if (inDamage.damageAmount >= healthAmount)
        {
            inDamage.damageAmount -= healthAmount;
            healthAmount = 0f;
        }
        else
        {
            healthAmount -= inDamage.damageAmount;
            inDamage.damageAmount = 0f;
        }
    }

    public virtual void Tick(float dt)
    {
        if (!recoverable && healthAmount <= 0f) destroyFlag = true;
    }
}
