﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using UnityEngine;


public abstract class EntityCustomVehicle : EntityMinibike
{
    public EntityPlayerLocal player;
    public LocalPlayerUI uiforPlayer;
    public XUiM_PlayerInventory playerInventory;
    public XUiC_VehicleContainer xuiC_VehicleContainer;
    public bool hasDriver = false;
    public CharacterController charCtrl = null;
    public Transform playerSpine1Bone = null;

    public VehicleCamera vehicleCam = null;
    public Vector3 cameraOffset = new Vector3(0f, -0.5f, -2.75f); // minibike default = (0.4f, -0.5f, -2.75f)
    public bool hasCamOffset;
    public bool thirdPersonModelVisible = true;
    public Vector3 playerOffsetPos;
    public Vector3 playerOffsetRot;
    public bool hasPlayerOffsetPos;
    public bool hasPlayerOffsetRot;

    public Vector3 colliderCenter;
    public float colliderRadius;
    public float colliderHeight;
    public float colliderSkinWidth;
    public float controllerSlopeLimit;
    public float controllerStepOffset;
    public bool hasColliderCenter;
    public bool hasColliderRadius;
    public bool hasColliderHeight;
    public bool hasControllerSlopeLimit;
    public bool hasControllerStepOffset;
    public bool hasColliderSkinWidth;

    public BoxCollider nativeBoxCollider;
    public Vector3 vehicleActivationCenter;
    public Vector3 vehicleActivationSize;
    public bool hasVehicleActivationCenter;
    public bool hasVehicleActivationSize;

    public bool controllerSettingsDone;
    public bool camAndPlayerOffsetsDone;

    public bool allBonesSet1Found;
    public bool allBonesSet2Found;

    public VehicleWeapons vehicleWeapons = null;
    public bool autoGeneratedWeaponLaunchers = false;
    public Transform missileLauncher = null;
    public Transform gunLauncher = null;

    public Transform missileLauncher1 = null;
    public Transform gunLauncher1 = null;

    public Transform missileLauncher2 = null;
    public Transform gunLauncher2 = null;

    public bool hasBuiltInStorage = false;

    //public string vehicleXuiName = "vehicle";

    // Three8's WaterCraft
    bool isAirtight;
    bool isWaterCraft;

    public bool IsWaterCraft()
    {
        return isWaterCraft;
    }

    public bool IsAirtight()
    {
        return isAirtight;
    }

    static bool showDebugLog = false;

    public static void DebugMsg(string msg)
    {
        if (showDebugLog)
        {
            Debug.Log(msg);
        }
    }


    public override void Init(int _entityClass)
    {
        player = GameManager.Instance.World.GetLocalPlayer() as EntityPlayerLocal;
        uiforPlayer = LocalPlayerUI.GetUIForPlayer(player);
        DebugMsg("initial player.vp_FPCamera.Position3rdPersonOffset = " + player.vp_FPCamera.Position3rdPersonOffset.ToString("0.0000"));

        base.Init(_entityClass);

        nativeBoxCollider = this.nativeCollider as BoxCollider;
    }

    #region Init Settings

