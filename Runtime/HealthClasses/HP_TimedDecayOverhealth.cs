
public class HP_TimedDecayOverhealth : HealthInstanceData
{
    public float decayTime = 0f;

    // Constructors: Make what you need
    // Default: Shouldn't be called, but exists for safety and comprehensiveness
    public HP_TimedDecayOverhealth() : base()
    {
        recoverable = false;
        decayTime = 0f;
    }

    // inDecayTime: Time in seconds that the health will naturally decay from full to zero
    public HP_TimedDecayOverhealth(float inHealth, float inDecayTime) : base(inHealth, HealthTypes.OVERHEALTH, false)
    {
        decayTime = inDecayTime;
    }

    public override void ProcessDamage(Damage inDamage)
    {
        // You do NOT need to call the base if you have your own custom implementation!
        base.ProcessDamage(inDamage);
    }

    public override void Tick(float dt)
    {
        decayTime -= dt;
        if (decayTime <= 0f) healthAmount = 0f;
        // You should always call the base. Whether at the start or at the end is up to you.
        base.Tick(dt);
    }
}
