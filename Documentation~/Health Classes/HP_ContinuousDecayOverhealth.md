# HP_ContinuousDecayOverhealth.cs
Information about the `HP_ContinuousDecayOverhealth` class

---
This class a derived class of `HealthInstanceData`. This is a type of `Overhealth` which linearly decays over a specified period of time.

In Overwatch, `Overhealth` is unrecoverable. This type of `Overhealth` can be seen in Lucio's Sound Barrier ability.

Class Member | Description 
:-----|:-----
`public float decayStep` | The amount of health lost per second to decay

Function | Description 
:-----|:-----
`public HP_ContinuousDecayOverhealth()` | Default constructor. Calls the base class default constructor.
`public HP_ContinuousDecayOverhealth(float inHealth, float inDecayTime)` | Parameterised constructor. `inHealth` defines the current and max health. Calls the base class parameterised constructor, specifying the `Overhealth` type and `recoverable` property set to false. `inDecayTime` is the time in seconds for the health to naturally decay from full to zero, if no damage is present. `decayStep` is calculated based on this parameter.
`public override void ProcessDamage(Damage inDamage)` | Processes a damage instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR!**
`public override void Tick(float dt)` | Ticks the health instance. Health decay behaviour is processed here
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**