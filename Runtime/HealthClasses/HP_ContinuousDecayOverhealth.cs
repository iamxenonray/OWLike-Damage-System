
public class HP_ContinuousDecayOverhealth : HealthInstanceData
{
    public float decayStep = 0f;

    // Constructors: Make what you need
    // Default: Shouldn't be called, but exists for safety and comprehensiveness
    public HP_ContinuousDecayOverhealth() : base()
    {
        recoverable = false;
        decayStep = 0f;
    }

    // inDecayTime: Time in seconds that the health will naturally decay from full to zero
    public HP_ContinuousDecayOverhealth(float inHealth, float inDecayTime) : base(inHealth, HealthTypes.OVERHEALTH, false)
    {
        decayStep = (inDecayTime == 0f) ? 0f : inHealth / inDecayTime;
    }

    public override void ProcessDamage(Damage inDamage)
    {
        // You do NOT need to call the base if you have your own custom implementation!
        base.ProcessDamage(inDamage);
    }

    public override void Tick(float dt)
    {
        healthAmount -= decayStep * dt;
        // You should always call the base. Whether at the start or at the end is up to you.
        base.Tick(dt);
    }
}
