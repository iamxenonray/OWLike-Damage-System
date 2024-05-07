# HP_TimedDecayOverhealth.cs
Information about the `HP_TimedDecayOverhealth` class

---
This class a derived class of `HealthInstanceData`. This is a type of `Overhealth` which lasts for a specified length of time, after which it fully disappears.

In Overwatch, `Overhealth` is unrecoverable. This type of `Overhealth` can be seen in abilities such as Wrecking Ball's Adaptive Shield or Junker Queen's Commanding Shout.

Class Member | Description 
:-----|:-----
`public float decayTime` | The amount of time left before the health expires

Function | Description 
:-----|:-----
`public HP_TimedDecayOverhealth()` | Default constructor. Calls the base class default constructor.
`public HP_TimedDecayOverhealth(float inHealth, float inDecayTime)` | Parameterised constructor. `inHealth` defines the current and max health. Calls the base class parameterised constructor, specifying the `Overhealth` type and `recoverable` property set to false. `inDecayTime` is the time in seconds before the health expires
`public override void ProcessDamage(Damage inDamage)` | Processes a damage instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR!**
`public override void Tick(float dt)` | Ticks the health instance. Health decay behaviour is processed here
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**