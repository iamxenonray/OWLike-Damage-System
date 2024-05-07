# HP_Armor2.cs
Information about the `HP_Armor2` class

---
This class a derived class of `HealthInstanceData`. This health has a damage reduction element to it. It implements a special processing function to facilitate the implementation of the damage reduction.

This armour is based on the armour health from the original Overwatch 1 and Overwatch 2 Season 10 Midseason patch armour system (Damage reduction up to a specified amount)

In Overwatch, this is a 50% damage reduction OR 5 damage reduced, whichever is lower.

Class Member | Description 
:-----|:-----
`public float armorDamageReduction` | Percentage of damage reduced. Ranges from `0` to `1` (but not including `1`)
`public float armorThreshold` | Maximum amount of damage reduced

Function | Description 
:-----|:-----
`public HP_Armor2()` | Default constructor. Calls the base class default constructor.
`public HP_Armor2(float inHealth, float inArmorDamageReduction, float inArmorThreshold)` | Parameterised constructor. `inHealth` defines the current and max health. Calls the base class parameterised constructor, specifying the `Armor` type and `recoverable` property set to true
`public override void ProcessDamage(Damage inDamage)` | Processes damage with the damage reduction applied
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR (SUCH AS THIS CLASS)!**
`public override void Tick(float dt)` | Ticks the health instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**