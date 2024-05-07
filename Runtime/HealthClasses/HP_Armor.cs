// Original OW2 armor system
public class HP_Armor : HealthInstanceData
{
    public float armorDamageReduction = 0f;
    // Constructors: Make what you need
    public HP_Armor() : base()
    {
        armorDamageReduction = 0f;
    }

    public HP_Armor(float inHealth, float inArmorDamageReduction) : base(inHealth, HealthTypes.ARMOR, true)
    {
        armorDamageReduction = inArmorDamageReduction;
    }

    public override void ProcessDamage(Damage inDamage)
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

    public override void Tick(float dt)
    {
        // You should always call the base. Whether at the start or at the end is up to you.
        base.Tick(dt);
    }
}
