# HP_Armor.cs
Information about the `HP_Armor` class

---
This class a derived class of `HealthInstanceData`. This health has a damage reduction element to it. It implements a special processing function to facilitate the implementation of the damage reduction.

This armour is based on the armour health from the original Overwatch 2 armour system (Flat damage reduction)

Class Member | Description 
:-----|:-----
`public float armorDamageReduction` | Percentage of damage reduced. Ranges from `0` to `1`

Function | Description 
:-----|:-----
`public HP_Armor()` | Default constructor. Calls the base class default constructor.
`public HP_Armor(float inHealth, float inArmorDamageReduction)` | Parameterised constructor. `inHealth` defines the current and max health. Calls the base class parameterised constructor, specifying the `Armor` type and `recoverable` property set to true
`public override void ProcessDamage(Damage inDamage)` | Processes damage with the damage reduction applied
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR (SUCH AS THIS CLASS)!**
`public override void Tick(float dt)` | Ticks the health instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**