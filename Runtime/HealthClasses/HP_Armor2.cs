// OW1 and OW2 S10 Midseason+ armor system
public class HP_Armor2 : HealthInstanceData
{
    public float armorDamageReduction = 0f;
    public float armorThreshold = 0f;
    // Constructors: Make what you need
    public HP_Armor2() : base()
    {
        armorDamageReduction = 0f;
        armorThreshold = 0f;
    }

    public HP_Armor2(float inHealth, float inArmorDamageReduction, float inArmorThreshold) : base(inHealth, HealthTypes.ARMOR, true)
    {
        armorDamageReduction = inArmorDamageReduction;
        armorThreshold = inArmorThreshold;
    }

    public override void ProcessDamage(Damage inDamage)
    {
        if (inDamage.damageAmount >= (armorThreshold / (1f - armorDamageReduction)))
        {
            if (inDamage.damageAmount + armorThreshold >= healthAmount)
            {
                inDamage.damageAmount -= healthAmount + armorThreshold;
                healthAmount = 0f;
            }
            else
            {
                healthAmount -= (inDamage.damageAmount - armorThreshold);
                inDamage.damageAmount = 0f;
            }
        }
        else
        {
            if (inDamage.damageAmount * (1f - armorDamageReduction) >= healthAmount)
            {
                inDamage.damageAmount -= (healthAmount / (1f - armorDamageReduction));
                healthAmount = 0f;
            }
            else
            {
                healthAmount -= (inDamage.damageAmount * (1f - armorDamageReduction));
                inDamage.damageAmount = 0f;
            }
        }
    }

    public override void Tick(float dt)
    {
        // You should always call the base. Whether at the start or at the end is up to you.
        base.Tick(dt);
    }
}
