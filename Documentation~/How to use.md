# How to use the OWLike Damage System

To begin, import the package into Unity.

**Getting Started - Usage**
---
To use, add the `Health` component to a Game Object of your choice. This is the main interface of the system. Everything else you should only really touch if you are a developer and are customising the system.

In your Game Object, you should have a separate component that initialises the health instances of your object. Avoid doing this initialisation in the `Health.cs` class, as this will affect all objects with the component, and you likely do not want that!

To do so, you need to get the `Health` component using `GetComponent<Health>()` on the desired object. Then, access `health.AddHealthInstance(HealthInstanceData inHealthInstance)`. In the parameter you should construct a new instance of a *derived* health class (and *not* HealthInstanceData!) with the parameters you wish.

Here is an example code block. `objectToTrack` is a GameObject I specified in editor, while `healthComp` is a `Health`.

```cs
healthComp = objectToTrack.GetComponent<Health>();
healthComp.health.AddHealthInstance(new HP_Health(200f));
healthComp.health.AddHealthInstance(new HP_Armor(50f, 0.3f));
healthComp.health.AddHealthInstance(new HP_Armor2(50f, 0.5f));
healthComp.health.AddHealthInstance(new HP_Shield(100f));
```

If you wish to read more about the provided health types and their parameters, please see the `Health Classes` folder of this documentation.

To apply damage or healing, the object which is doing the application (typically on collision) should get the target's `Health` component and call `AddDamageInstance(Damage inDamage)` or `AddHealingInstance(Healing inHealing)`. It is recommended to supply a new instance or *copy* of an existing Damage or Healing instance, as the instance will be modified during processing.

Here is an example code block for a projectile which collides with the object and applies damage. For both damage and healing, the parameters are the `amount` and `owner` respectively by default. If there is no owner or you do not wish to use it, you can omit the `owner` parameter.

```cs
private void OnCollisionEnter(Collision collision)
{
    collision.gameObject.GetComponent<Health>().AddDamageInstance(new Damage(100f, gameObject));
}
```



**Getting Started - Development**
---
Before starting development on this package, it is recommended that you read the detailed documentation of the individual files located in this Documentation folder. This will give you a better understanding of the specific parts of the system.

Damage and healing
---
The classes `Damage` and `Healing` are base classes which only contain a `damageAmount`/`healingAmount` float and `owner` Game Object, alongside a parameterised constructor. These can be used as-is to apply damage and healing in the health system, or you can create your own derived classes for your custom behaviour.

The `owner` parameter can be null. Typically, you might want to have this information to determine who dealt a killing blow or for other logging purposes. As of now, this package does not come with those features by default. 

Health.cs
---
It is recommended not to touch `Health.cs`. The behaviour in the script is quite standard, and if you wish to make changes, you can likely do them inside other classes. If you want to make changes anyway, be cautious, and try not to remove things unnecessarily.

HealthData.cs
---
Most of this class contains useful helper functions to make your code neater, but the main logic lies in the functions `ProcessDamage`, `ProcessHealing`, `DamageAtIndex`, and `HealAtIndex`. These functions effectively run the entire system, and should be the first places you modify if you want to make changes to the behaviour of the system.

**Try not to touch `Tick` here. You should instead modify the health instance classes' `Tick` functions.**

HealthInstanceData.cs
---
This is the base health instance class. It is not recommended to modify anything in here, as it will apply to all your derived classes. The class is functional, but quite bare, so that derived classes have more freedom in their behaviour. That said, you should not add a `HealthInstanceData` to your `HealthData`. Instead use a derived class. The `HP_Health` class functions as a glorified wrapper for `HealthInstanceData` if you really want the simple default health behaviour.

The HealthTypes enum
---
Inside `HealthInstanceData.cs` lies the `HealthTypes` enum. This is a key enum used for identifying and sorting the different types of health. If you wish to add your own types, you can do so here. Ensure that `COUNT` is always the last entry.

**Q: Why have an enum while also making a derived class for every type of health?**

**A: Multiple derived classes can have the same `HealthType`. The most common example is the `Overhealth` health types. There are many different behaviours of these classes, but they are all `Overhealth` at their core.**

The HealthClasses folder (Derived HealthInstanceData classes)
---
Inside the `HealthClasses` folder are some basic derived classes for health instances. You can use these as a starting point or reference to make your own health classes.

To create new types of health, create a new C# file and define a class which inherits from `HealthInstanceData`. From there you are free to define whatever class members and functions you wish, but take note of the following:

1. It is highly recommended (but probably not required) to have a default constructor.
2. It is required to have a parameterised constructor. How you choose to do it is up to you.
3. It is required to invoke the base class constructor as there are private class members which need to be initialised.
4. It is required that you provide an override definition for the `ProcessDamage` function. You do **NOT** need to call the base **if** you have your own custom implementation.
5. It is required that you provide an override definition for the `Tick` function. You **MUST** call the base, but are free to do so wherever inside the function. It is recommended that you call it at the end of the function.