    public override void CopyPropertiesFromEntityClass()
    {
        base.CopyPropertiesFromEntityClass();

        EntityClass entityClass = EntityClass.list[this.entityClass];
        // Cam offset from xml
        if (entityClass.Properties.Values.ContainsKey("CameraOffset"))
        {
            Vector3 camOffset;
            if (CustomVehiclesUtils.StringVectorToVector3(entityClass.Properties.Values["CameraOffset"], out camOffset))
            {
                cameraOffset = camOffset;
                hasCamOffset = true;
            }
        }

        // Player settings from xml
        if (entityClass.Properties.Values.ContainsKey("3rdPersonModelVisible"))
        {
            bool thirdPVisible;
            if(bool.TryParse(entityClass.Properties.Values["3rdPersonModelVisible"], out thirdPVisible));
            {
                thirdPersonModelVisible = thirdPVisible;
            }

        }
        if (entityClass.Properties.Values.ContainsKey("PlayerPositionOffset"))
        {
            if (CustomVehiclesUtils.StringVectorToVector3(entityClass.Properties.Values["PlayerPositionOffset"], out playerOffsetPos))
            {
                hasPlayerOffsetPos = true;
            }
        }
        if (entityClass.Properties.Values.ContainsKey("PlayerRotationOffset"))
        {
            if (CustomVehiclesUtils.StringVectorToVector3(entityClass.Properties.Values["PlayerRotationOffset"], out playerOffsetRot))
            {
                hasPlayerOffsetRot = true;
            }
        }

        // Vehicle Character controller collider settings from xml
        this.SetEntityName(EntityClass.list[this.entityClass].entityClassName);

        if (entityClass.Properties.Values.ContainsKey("ColliderCenter"))
        {
            if (CustomVehiclesUtils.StringVectorToVector3(entityClass.Properties.Values["ColliderCenter"], out colliderCenter))
            {
                hasColliderCenter = true;
            }
        }
        if (entityClass.Properties.Values.ContainsKey("ColliderRadius"))
        {
            if (float.TryParse(entityClass.Properties.Values["ColliderRadius"], out colliderRadius))
            {
                hasColliderRadius = true;
            }
        }
        if (entityClass.Properties.Values.ContainsKey("ColliderHeight"))
        {
            if (float.TryParse(entityClass.Properties.Values["ColliderHeight"], out colliderHeight))
            {
                hasColliderHeight = true;
            }
        }
        if (entityClass.Properties.Values.ContainsKey("ColliderSkinWidth"))
        {
            if (float.TryParse(entityClass.Properties.Values["ColliderSkinWidth"], out colliderSkinWidth))
            {
                hasColliderSkinWidth = true;
            }
        }
        if (entityClass.Properties.Values.ContainsKey("ControllerSlopeLimit"))
        {
            if (float.TryParse(entityClass.Properties.Values["ControllerSlopeLimit"], out controllerSlopeLimit))
            {
                hasControllerSlopeLimit = true;
            }
        }
        if (entityClass.Properties.Values.ContainsKey("ControllerStepOffset"))
        {
            if (float.TryParse(entityClass.Properties.Values["ControllerStepOffset"], out controllerStepOffset))
            {
                hasControllerStepOffset = true;
            }
        }

        // Vehicle activation area from xml
        if (entityClass.Properties.Values.ContainsKey("VehicleActivationCenter"))
        {
            if (CustomVehiclesUtils.StringVectorToVector3(entityClass.Properties.Values["VehicleActivationCenter"], out vehicleActivationCenter))
            {
                hasVehicleActivationCenter = true;
            }
        }
        if (entityClass.Properties.Values.ContainsKey("VehicleActivationSize"))
        {
            if (CustomVehiclesUtils.StringVectorToVector3(entityClass.Properties.Values["VehicleActivationSize"], out vehicleActivationSize))
            {
                hasVehicleActivationSize = true;
            }
        }

        // Three8's WaterCraft settings from xml
        // Add this to xml to turn on underwater use <property name="WaterCraft" value="true" />
        if (entityClass.Properties.Values.ContainsKey("WaterCraft"))
        {
            bool.TryParse(entityClass.Properties.Values["WaterCraft"], out isWaterCraft);
        }
        // Add this to xml so you dont drown when underwater <property name="Airtight" value="true" />
        if (entityClass.Properties.Values.ContainsKey("Airtight"))
        {
            bool.TryParse(entityClass.Properties.Values["Airtight"], out isAirtight);
        }

        // Test changing Storage size
        /*if (entityClass.Properties.Values.ContainsKey("vehicleXuiName"))
        {
            //entityClass.Properties.Values["vehicleXuiName"];
            //GUIWindowManager windowManager = uiforPlayer.windowManager;
            //XUiC_VehicleWindowGroup.ID = entityClass.Properties.Values["vehicleXuiName"];
            //XUiC_VehicleWindowGroup xuic_vehicleWindowGroup = ((XUiC_VehicleWindowGroup)((XUiWindowGroup)windowManager.GetWindow(entityClass.Properties.Values["vehicleXuiName"])).Controller);
            //xuic_vehicleWindowGroup.CurrentVehicleEntity = this;
            //return (XUiC_VehicleContainer)uiforPlayer.xui.FindWindowGroupByName(XUiC_VehicleWindowGroup.ID).GetChildByType<XUiC_VehicleContainer>();
            vehicleXuiName = entityClass.Properties.Values["vehicleXuiName"];
        }*/

        SetCharCtrlAndBoxCollFromXml();
    }


