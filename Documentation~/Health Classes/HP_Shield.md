# HP_Shield.cs
Information about the `HP_Shield` class

---
This class a derived class of `HealthInstanceData`. This is the basic Shield health type. In Overwatch, this type of health naturally regenerates. Note that the behaviour for this property does not exist within the class, but inside `Health.cs`'s `Update()` function.


Function | Description 
:-----|:-----
`public HP_Shield()` | Default constructor. Calls the base class default constructor.
`public HP_Shield(float inHealth)` | Parameterised constructor. `inHealth` defines the current and max health. Calls the base class parameterised constructor, specifying the `Shield` type and `recoverable` property set to true
`public override void ProcessDamage(Damage inDamage)` | Processes a damage instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR!**
`public override void Tick(float dt)` | Ticks the health instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**