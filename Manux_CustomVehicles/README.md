<!--Read this in github to have all the visuals and formatting: https://github.com/manux32/7dtdSdxMods/tree/master/Manux_HPMiniBike-->

# Custom Vehicles 
| ![img](Icons/roadHogChassis.png) | ![img](Icons/hellGoatBikeChassis.png) | ![img](Icons/quadChassis.png) | ![img](Icons/cicadaCarChassis.png) | ![img](Icons/loaderChassis.png) | ![img](Icons/helicopterChassis.png) |
|:---:|:---:|:---:|:---:|:---:|:---:|  
| Dust2Death's Road Hog | Hell Goat Bike | Quad | Cicada Car | The Beast (Loader) | Helicopter |

The Custom Vehicles mod is there to help you build your own custom vehicles, from custom Bikes to custom Cars, Quads, Trucks.  
You can make all-terrain vehicles that can climb small and medium objects, and control the camera distance, and player position/orientation on the vehicle.  

**New:**  Thanks to **Three8**, all vehicles now have the abillity to go underwater (controlled via XML properties).  
The Beast (Loader) is currently the only vehicle that can destroy and harvest the environment and buildings, but I will make that availlable to all vehicles in the near future...  You can currently control what gets destroyed and harvested for The Beast, all defined through XML properties. You can also set it to harvest directly to the vehicle storage.  
And we now have our first flying vehicle, the Helicopter. This is still a bit experimental, but it works, and it's so much fun! And it also now shoots bullets and missiles! Actually all vehicles can now shoot bullets and explosives of all sorts. :stuck_out_tongue_winking_eye:  