    public CharacterController GetCharacterController()
    {
        string dbgMsg = (this.EntityName + " (" + this.GetType().ToString() + "):\nGet CharacterController:\n");
        CharacterController charCtrl = this.m_characterController;
        if (charCtrl == null)
        {
            dbgMsg += ("this.m_characterController is NULL. Trying to find it through hierarchy colliders.\n");
            Collider[] colls = this.transform.root.GetComponentsInChildren<Collider>();
            foreach (Collider coll in colls)
            {
                dbgMsg += ("Found " + coll.gameObject.name + " collider: " + coll.GetType().ToString() + "\n");
                if (coll.gameObject.name == "Physics")
                {
                    charCtrl = coll as CharacterController;
                    dbgMsg += ("\tFound CharacterController = " + charCtrl.ToString() + "|" + charCtrl.GetInstanceID().ToString() + "\n");
                    if (charCtrl != null)
                    {
                        dbgMsg += ("\tcharCtrl = " + charCtrl.ToString() + "|" + charCtrl.GetInstanceID().ToString() + "\n");
                    }
                    if (this.nativeCollider != null)
                    {
                        dbgMsg += ("\tthis.nativeCollider = " + this.nativeCollider.ToString() + "|" + this.nativeCollider.GetType().ToString() + "|" + this.nativeCollider.GetInstanceID().ToString() + "\n");
                        if(nativeBoxCollider == null)
                        {
                            this.nativeBoxCollider = this.nativeCollider as BoxCollider;
                        }
                    }
                }
            }
        }

        return charCtrl;
    }

    public void SetCharCtrlAndBoxCollFromXml()
    {
        string dbgMsg = (this.EntityName + " (" + this.GetType().ToString() + "):\nSet CharacterController settings from xml:\n");
        charCtrl = GetCharacterController();
        if(charCtrl == null)
        {
            DebugMsg("CharacterController is NULL");
            return;
        }

        if (hasColliderCenter)
        {
            // Inverse x and z sign, because the char controller seems to have it's root inversed relative to the vehicle.
            colliderCenter.x = -colliderCenter.x;
            colliderCenter.z = -colliderCenter.z;
            dbgMsg += ("\tnew colliderCenter = " + colliderCenter.ToString("0.000") + " (was: " + charCtrl.center.ToString("0.000") + ")\n");
            charCtrl.center = colliderCenter;

        }
        if (hasColliderRadius)
        {
            dbgMsg += ("\tnew radius = " + colliderRadius.ToString("0.000") + " (was: " + charCtrl.radius.ToString("0.000") + ")\n");
            charCtrl.radius = colliderRadius;
        }
        if (hasColliderHeight)
        {
            dbgMsg += ("\tnew height = " + colliderHeight.ToString("0.000") + " (was: " + charCtrl.height.ToString("0.000") + ")\n");
            charCtrl.height = colliderHeight;
        }
        if (hasColliderSkinWidth)
        {
            dbgMsg += ("\tnew skinWidth = " + colliderSkinWidth.ToString("0.0000") + " (was: " + charCtrl.skinWidth.ToString("0.000") + ")\n");
            charCtrl.skinWidth = colliderSkinWidth;
        }
        if (hasControllerSlopeLimit)
        {
            dbgMsg += ("\tnew slopeLimit = " + controllerSlopeLimit.ToString("0.000") + " (was: " + charCtrl.slopeLimit.ToString("0.000") + ")\n");
            charCtrl.slopeLimit = controllerSlopeLimit;
        }
        if (hasControllerStepOffset)
        {
            dbgMsg += ("\tnew stepOffset = " + controllerStepOffset.ToString("0.000") + " (was: " + charCtrl.stepOffset.ToString("0.000") + ")\n");
            charCtrl.stepOffset = controllerStepOffset;
        }

        // The Box Collider present on vehicles seems to only be for what area of the vehicle will show the Vehicle Activate menu (which is still useful)
        if (nativeBoxCollider == null)
        {
            dbgMsg += ("Box Collider for Vehicle Activation Area could not be found.\n");
        }
        else
        {
            if (hasVehicleActivationCenter)
            {
                dbgMsg += ("\tnew vehicleActivationCenter = " + vehicleActivationCenter.ToString("0.000") + " (was: " + nativeBoxCollider.center.ToString("0.000") + ")\n");
                nativeBoxCollider.center = vehicleActivationCenter;
            }
            if (hasVehicleActivationSize)
            {
                dbgMsg += ("\tnew vehicleActivationSize = " + vehicleActivationSize.ToString("0.000") + " (was: " + nativeBoxCollider.size.ToString("0.000") + ")\n");
                nativeBoxCollider.size = vehicleActivationSize;
            }
        }

        DebugMsg(dbgMsg);
        controllerSettingsDone = true;
    }


