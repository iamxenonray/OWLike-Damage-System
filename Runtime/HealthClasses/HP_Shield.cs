
public class HP_Shield : HealthInstanceData
{
    // Constructors: Make what you need
    public HP_Shield() : base()
    {

    }

    public HP_Shield(float inHealth) : base(inHealth, HealthTypes.SHIELD, true)
    {

    }

    public override void ProcessDamage(Damage inDamage)
    {
        // You do NOT need to call the base if you have your own custom implementation!
        base.ProcessDamage(inDamage);
    }

    public override void Tick(float dt)
    {
        // You should always call the base. Whether at the start or at the end is up to you.
        base.Tick(dt);
    }
}
