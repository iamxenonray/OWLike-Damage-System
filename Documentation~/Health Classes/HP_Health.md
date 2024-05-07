# HP_Health.cs
Information about the `HP_Health` class

---
This class a derived class of `HealthInstanceData`. This is the basic health type with no special behaviour. It is recommended to use this as a baseline for any custom classes you wish to create.


Function | Description 
:-----|:-----
`public HP_Health()` | Default constructor. Calls the base class default constructor.
`public HP_Health(float inHealth)` | Parameterised constructor. `inHealth` defines the current and max health. Calls the base class parameterised constructor, specifying the `Health` type and `recoverable` property set to true
`public override void ProcessDamage(Damage inDamage)` | Processes a damage instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR!**
`public override void Tick(float dt)` | Ticks the health instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**