    public static Transform GetRootTransform(Transform fromTransform, string stopAtString)
    {
        if (fromTransform.parent != null)
        {
            DebugMsg("GetRootTransform parent = " + fromTransform.gameObject.name + " | " + fromTransform.gameObject.GetInstanceID().ToString());
            if (stopAtString != null && fromTransform.gameObject.name.ToLower().Contains(stopAtString))
                return fromTransform;

            return GetRootTransform(fromTransform.parent, stopAtString);
        }
        return fromTransform;
    }

    public virtual void GetVehicleBones()
    {
        List<Transform> childrenList = new List<Transform>();
        List<int> childrenInstanceIds = new List<int>();
        childrenList.Add(this.transform);
        childrenInstanceIds.Add(this.transform.GetInstanceID());
        CustomVehiclesUtils.GetAllChildTransforms(this.transform, ref childrenList, ref childrenInstanceIds);

        foreach (Transform child in childrenList)
        {
            switch (child.name)
            {
                case "missileLauncher":
                    if (missileLauncher1 == null)
                        missileLauncher1 = child;
                    else
                        missileLauncher2 = child;
                    break;
                case "gunLauncher":
                    if (gunLauncher1 == null)
                        gunLauncher1 = child;
                    else
                        gunLauncher2 = child;
                    break;
            }
        }

        if (missileLauncher1 == null || gunLauncher1 == null)
        {
            //Debug.LogError(this.ToString() + " : Some bones could not be found for set 1. Custom Vehicle will not be fully functionnal.");
        }
        else
        {
            allBonesSet1Found = true;
            DebugMsg(this.ToString() + " : All bones set 1 found.");
        }

        if (missileLauncher2 == null || gunLauncher2 == null)
        {
            //DebugMsg(this.ToString() + " : Some bones could not be found for set 2. (this is harmless)");
        }
        else
        {
            allBonesSet2Found = true;
            DebugMsg(this.ToString() + " : All bones set 2 found.");
        }

        if (missileLauncher2 != null)
            missileLauncher = missileLauncher2;
        else
        {
            if (missileLauncher1 != null)
                missileLauncher = missileLauncher1;
        }

        if (gunLauncher2 != null)
            gunLauncher = gunLauncher2;
        else
        {
            if (gunLauncher1 != null)
                gunLauncher = gunLauncher1;
        }


        if (missileLauncher == null || gunLauncher == null)
        {
            if (!autoGeneratedWeaponLaunchers)
            {
                DebugMsg("Generating weapon launcher bones");
                if (gunLauncher == null)
                {
                    gunLauncher = new GameObject("gunLauncher").transform;
                    gunLauncher.SetParent(this.transform);
                    gunLauncher.transform.localPosition = new Vector3(0, 1, 1.5f);
                    gunLauncher.transform.localRotation = Quaternion.identity;
                }
                if (missileLauncher == null)
                {
                    missileLauncher = new GameObject("missileLauncher").transform;
                    missileLauncher.SetParent(this.transform);
                    missileLauncher.transform.localPosition = new Vector3(0, 1, 1.5f);
                    missileLauncher.transform.localRotation = Quaternion.identity;
                }

                autoGeneratedWeaponLaunchers = true;
            }
            allBonesSet1Found = true;
        }
    }

