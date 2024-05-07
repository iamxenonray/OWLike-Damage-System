# HealthInstanceData.cs
Information about the `HealthInstaceData` class

---
This class is the base class of health instances. You should not directly add `HealthInstanceData`s to your HealthData container, rather you should only add derived classes to it.

# The HealthTypes Enum
This enum lists the various types of health that exist in the system, with `COUNT` being the marker of the last item, and is not itself an item. You can customise this however you wish. Note that the order listed is the order that the health instances will be sorted in.

Class Member | Description 
:-----|:-----
`public float healthAmount` | The current health that the health instance contains
`public float maxHealthAmount` | The maximum health that the health instance can contain. Only used in recoverable health
`public HealthTypes healthType` | The type of health this is
`public bool recoverable` | Can this health be recovered?
`private bool destroyFlag` | Flag for destruction. If true, this instance will be destroyed (processed in `HealthData` `Tick` function)


Function | Description 
:-----|:-----
`public HealthInstanceData()` | Default constructor. Creates a 0 health Health which is recoverable. Generally do not call this, unless you make your own implementation.
`public HealthInstanceData(float inHealth, HealthTypes inHealthType, bool inRecoverable)` | Parameterised constructor. `inHealth` defines the current and max health.
\- | **When creating derived class constructors, always call the base constructors as well! This means that anything you modify here will affect ALL health classes! See the provided derived class examples for more information**
`public float GetMaxHealth()` | If recoverable, return the max health, otherwise, return the current health
`public bool GetDestroy()` | Returns the `destroyFlag`
`public virtual void ProcessDamage(Damage inDamage)` | Processes a damage instance.
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `ProcessDamage`! THE BASE `ProcessDamage` IMPLEMENTS A SIMPLE BEHAVIOUR, SO SIMPLY CALL THE BASE FUNCTION UNLESS YOU ARE IMPLEMENTING CUSTOM BEHAVIOUR!**
`public virtual void Tick(float dt)` | Ticks the health instance
\- | **IMPORTANT! ALL DERIVED CLASSES MUST IMPLEMENT `Tick`! ADDITIONALLY, THEY MUST CALL THE BASE `Tick` FUNCTION!**