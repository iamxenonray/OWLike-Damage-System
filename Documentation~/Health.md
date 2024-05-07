# Health.cs
Information about the `Health` component

---
This component is the core interface of the system. If you are not a developer, this should be the only thing you touch. 

Class Member | Description 
:-----|:-----
`public HealthData health` | The main container for health. **Do not add to it in editor!**
`public float naturalRegenerationRate` | The amount of health per second that naturally regenerates
`public float shieldRegenerationRate` | The amount of health per second that naturally regenerates for shield health
`public float combatTimeThreshold` | The amount of time in seconds before natural regeneration begins
`private bool inCombat` | Whether or not the object is "in combat"
`private float combatTimer` | Timer to track how long until the object is considered "out of combat"
`private List<Damage> incomingDamage` | Incoming damage queue. **Do not modify directly!**
`private List<Healing> incomingHealing` | Incoming healing queue. **Do not modify directly!**

Function | Description 
:-----|:-----
\- | **Unless you are doing some heavy customisation, you should not touch these functions.**
`void Start()` | Nothing
`void Update()` | Main logic for the system
`public void AddDamageInstance(Damage inDamage)` | Adds an instance of Damage to the damage queue
`public void AddHealingInstance(Healing inHealing)` | Adds an instance of Healing to the healing queue