    public void GetPlayerSpine1Bone()
    {
        GameObject playerRoot = GetRootTransform(player.transform, "player").gameObject;
        Component[] comps = playerRoot.GetComponentsInChildren<Component>();
        foreach (Component comp in comps)
        {
            //DebugMsg("\nPlayer comp = " + comp.gameObject.name + " | " + comp.GetType());
            /*if (comp.GetType() == typeof(Animator))
            {
                playerAnimator = comp as Animator;
                playerHeadBone = playerAnimator.GetBoneTransform(HumanBodyBones.Head);
            }*/
            if (comp.transform.name == "Spine1")
            {
                playerSpine1Bone = comp.transform;
            }
        }
    }

    public virtual XUiC_VehicleContainer GetVehicleContainer()
    {
        GUIWindowManager windowManager = uiforPlayer.windowManager;
        ((XUiC_VehicleWindowGroup)((XUiWindowGroup)windowManager.GetWindow("vehicle")).Controller).CurrentVehicleEntity = this;
        return (XUiC_VehicleContainer)uiforPlayer.xui.FindWindowGroupByName(XUiC_VehicleWindowGroup.ID).GetChildByType<XUiC_VehicleContainer>();
    }

    #endregion

    protected override void Start()
    {
        base.Start();
        player = GameManager.Instance.World.GetLocalPlayer() as EntityPlayerLocal;
        InitVehicle();
    }

    public virtual void InitVehicle()
    {
        GetVehicleBones();
        GetPlayerSpine1Bone();

        if (vehicleCam == null)
        {
            vehicleCam = this.gameObject.AddComponent<VehicleCamera>();
            vehicleCam.entity = this;
        }

        if (vehicleWeapons == null)
        {
            vehicleWeapons = this.gameObject.AddComponent<VehicleWeapons>();
            vehicleWeapons.entity = this;
        }

        HasBuiltInStorage();
    }

    public virtual void OnDriverOn()
    {
        //DebugMsg(this.EntityName + " (" + this.GetType().ToString() + "): OnDriverOn()");
        //if (player != this.AttachedEntities)
        {
            player = this.AttachedEntities as EntityPlayerLocal;
            GetPlayerSpine1Bone();
            uiforPlayer = LocalPlayerUI.GetUIForPlayer(player);
            playerInventory = uiforPlayer.xui.PlayerInventory;
        }

        hasDriver = true;
        vehicleCam.newThirdPcameraOffset = cameraOffset;
        player.vp_FPCamera.Position3rdPersonOffset = cameraOffset;

        if (!vehicleCam.is3rdPersonView)
        {
            vehicleCam.ToggleFirstAnd3rdPersonView(false, true);
        }
        //DebugMsg("Game Cam parent = " + player.vp_FPCamera.transform.parent.name + " (pos = " + player.vp_FPCamera.transform.position + " | vehicle pos = " + this.position + ")");
    }

    public virtual void OnDriverOff()
    {
        hasDriver = false;
        camAndPlayerOffsetsDone = false;
    }