The mod contains multiple different examples of already functionnal bikes and cars/trucks.  
It also contains examples of custom vehicle parts. Check-out the [**Custom Vehicle Parts section**](#custom-vehicle-parts).  
I will eventually try to make tutorials or youtube vids to help you build your own, if there is enough demand for it.  

I you want to build your own, I recommend starting with something simple like a custom bike. The Car, Quad, Loader and Helicopter are more complex on the rigging side.  
You can grab Unity template scenes for a Custom Bike and a Custom Car [**here**](https://drive.google.com/drive/folders/1Ke6T4T10FMly86gZedYfcR0-j0TuCkG7?usp=sharing).  
I can provide templates for other vehicles if needed, just ask me on the [**forum thread**](https://7daystodie.com/forums/showthread.php?87828-Custom-Vehicles-by-Manux-SDX).  

**IMPORTANT:** Please check the [**Terms of Use**](#terms-of-use) section, especially if you want to include this mod and it's 3D assets in another mod that you will distribute. Some of the vehicles were built from purchased 3D assets, and are under licensing terms.

Special Thanks to **DUST2DEATH** for making the ball roll on this one.  
See the complete ***Special Thanks*** section [**here**](#special-thanks).  

## Vids
### Bike, Quad, and Car
| [![driveable cars](http://img.youtube.com/vi/jd1xWsgqwCg/0.jpg)](https://www.youtube.com/watch?v=jd1xWsgqwCg "Custom Driveable Cars") | [![all terrain vehicles](http://img.youtube.com/vi/au5lZz8cKmQ/0.jpg)](https://www.youtube.com/watch?v=au5lZz8cKmQ "All-Terrain Vehicles") |  
|:---:|:---:|
|Custom Driveable Cars|All-Terrain Vehicles|  

### The Beast
[![LoaderA](http://img.youtube.com/vi/MXkOzT_1-nM/0.jpg)](https://youtu.be/MXkOzT_1-nM "Custom Loader that destroys everything on its path") | [![LoaderB](http://img.youtube.com/vi/OehnLqXRZIU/0.jpg)](https://youtu.be/OehnLqXRZIU "Custom Loader vehicle: a horde killer") | [![LoaderC](http://img.youtube.com/vi/05JCymS6XHI/0.jpg)](https://youtu.be/05JCymS6XHI "The Beast now harvests what it destroys") | [![LoaderD](http://img.youtube.com/vi/tAwpDKaP1w0/0.jpg)](https://youtu.be/tAwpDKaP1w0 "Sneak peek of new destruction and underwater features") |  
|:---:|:---:|:---:|:---:|  
|Custom Loader that destroys everything on its path|Custom Loader vehicle: a horde killer|The Beast now harvests what it destroys| Sneak peek of new destruction and underwater features |  

### Flying
[![HelicoA](http://img.youtube.com/vi/25foBmCLDSE/0.jpg)](https://youtu.be/25foBmCLDSE "A little surprise to cheer your Monday up!") | [![HelicoB](http://img.youtube.com/vi/JhAJ4osfxDE/0.jpg)](https://youtu.be/JhAJ4osfxDE "Monday's surprise part 2") |
|:---:|:---:|  
|A little surprise to cheer your Monday up!|Monday's surprise part 2|  

## Installation  
All my mods are built for being compiled and deployed with [**SDX Launcher version 0.72c**](https://github.com/SphereII/SDXWorkshop/blob/master/SDX0.7.2c.zip).  
If you don't know what SDX is, go [**here**](https://7daystodie.com/forums/showthread.php?72888-7D2D-SDX-Tutorials-and-Modding-Kit), and make sure you do the tutorials to know how to create an SDX mods build environment.  
### Updating the mod
Because this mod is currently under construction, you should always delete the old version of the mod before copying the new one. Some files are sometimes deleted or renamed in a new update, and it would create errors or issues if you don't do that.

## Dependencies
This mod has dependencies on [**Hal's DLL Fixes**](https://github.com/7D2DSDX/Mods/tree/master/HalDllUpdates) mod.  
Make sure you also deploy that mod for this one to work.  
The SDX Launcher shouldn't let you build if you don't have it or don't have it enabled.   

## Multiplayer
The mod is not really functionnal for multi-player currently. There is lots of animation update issues, and other bugs.  
I will try to fix those issues in the future, but I'm not sure when and how much work it will require.  

## Vehicle Controls
All Vehicles use the regular Keyboard Controls of the MiniBike. Some of them have additional Controls, see lists below.
### All Vehicles
All vehicles now have additionnal controls for the camera and weapons. Vehicle Weapons and Ammo can be different per vehicle, all definable in xml. Custom parts can be defined for the weapons.
- **Mouse Scroll-Wheel**: Zoom in-out in 3rd person view
- **Home**: Toggle between 3rd person and 1st person view
- **Left Mouse Button**: Shoot bullets from machine gun
- **Right Mouse Button**: Shoot Explosives (Grenades, Missiles, Tank Shells)

### The Beast
The Beast's bucket's height determines how high/low objects can be destroyed and harvested. The bucket can be moved up/down, and rotated up/down, but the rotation is mainly for aesthetics, only the height really determines what you destroy.
- **UpArrow**: Move the Bucket Up
- **DownArrow**: Move the Bucket Down
- **LeftArrow**: Rotate the Bucket Down (Outward)
- **RightArrow**: Rotate the Bucket Up (Inward)  

### Helicopter
- **LeftShift**: Lift/Increase main rotor speed
- **Space**: Down/Decrease main rotor speed
- **W**: Move/Tilt Forward
- **S**: Move/Tilt Back
- **A**: Turn/Tilt Left
- **D**: Turn/Tilt Right
- **LeftArrow**: Rotate Left
- **LeftArrow**: Rotate Right
- **Backspace**: Start/Stop Music  (same music as in the Helicopter Vid above)

## Custom Vehicle C# classes  
### EntityCustomBike
To make Custom Bikes (2 Wheels).  
This is the parent class of all other Custom Vehicle classes. It's the main class that enables the abillity to control different aspects of the vehicle through new XML properties.  
XML Example:
```XML
<entity_class name="hellGoatBike">
        <property name="Class" value="EntityCustomBike, Mods" />
        ...
</entity_class>
```
### EntityCustomCar
To make Custom Cars/Trucks/Quads (4 wheels).  
Making Custom Cars is more complex than making Custom Bikes, it requires more rigging know-how. Tofunction, it requires additionnal bones and a different hierarchy than the Bikes.
XML Example:
```XML
<entity_class name="cicadaCar">
        <property name="Class" value="EntityCustomCar, Mods" />
        ...
</entity_class>
```
### EntityCustomLoader
This is the new kid on the block and is still experimental. The code will most likely change a lot in the near future. But the base is there.  
This one is even more complex than the Custom Cars. It requires more advanced rigging know-how.  
It currently supports additionnal XML properties to control [**destruction/harvesting**](#only-on-loader-for-now) of the vehicle. It can destroy and harvest almost anything, all controllable via XML.  
It also kills zombies and other creatures when you drive over them.  
XML Example:
```XML
<entity_class name="loader">
        <property name="Class" value="EntityCustomLoader, Mods" />
        ...
</entity_class>
```
### EntityCustomHelicopter
Yes, we now have a class for Helicopters! Still very experimental and currently harcoded for this Helicopter's Rig. But I will make it more flexible for any types of helicopter soon...  
XML Example:
```XML
<entity_class name="helicopter">
        <property name="Class" value="EntityCustomHelicopter, Mods" />
        ...
</entity_class>
```

### ItemActionSpawnCustomVehicle
This is class is there to be able to spawn a custom vehicle from the custom Chassis item of the vehicle.  
The class is common to all vehicles, the vehicle to spawn is defined through the ***VehicleToSpawn*** XML property.  
For example:  
```XML
<item id="" name="hellGoatBikeChassis">
    <property name="Extends" value="robustBikeChassis"/>
    <property name="Meshfile" value="#HellGoatBike?HellGoatBikeChassisPrefab" />
    <property class="Action1">
        <property name="Class" value="SpawnCustomVehicle, Mods" />
        <property name="VehicleToSpawn" value="hellGoatBike"/>
    </property>
</item>
```

## Vehicles entity_class new XML properties
New XML properties are supported to control different apsects of your custom vehicles.  
You have to add these in your vehicle's entity_class.  
### Common to all vehicles
#### Camera and Player controls
```XML
<property name="CameraOffset" value="0, 2, -8" />
```  
To control how far the camera is when driving the vehicle
```XML
<property name="3rdPersonModelVisible" value="false" />
```  
Is the 3rd person player visible on the vehicle.  
```XML
<property name="PlayerPositionOffset" value="0, 0, 0.15" />
<property name="PlayerRotationOffset" value="15, 0, 0" />
```  
3rd person player position and rotation offsets on the vehicle. Rotation also moves the player arround, so you need to play with values to achieve what you want.  

#### CharacterController (vehicle movement and collider)
```XML
<property name="ColliderCenter" value="0, 2.07, -0.01" />
<property name="ColliderRadius" value="2" />
<property name="ColliderHeight" value="4.1" />
```  
A vehicle in 7d2d moves arround using a Unity [**CharacterController**](https://docs.unity3d.com/530/Documentation/ScriptReference/CharacterController.html) component. [Unity Scripting documentation](https://docs.unity3d.com/530/Documentation/Manual/class-CharacterController.html).  
(_The Helicopter is an exception, it has it's own custom controller to move arround._)

The above XML properties let you change the values of the public properties that exist on the CharacterController component of your custom vehicle.  
If you add a CharacterController component to an object in Unity, you will see properties with similar names in the Inspector.  
To know what values to set for the ***ColliderCenter, ColliderRadius, and ColliderHeight***, you can simply add a CharacterController component to your custom vehicle's prefab root in Unity, and modify those values until it best fits the volume of your vehicle.  
We are sadly stuck with the built-in capsule collider of the CharacterController component at this point, since this is what TFP uses for drivable vehicles. A Capsule collider is limited in how well you can adjust it to the extents of your vehicle, just fit it as best as you can.  
**Note:** Make sure to remove that CharacterController component from you prefab before exporting, to not cause undesired effects in the game.  
The best is to add it to another object if you want to keep it in your Unity scene. Just make sure that object in not in you prefab hierarchy and that it has the same transform position and rotation as your prefab root when you want to tweak it for changing the XML values.

#### All-terrain vehicles settings
```XML
<property name="ColliderSkinWidth" value="0.0001" />
<property name="ControllerSlopeLimit" value="90" />
<property name="ControllerStepOffset" value="1" />
```  
The above are for making all-terrain vehicles that can climb objects.  

***ControllerSlopeLimit*** is by default at **45** in Unity. Set it to **90** to be able to climb steep terrain slopes. I tried smaller values, but only 90 or greater seemed to work.  

***ControllerStepOffset***: *from Unity docs: "The character will step up a stair only if it is closer to the ground than the indicated value. This should not be greater than the Character Controller’s height or it will generate an error.*"  
From what I understand, a step of **1.0** lets you climb over a single block. If you have a taller vehicle like the Loader, you can set it higher to be able to climb over 2-3-4 blocks. But never set it higher than the Character Controller’s height (***ColliderHeight*** XML property).  

***ColliderSkinWidth*** Can be left to the default value that shows in Unity: **0.08**.  
But putting the minimum value of **0.0001** can help it climb better.  

#### Vehicles UI activation volume
```XML
<property name="VehicleActivationCenter" value="0, 2, -0.05" />
<property name="VehicleActivationSize" value="3, 4, 6" />
```  
There is another collider(Box collider) present on vehicles. It does not colide with the environment, it's only there to define the volume for the activation UI of the vechicles.  
Just like for the CharacterController above, you can make a dummy Box Collider in your Unity scene to know what values to put in there.  

### Only on Loader for now
```XML
<property name="EntityDamage" value="1000" />
<property name="BlockDamage" value="10000" />
<property name="DestructionRadius" value="3" />
<property name="DestructionHeight" value="3" />
<property name="DestructionHarvestBonus" value="1.4" />
<property name="DestroyBlocks" value="grass,plant,cactus,shrubOrBush,tree,rock,bigBoulder,rareOres,tire,fence,buildings,debris,poleOrPillar,car,furniture,devices,curb,snow,trap,terrain,lootCtn" />
<property name="HarvestBlocks" value="plant,cactus,shrubOrBush,tree,rock,bigBoulder,rareOres,tire,fence,buildings,debris,poleOrPillar,bench,car,furniture,devices,curb,snow,trap,terrain,lootCtn" />
<property name="HarvestToVehicleInventory" value="true" />
```  
The Loader currently supports additionnal XML properties to control the destruction, and harvesting. (Yes, it can harvest what it destroys!).  
But I will most likely make this evolve a lot and transfer it to the EntityCustomBike class in order for all vehicles to be able to damage the environment and the Zombies, or other living humans, animals, and creatures.  

## Custom Vehicle Parts
You don't need this mod to make your own custom parts for vehicles, it can be done through xml.  
But if you do that and rename vehicle parts slots, you will end up with many different bugs. TFP has code that hardcodes the parts slots names, so if you change the name of the vehicle slots, it will create issues.  

But in the latest version of this mod I patched TFP's code, and added a new way of defining custom vehicle parts that fully work. This means that you can now make custom parts for all you vehicles, insurring that users can only use the parts meant for each vehicle. The custom parts can also change things like how fast your vehicle goes (engine), how robust it is, etc...

All the vehicle's custom parts in this mod now use this new system. Check the xmls to see examples.  
Each vehicle always has a custom chassis item for items.xml, to be able to spawn that specific type of vehicle.  
I made the icons show the whole vehicle so you know what you are spawning:  

| ![img](Icons/roadHogChassis.png) | ![img](Icons/hellGoatBikeChassis.png) | ![img](Icons/quadChassis.png) | ![img](Icons/cicadaCarChassis.png) | ![img](Icons/loaderChassis.png) | ![img](Icons/helicopterChassis.png) |
|:---:|:---:|:---:|:---:|:---:|:---:|  

### 2 New weapon parts slots
In the last version I added 2 new parts slots to be able to have 2 weapons per vehicle: a machine gun and an explosive launcher.  
You can make your own custom vehicle parts to populate those new slots, or you can use the ones I already made. See those 2 new files: **vehicleWeapons.xml** and **vehicleAmmo.xml**.

#### Examples of vehicle UIs with those 2 new slots:
| ![male](https://manux32.github.io/7dtd_miscImages/RoadHog_partsSlots.jpg) | ![female](https://manux32.github.io/7dtd_miscImages/Helicopter_partsSlots.jpg) |  
|:---:|:---:|  
| Dust2Death's RoadHog | Helicopter |  

### How to define custom parts
- Always keep the regular vehicle slot names identical to the minibike (***slot_type*** on vehicle parts and ***VehicleSlotType*** on part items).
- Add a new xml property on a vehicle part to make it a custom part and set it's value to the name of the custom item.
_Example:_
```XML
<property name="custom_slot_type" value="helicopterMissileLauncher" />
```  
- Also add this new property to the part item. This will prevent using that part in regular vehicle slots.  
```XML
<property name="IsVehicleCustomPart" value="true" />
```  

### Professional High-Powered Bike Parts
Professional High-Powered versions of the minibike parts, in order to build High-Powered Bikes or other Vehicles.  
I initially wanted a faster bike especially for Random Gen maps where cities are pretty far from each other. I did these parts before making this mod, before knowing how to make fully custom vehicles. I was then just using them to have a HP minibike.  

Only the Hell Goat bike currently uses the HP Bike parts. The new Loader also has a couple of custom parts, it's engine xml class extends from the bigEngine class below.  
Based on those examples, you can use them for other vehicles or make new versions of some of the parts for different types of vehicles.
I did not yet add any XML progression gates for being able to craft these items.   

#### ![bigEngine](Icons/bigEngine.png) Big Engine
A big, robust, and powerful engine for your bigger vehicles. It consumes a bit more gas but features a bigger gas tank. You can accellerate faster and reach very high speeds, but be careful, it also jumps way higher!
#### ![robustBikeChassis](Icons/robustBikeChassis.png) Robust Bike Chassis (Power suspension)
A robust bike chassis equipped with power suspension. You almost don't get hurt when jumping too high. 
#### ![proBikeHandlebars](Icons/proBikeHandlebars.png) Professional Bike Handlebars
Have better control of your driving with these professional bike handlebars. They will also degrade slower than regular ones.  
#### ![proBikeWheels](Icons/proBikeWheels.png) High-Performance Bike Wheels
Have better traction and reduced drag with these beautiful High Performance tires. They will also degrade slower than regular ones.  
#### ![proBikeSeat](Icons/proBikeSeat.png) Professional Bike Seat
A beautiful deluxe comfy seat that drains less stamina when the bike is damaged. The seat is also more robust and will degrade slower.

### Loader Parts
I did not yet add any recipes to craft these items, grab them from the creative menu.  

#### ![loaderHandlebars](Icons/loaderHandlebars.png) Loader Handlebars
I did this one to be able to have the Loader steering wheel turn much slower than Bikes.  
#### ![loaderEngine](Icons/loaderEngine.png) Loader engine
I did this one mainly to control the speed at which the loader moves, the gas consumption, the size of the gas tank, but also for things like the DegradationMax and VehicleNoise.  

### Helicopter parts
The Helicopter has a built-in storage, it is always present, no vehicle part is needed. Same goes for the Cicada Car.  
#### ![heliEngine](Icons/helicopterEngine.png) Helicopter Engine
I mainly made this to be able to control gas consumption. But it also makes a lot of sense to have a special engine for an helicopter.
#### ![heliMissileLauncher](Icons/helicopterMissileLauncher.png) Helicopter Missile Launcher
This part is needed to be able to fire missiles.  
You need this type of Ammo in your backpack: ![heliMissile](Icons/helicopterMissile.png) **Helicopter Missiles**  
#### ![heliGun](Icons/helicopterGun.png) Helicopter Gun
This part is needed to be able to fire gun ammo.  
You need this type of ammo in your backpack: ![heliGunAmmo](Icons/helicopterBullet.png) **Helicopter Bullet** 

## Terms of use
Some of the 3D Assets used to make the vehicles in this mod were purchased or downloaded for free, from various sites. Different licensing terms apply to the different Assets, see the list below.  
I am not yet fully certain of how these licensing terms apply to what we do, but if your goal is to make a mod that includes my mod and those assets in it, it would be safer if you also purchased those assets.  
I will contact Sketchfab to get clarifications on how this applies to us, modders...  

### The Beast (Loader)
- **Original 3D Asset:** [**Wheel Loader**](https://skfb.ly/6toGS)
- **Creator:** [**Renafox**](https://sketchfab.com/kryik1023)  
A very talented artist that created the original 3D Asset I used for making The Beast.  
Check-out all the other [great models](https://sketchfab.com/kryik1023) she has for sale.  
- **Asset acquisition: Sketchfab Purchase (25$)**  
- **Licensing type:** [**Sketchfab Standard**](https://sketchfab.com/licenses)  
To be safe, you need to also purchase this asset if you want to include my mod and this asset in another mod that you distribute.  

### Quad
- **Original 3D Asset:** [**ATV model practice**](https://skfb.ly/6x9oT)  
- **Creator:** [**Mark Bai**](https://sketchfab.com/bcfbox)  
A talented artist who did the very nice and cheap Sketchfab asset that I used for the Quad vehicle.  
- **Asset acquisition: Sketchfab Purchase (4$)**  
- **Licensing type:** [**Sketchfab Standard**](https://sketchfab.com/licenses)  
To be safe, you need to also purchase this asset if you want to include my mod and this asset in another mod that you distribute.  
 
### HellGoat Bike
- **Original 3D Asset:** [**Hell Motogoat**](https://skfb.ly/TCEV)  
- **Creator:** [**chervinin**](https://sketchfab.com/chervinin)  
A great artist who did this amazing asset that I am using for the Hell Goat Bike vehicle. 
- **Asset acquisition: Free Sketchfab Download**  
- **Licensing type:** [**Creative Commons Attribution 4.0**](https://creativecommons.org/licenses/by/4.0/)  
I made the changes listed below to the Asset in order to be able to integrate it in this mod for the 7 days to die game.  
This mod is public and free, the derived asset is not used in any commercial way.  
- Polygon reduction on all meshes.
- Textures reduction from 2048x2048 to 512x512
- Combine the textures maps to be compatible with the Unity Shaders (Glossiness maps as the alpha channel of Specular maps, Opacity maps as the alpha channel of Diffuse maps)
- Skinning of the meshes on a simple bone structure to be able to animate it in the game.
- Addition of lightbulbs in the eyes of the Goat skull, for when the lights of the vehicle are turned on. Looks awesome!  

### Helicopter
#### Original Helicopter 3D Model and Movement Controller code
- **Original Assets:** [**Base Helicopter Controller**](https://assetstore.unity.com/packages/tools/physics/base-helicopter-controller-40107)  
I used most of the Helicopter 3D Model to make the Helicopter vehicle, and also used the Controllers code base to make the Helicopter move.  
- **Creator:** [**Sun Cube Studio**](https://www.facebook.com/suncubestudio/)  
A talented person/group who did the wonderful and free Unity Asset Store Base Helicopter Controller system.  
- **Asset acquisition: Unity3D Asset Store Free Download**  
- **Licensing type:** [**Asset Store Terms of Service and EULA**](https://unity3d.com/legal/as_terms)  

#### Helicopter cockpit interior  
- **Original 3D Asset:** [**Military Helicopter**](https://assetstore.unity.com/packages/3d/vehicles/air/military-helicopter-3922)  
I only used the interior cockpit of the 3D Asset to put it in the other Helicopter 3D model above, because that one didn't have any interior cockpit.
- **Creator:** [**Duane's Mind**](https://assetstore.unity.com/publishers/678)  
- **Asset acquisition: Unity3D Asset Store Free Download**  
- **Licensing type:** [**Asset Store Terms of Service and EULA**](https://unity3d.com/legal/as_terms)  

### Cicada Car
- **Original 3D Asset:** [**Retro Cartoon Cars - Cicada**](https://assetstore.unity.com/packages/3d/vehicles/land/retro-cartoon-cars-cicada-96158)  
This asset has been used to make my fist custom car vehicle. A bit too cartoony for the style of the game, but I kept it because I like it a lot, it's like the minibike of cars. And the player looks so funny when driving it.  
- **Creator:** [**Retro Valorem**](https://assetstore.unity.com/publishers/22495)  
A great artist who did this cute, and free Unity Asset Store 3D Asset.  
- **Asset acquisition: Unity3D Asset Store Free Download**  
- **Licensing type:** [**Asset Store Terms of Service and EULA**](https://unity3d.com/legal/as_terms)  


## Special Thanks

### To the 3D Assets creators 
To all the creators of the 3D Assets I used to make the vehicles. See the list in the **Terms of Use** section above.

### Dust2Death 
For doing all the ground work to find how to make a custom bike using the game unused Road Hog asset.
He's the one that originally initiated the forum thread we currently use for this mod. When I saw what he did with the RoadHog, it picked my interest. We joined force and the initiative evolved to this Vehicles mod: [**Custom Vehicles by Manux**](https://7daystodie.com/forums/showthread.php?87828-Custom-Vehicles-by-Manux-SDX)  

### TormentedEmu
For making the Horse vehicle of the Medieval Mod, which has been a great code reference for me when building this mod. And also for helping demistify some of the more obscur parts of coding something like this.
And thanks also for her great [**MinibikeImpact**](https://github.com/TormentedEmu/7DTD-SDX-Mods/tree/master/MinibikeImpact) mod that I am using in the first video above to run over zombies with the Cicada car.

### Mumpfy
A very talented visual artist that it also a 7d2d modder. He retextured some of the coolest Vehicles to make them fit better in the mood of the game. They look awesome!
He retextured the following vehicles so far: 
- Dust2Death's RoadHog
- The Beast
- Helicopter

### Three8
For adding underwater capabillities to all vehicles. He is a top notch modder doing stuff like a fully working Elevator.

### JaxTeller718  
For doing great sounds for Dust2Death's Road Hog. I am also using those sounds on the Hell Goat Bike and the Loader.
