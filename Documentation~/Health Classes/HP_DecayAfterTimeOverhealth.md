# HP_DecayAfterTimeOverhealth.cs
Information about the `HP_DecayAfterTimeOverhealth` class

---
This class a derived class of `HealthInstanceData`. This is a type of `Overhealth` which does not decay for a length of time, after which it naturally decays. This is like a combination of `HP_ContinuousDecayOverhealth` and `HP_TimedDecayOverhealth`.

In Overwatch, `Overhealth` is unrecoverable. This type of `Overhealth` can be seen in abilities such as Lifeweaver's Tree of Life or Sigma's Kinetic Grasp.

Class Member | Description 
:-----|:-----
`public float decayStep` | The amount of health lost per second to decay
`public float decayDelay` | The amount of time before health starts to decay

Function | Description 
:-----|:-----
`public HP_DecayAfterTimeOverhealth()` | Default constructor. Calls the base class default constructor.
`public HP_DecayAfterTimeOverhealth(float inHealth, float inDecayTime, float inDecayDelay)` | Parameterised constructor. `inHealth` defines the current and max health. Calls the base class parameterised constructor, specifying the `Overhealth` type and `recoverable` property set to false. `inDecayTime` is the time in seconds before the health decays naturally from full to zero. `inDecayDelay` is the time in seconds before decay begins
`public override void ProcessDamage(Damage inDamage)` | Processes a damage instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR!**
`public override void Tick(float dt)` | Ticks the health instance. Health decay behaviour is processed here
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**