    public new void FixedUpdate()
    {
        base.FixedUpdate();

        if(!controllerSettingsDone)
        {
            SetCharCtrlAndBoxCollFromXml();
            return;
        }

        if (!(this.AttachedEntities is EntityPlayer))
        {
            if (hasDriver)
            {
                OnDriverOff();
            }
            return;
        }

        if(!hasDriver)
        {
            OnDriverOn();
        }

        if (!allBonesSet1Found || playerSpine1Bone == null)
        {
            InitVehicle();
            return;
        }

        if (camAndPlayerOffsetsDone)
            return;

        if (player != null)
        {
            string dbgMsg = (this.EntityName + " (" + this.GetType().ToString() + "):\nSet Vehicle Player settings from xml:\n");
            if (hasCamOffset)
            {
                dbgMsg += ("\tPosition3rdPersonOffset = " + cameraOffset.ToString("0.000") + " (was: " + player.vp_FPCamera.Position3rdPersonOffset.ToString("0.000") + ")\n");
                player.vp_FPCamera.Position3rdPersonOffset = cameraOffset;
            }

            player.emodel.SetVisible(thirdPersonModelVisible);

            if (hasPlayerOffsetPos)
            {
                dbgMsg += ("\tPlayerPositionOffset = " + playerOffsetPos.ToString("0.000") + " (was: " + player.ModelTransform.localPosition.ToString("0.000") + ")\n");
                player.ModelTransform.localPosition = playerOffsetPos;
            }
            if (hasPlayerOffsetRot)
            {
                dbgMsg += ("\tPlayerRotationOffset = " + playerOffsetRot.ToString("0.000") + " (was: " + player.ModelTransform.localEulerAngles.ToString("0.000") + ")\n");
                player.ModelTransform.localEulerAngles = playerOffsetRot;
            }

            DebugMsg(dbgMsg);
            camAndPlayerOffsetsDone = true;
        }

        // Vehicle sometimes gets stuck
        //if (this.isDriveable() && this.vehicle.GetFuelLevel() > 0 && this.vehicle.SimulationInput.bWheelSpinForward && this.vehicle.SimulationInput.velocity == Vector3.zero)
        /*if (this.isDriveable() && this.vehicle.GetFuelLevel() > 0 && this.IncomingRemoteSimulationInput.bAccelerate && this.vehicle.SimulationInput.velocity == Vector3.zero)
        {
            charCtrl.SimpleMove(new Vector3(0,2,0));
        }*/
    }


    // Three8's WaterCraft: calls only while attached - must do this or it wont work under water.
    // TO-DO: This will need to be reviewed as the current function does not do everything that the original function does...
    public new void Update()
    {
        if (!IsWaterCraft())
        {
            base.Update();
            return;
        }

        if (IsAirtight())
        {
            if (GameManager.Instance.World.IsLiquidInBounds(new Bounds(this.position + new Vector3(0f, 1.5f, 0f), Vector3.one)))
            {
                if (player != null)
                {
                    player.Stats.Debuff("cannotBreath");
                    player.Stats.Debuff("drowning");
                }
            }
        }

        if (!this.vehicle.HasAnyParts())
        {
            this.Kill();
        }
        this.vehicle.Update(Time.deltaTime);
    }


    public override bool isDriveable()
    {
        if (IsWaterCraft())
            return this.vehicle.IsDriveable();

        return this.vehicle.IsDriveable() && !this.world.IsLiquidInBounds(new Bounds(this.position + new Vector3(0f, 1.5f, 0f), Vector3.one));
    }


    public ItemValue GetWeaponAmmoType(string weaponSlotType)
    {
        ItemValue itemValue = ItemClass.GetItem(this.GetVehicle().GetPartProperty(weaponSlotType, "custom_slot_type"), false);
        if (itemValue.ItemClass.Properties.Values.ContainsKey("AmmoType"))
        {
            return ItemClass.GetItem(itemValue.ItemClass.Properties.Values["AmmoType"], false);
        }
        return null;
    }

    public virtual bool HasGun()
    {
        //DebugMsg("HasGun = " + (this.vehicle.GetPartItemValueByTag("vehicleGun").type != 0).ToString());
        return this.vehicle.GetPartItemValueByTag("vehicleGun").type != 0;
    }

