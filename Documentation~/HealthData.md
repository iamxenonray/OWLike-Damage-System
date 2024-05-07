# HealthData.cs
Information about the `HealthData` class

---
This class handles the main logic of the system. If you are a developer, you will probably be spending a lot of time here, so take some time to read this.

Class Member | Description 
:-----|:-----
`public List<HealthInstanceData> healthInstances` | The main container for health instances. **Do not add to it in editor!** This list functions similarly to a stack in most logic calculations, you should generally treat it like one


Function | Description 
:-----|:-----
`public float GetMaxHealth()` | Returns the maximum health the object has
`public float GetDisplayMaxHealth()` | Returns GetMaxHealth() rounded up to an int. For use in displaying the object's health
`public float GetCurrentHealth()` | Returns the current health the object has
`public float GetDisplayCurrentHealth()` | Returns GetCurrentHealth() rounded up to an int. For use in displaying the object's health
`public HealthInstanceData GetTop()` | Returns the last health instance object
`public HealthInstanceData GetBottom()` | Returns the first health instance object
`public void AddHealthInstance(HealthInstanceData inHealthInstance)` | Adds an instance of health. When initialising or adding new instances of health, use this function!
`public bool HasHealthType(HealthTypes inType)` | Checks if the object has an instance of health of this type
`public int GetFirstOfType(HealthTypes inType)` | Returns the index of the first instance of this type of health
`public int GetFirstNotFullOfType(HealthTypes inType)` | Returns the index of the first instance of this type of health that is recoverable and whose current health is less than its max health
`public int GetLastOfType(HealthTypes inType)` | Returns the index of the last instance of this type of health
`public int GetLastNotFullOfType(HealthTypes inType)` | Returns the index of the last instance of this type of health that is recoverable and whose current health is less than its max health
`public void Tick(float dt)` | Ticks all health instances. Supply the delta time to this function. This is called in Health.cs, it is recommended you do not call it elsewhere
`public void ProcessDamage(Damage inDamage)` | Logic to process a damage instance. This is probably what you want to customise
`public void ProcessHealing(Healing inHealing)` | Logic to process a healing instance. This is probably what you want to customise
`public void DamageAtIndex(int idx, Damage inDamage)` | Processes a damage instance starting at a specific index. Useful if you wish to deal direct damage to a specific type of health
`public void HealAtIndex(int idx, Healing inHealing, Healthtypes inRestriction = Healthtypes.COUNT)` | Processes a healing instance starting at a specific index. You can specify a restriction so that you only heal that type of health. Leaving it at the default parameter means no restriction
`private HealthInstanceData ValidIndex(int idx)` | Helper to check if an index is valid
`private void SortHealthInstances()` | Sorts health instances by type. Done when adding new health instances. Sorts in order of the HealthTypes enum