    public virtual bool HasGunAmmo()
    {
        ItemValue itemValue = GetWeaponAmmoType("vehicleGun");
        if(itemValue != null)
        {
            ItemStack itemStack = new ItemStack(itemValue, 1);
            //DebugMsg("HasGunAmmo = " + (playerInventory.HasItem(itemStack)).ToString());
            return playerInventory.HasItem(itemStack);
        }
        return false;
    }

    public virtual bool HasExplosiveLauncher()
    {
        //DebugMsg("HasExplosiveLauncher = " + (this.vehicle.GetPartItemValueByTag("vehicleExplosiveLauncher").type != 0).ToString());
        return this.vehicle.GetPartItemValueByTag("vehicleExplosiveLauncher").type != 0;
    }

    public virtual bool HasExplosiveLauncherAmmo()
    {
        ItemValue itemValue = GetWeaponAmmoType("vehicleExplosiveLauncher");
        if (itemValue != null)
        {
            ItemStack itemStack = new ItemStack(itemValue, 1);
            //DebugMsg("HasExplosiveLauncherAmmo = " + (playerInventory.HasItem(itemStack)).ToString());
            return playerInventory.HasItem(itemStack);
        }
        return false;
    }

    public virtual bool HasFuel()
    {
        //DebugMsg("HasFuel = " + this.vehicle.GetFuelNrm().ToString("0.0000"));
        return this.vehicle.GetFuelNrm() > 0f;
    }

    public bool HasBuiltInStorage()
    {
        // Doing it here cause it fails in CopyPropertiesFromEntityClass()
        string hasBuiltInStrgString = this.GetVehicle().GetPartProperty("storage", "is_built-in_storage");
        DebugMsg("Reading storage hasBuiltInStrgString = " + hasBuiltInStrgString);
        if (hasBuiltInStrgString != string.Empty)
        {
            bool hasBuiltInStrg;
            if (bool.TryParse(hasBuiltInStrgString, out hasBuiltInStrg))
            {
                if (hasBuiltInStrg)
                    hasBuiltInStorage = true;
            }
        }
        return hasBuiltInStorage;
    }

    public override void OnEntityUnload()
    {
        if (autoGeneratedWeaponLaunchers)
        {
            Destroy(gunLauncher.gameObject);
            Destroy(missileLauncher.gameObject);
        }
        base.OnEntityUnload();
    }

    public override bool OnEntityActivated(int _indexInBlockActivationCommands, Vector3i _tePos, EntityAlive _entityFocusing)
    {
        EntityPlayerLocal entityPlayerLocal = _entityFocusing as EntityPlayerLocal;
        LocalPlayerUI uiforPlayer = LocalPlayerUI.GetUIForPlayer(entityPlayerLocal);
        if (this.isInteractionLocked)
        {
            return false;
        }
        switch (_indexInBlockActivationCommands)
        {
            case 0:
                if (!(uiforPlayer != null) || !uiforPlayer.windowManager.IsWindowOpen("windowpaging"))
                {
                    string @string = GamePrefs.GetString(EnumGamePrefs.PlayerId);
                    if (this.AttachedEntities == null && _entityFocusing.AttachedToEntity == null && this.isDriveable() && (!this.isLocked || this.IsOwner(@string) || !this.hasLock() || this.isAllowedUser(@string)) && !Physics.CapsuleCast(this.position, this.position, this.m_characterController.radius, Vector3.up, 1f, 65536))
                    {
                        _entityFocusing.SetAttachedTo(0, this);
                    }
                }
                break;
            case 1:
                {
                    // Testing different size storage
                    /*XUiC_VehicleWindowGroup.ID = vehicleXuiName;
                    DebugMsg("XUiC_VehicleWindowGroup.ID = " + XUiC_VehicleWindowGroup.ID);
                    DebugMsg("vehicleXuiName = " + vehicleXuiName);
                    DebugMsg("this.GetLootList() = " + this.GetLootList().ToString());
                    this.lootContainer.lootListIndex = this.GetLootList();
                    this.lootContainer.SetContainerSize(global::LootContainer.lootList[this.GetLootList()].size, true);
                    DebugMsg("this.lootContainer.items.Length = " + this.lootContainer.items.Length.ToString());
                    ItemStack[] oldStack = (ItemStack[])this.lootContainer.items.Clone();
                    this.lootContainer.items = new ItemStack[this.lootContainer.GetContainerSize().x * this.lootContainer.GetContainerSize().y];
                    oldStack.CopyTo(this.lootContainer.items, 0);
                    DebugMsg("this.lootContainer.items.Length = " + this.lootContainer.items.Length.ToString());
                    DebugMsg("lootListIndex = " + this.lootContainer.lootListIndex.ToString() + " | size = " + this.lootContainer.GetContainerSize().ToString());
                    GUIWindowManager windowManager = uiforPlayer.windowManager;
                    XUiC_VehicleWindowGroup xuic_vehicleWindowGroup = ((XUiC_VehicleWindowGroup)((XUiWindowGroup)windowManager.GetWindow(vehicleXuiName)).Controller);
                    xuic_vehicleWindowGroup.CurrentVehicleEntity = this;
                    xuic_vehicleWindowGroup.Update(0);
                    windowManager.Open(vehicleXuiName, true, false, true);*/

                    GUIWindowManager windowManager = uiforPlayer.windowManager;
                    ((XUiC_VehicleWindowGroup)((XUiWindowGroup)windowManager.GetWindow("vehicle")).Controller).CurrentVehicleEntity = this;
                    windowManager.Open("vehicle", true, false, true);                

                    Vector3i TS;
                    //var listOfFieldNames = typeof(Vehicle).GetFields();
                    var listOfFieldNames = typeof(CharacterController).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (FieldInfo fieldInfo in listOfFieldNames)
                    {
                        FieldInfo field = null;
                        if (fieldInfo.FieldType == typeof(CharacterController))
                        {
                            field = fieldInfo;
                            if (field != null)
                            {
                                TS = (Vector3i)field.GetValue(this);
                                DebugMsg("Found Vector3i TS");
                            }
                        }
                    }
                    TS = _tePos;
                    //this.TS = _tePos;
                    Audio.Manager.Play(this, "UseActions/open_vehicle");
                    this.isInteractionLocked = true;
                    this.syncStateData();
                    break;
                }
            case 2:
                if (entityPlayerLocal != null && XUiM_Vehicle.RepairVehicle(uiforPlayer.xui, this.vehicle))
                {
                    Audio.Manager.Play(this, "crafting/craft_repair_item");
                    this.syncStateData();
                }
                break;
            case 3:
                this.isLocked = true;
                Audio.Manager.Play(this, "misc/locking");
                this.syncPartData();
                break;
            case 4:
                this.isLocked = false;
                Audio.Manager.Play(this, "misc/unlocking");
                this.syncPartData();
                break;
            case 5:
                uiforPlayer.windowManager.Open(GUIWindowKeypad.ID, true, false, true);
                Audio.Manager.Play(this, "misc/password_type");
                NGuiKeypad.Instance.LockedItem = this;
                break;
            case 6:
                if (this.AddFuelFromInventory(_entityFocusing))
                {
                    this.syncStateData();
                }
                break;
            case 7:
                {
                    ItemValue partItemValueByTag = this.vehicle.GetPartItemValueByTag("chassis");
                    ItemStack itemStack = new ItemStack(partItemValueByTag, 1);
                    DebugMsg("Taking chassis: hasBuiltInStorage = " + hasBuiltInStorage.ToString());
                    if (uiforPlayer.xui.PlayerInventory.AddItem(itemStack, true))
                    {
                        // When taking the chassis, if it has built in storage, take all storage content.
                        if (HasBuiltInStorage())
                        {
                            DebugMsg("Taking storage content");
                            GetVehicleContainer().TakeAll();
                        }
                        this.vehicle.SetPartInSlot("chassis", ItemValue.None.Clone());
                        this.syncPartData();
                    }
                    break;
                }
            case 8:
                this.Honk();
                break;
        }
        return false;
    }
}

