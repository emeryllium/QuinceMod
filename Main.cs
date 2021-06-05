using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Main.Scenes;
using Assets.Scripts.Models;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Powers;
using Assets.Scripts.Models.Profile;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Filters;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Upgrades;
using Assets.Scripts.Models.TowerSets;
using Assets.Scripts.Unity;
using Assets.Scripts.Unity.Display;
using Assets.Scripts.Unity.Localization;
using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity.UI_New.InGame.StoreMenu;
using Assets.Scripts.Unity.UI_New.Upgrade;
using Assets.Scripts.Utils;
using Harmony;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

using UnhollowerBaseLib;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.Towers.Weapons;
using System.Net;
using Assets.Scripts.Unity.UI_New.Popups;
using TMPro;

namespace QuinceMod
{

    class Main : MelonMod
    {
        //https://github.com/gurrenm3/BloonsTD6-Mod-Helper/releases
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();

            //EventRegistry.instance.listen(typeof(Main));
            Console.WriteLine("quince mod loaded");
            //if (!File.Exists("Mods/BloonsTD6.Mod.Helper.dll"))
            //{
            //    using (WebClient client = new WebClient())
            //    {
            //        client.DownloadFile("https://github.com/gurrenm3/BloonsTD6-Mod-Helper/releases/download/0.0.2/BloonsTD6.Mod.Helper.dll", "Mods/BloonsTD6.Mod.Helper.dll");
            //        File.Delete("Mods/BloonsTD6_Mod_Helper.dll");
            //    }
            //    Console.WriteLine("Downloaded BloonsTD6.Mod.Helper.dll");
            //    Console.WriteLine("Restart required");
            //    Application.Quit(0);

            //}
        }


        static string customTowerImageID;
        static string customTowerName = "quince";
        static string customTowerDisplayName = "Quince";
        static string customTowerDisplay = "cddca470955e4e64da4063f1aa110f2b";

        static string customTowerUpgrade1Top = "Sharp Arrows";
        static string customTowerUpgrade2Top = "Double Arrows";
        static string customTowerUpgrade3Top = "Triple Arrows";
        static string customTowerUpgrade4Top = "Barbed Arrows";
        static string customTowerUpgrade5Top = "Quince, son of Quincy.";

        static string customTowerDescription1Top = "Arrows pop more bloons.";
        static string customTowerDescription2Top = "Shoots two arrows at a time.";
        static string customTowerDescription3Top = "Shoots three arrows at a time.";
        static string customTowerDescription4Top = "Arrows do extra damage.";
        static string customTowerDescription5Top = "Nothing gets past this bow!";

        static int customTowerCost1Top = 200;
        static int customTowerCost2Top = 550;
        static int customTowerCost3Top = 900;
        static int customTowerCost4Top = 4200;
        static int customTowerCost5Top = 43000;

        static string customTowerUpgrade1Mid = "Fast Arrows";
        static string customTowerUpgrade2Mid = "Fast Shooting";
        static string customTowerUpgrade3Mid = "Rapidfire Arrows";
        static string customTowerUpgrade4Mid = "Storm of Arrows";
        static string customTowerUpgrade5Mid = "Permafire";

        static string customTowerDescription1Mid = "Arrows fly through the air twice as fast.";
        static string customTowerDescription2Mid = "Shoots arrows more quickly.";
        static string customTowerDescription3Mid = "Ability: makes Quince attack twice as fast.";
        static string customTowerDescription4Mid = "Abilities: rapidfire ability now makes Quince attack four times as fast, and adds a Storm of Arrows ability.";
        static string customTowerDescription5Mid = "Rapidfire ability now permanently active and storm of arrows greatly improved.";

        static int customTowerCost1Mid = 150;
        static int customTowerCost2Mid = 400;
        static int customTowerCost3Mid = 950;
        static int customTowerCost4Mid = 3000;
        static int customTowerCost5Mid = 18000;

        static string customTowerUpgrade1Bottom = "Long Range";
        static string customTowerUpgrade2Bottom = "Sharp Marksmanship";
        static string customTowerUpgrade3Bottom = "Plasma Arrows";
        static string customTowerUpgrade4Bottom = "Champion of the Bow";
        static string customTowerUpgrade5Bottom = "Archery Master";

        static string customTowerDescription1Bottom = "Range increased.";
        static string customTowerDescription2Bottom = "Lets Quince see camo bloons.";
        static string customTowerDescription3Bottom = "Shoots out arrows made of plasma!";
        static string customTowerDescription4Bottom = "Champion of the Bow destroys all bloons.";
        static string customTowerDescription5Bottom = "The master of all archery.";

        static int customTowerCost1Bottom = 100;
        static int customTowerCost2Bottom = 300;
        static int customTowerCost3Bottom = 24000;
        static int customTowerCost4Bottom = 73000;
        static int customTowerCost5Bottom = 250000;

        static string customTowerImages = @"Mods/QuinceMod/";
        static string customTowerImageLocation = customTowerImages + "Quince.png";
        static string customTowerTowerSet = "Primary";
        static int customTowerTowerIndex = 3;




        static string[] upgrades = new string[]
{
                customTowerUpgrade1Top,
                customTowerUpgrade2Top,
                customTowerUpgrade3Top,
                customTowerUpgrade4Top,
                customTowerUpgrade5Top,
                customTowerUpgrade1Mid,
                customTowerUpgrade2Mid,
                customTowerUpgrade3Mid,
                customTowerUpgrade4Mid,
                customTowerUpgrade5Mid,
                customTowerUpgrade1Bottom,
                customTowerUpgrade2Bottom,
                customTowerUpgrade3Bottom,
                customTowerUpgrade4Bottom,
                customTowerUpgrade5Bottom,
};
        static string[] upgradeDescriptions = new string[]
        {
                customTowerDescription1Top,
                customTowerDescription2Top,
                customTowerDescription3Top,
                customTowerDescription4Top,
                customTowerDescription5Top,
                customTowerDescription1Mid,
                customTowerDescription2Mid,
                customTowerDescription3Mid,
                customTowerDescription4Mid,
                customTowerDescription5Mid,
                customTowerDescription1Bottom,
                customTowerDescription2Bottom,
                customTowerDescription3Bottom,
                customTowerDescription4Bottom,
                customTowerDescription5Bottom,
        };



        [HarmonyPatch(typeof(TitleScreen), "Start")]
        public class Awake_Patch
        {

            [HarmonyPostfix]
            public static void Postfix()
            {
                if (!Directory.Exists("Mods/QuinceMod/"))
                {
                    File.WriteAllBytes("Mods/QuinceMod.zip", Resource1.QuinceMod);
                    System.IO.Compression.ZipFile.ExtractToDirectory("Mods/QuinceMod.zip", "Mods/");
                    File.Delete("Mods/QuinceMod.zip");
                }

                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImageLocation, default, out customTowerImageID);
                string a;
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "100.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "200.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "300.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "400.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "500.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "010.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "020.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "030.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "040.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "050.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "001.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "002.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "003.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "004.PNG", default, out a);
                Game.instance.GetSpriteRegister().RegisterSpriteFromImage(customTowerImages + "005.PNG", default, out a);





                Console.WriteLine("initializing " + customTowerName);

                if (!LocalizationManager.instance.textTable.ContainsKey(customTowerName))
                {
                    LocalizationManager.instance.textTable.Add(customTowerName, customTowerDisplayName);
                }


                for (int i = 0; i < upgrades.Length; i++)
                {
                    if (!LocalizationManager.instance.textTable.ContainsKey(upgrades[i] + " Description"))
                    {
                        LocalizationManager.instance.textTable.Add(upgrades[i] + " Description", upgradeDescriptions[i]);
                    }
                }


                Il2CppSystem.Collections.Generic.List<UpgradeModel> list = new Il2CppSystem.Collections.Generic.List<UpgradeModel>();
                list.Add(new UpgradeModel(customTowerUpgrade1Top, customTowerCost1Top, 0, new SpriteReference(customTowerImages + "100.PNG"), 0, 1, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade2Top, customTowerCost2Top, 0, new SpriteReference(customTowerImages + "200.PNG"), 0, 2, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade3Top, customTowerCost3Top, 0, new SpriteReference(customTowerImages + "300.PNG"), 0, 3, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade4Top, customTowerCost4Top, 0, new SpriteReference(customTowerImages + "400.PNG"), 0, 4, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade5Top, customTowerCost5Top, 0, new SpriteReference(customTowerImages + "500.PNG"), 0, 5, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade1Mid, customTowerCost1Mid, 0, new SpriteReference(customTowerImages + "010.PNG"), 1, 1, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade2Mid, customTowerCost2Mid, 0, new SpriteReference(customTowerImages + "020.PNG"), 1, 2, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade3Mid, customTowerCost3Mid, 0, new SpriteReference(customTowerImages + "030.PNG"), 1, 3, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade4Mid, customTowerCost4Mid, 0, new SpriteReference(customTowerImages + "040.PNG"), 1, 4, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade5Mid, customTowerCost5Mid, 0, new SpriteReference(customTowerImages + "050.PNG"), 1, 5, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade1Bottom, customTowerCost1Bottom, 0, new SpriteReference(customTowerImages + "001.PNG"), 2, 1, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade2Bottom, customTowerCost2Bottom, 0, new SpriteReference(customTowerImages + "002.PNG"), 2, 2, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade3Bottom, customTowerCost3Bottom, 0, new SpriteReference(customTowerImages + "003.PNG"), 2, 3, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade4Bottom, customTowerCost4Bottom, 0, new SpriteReference(customTowerImages + "004.PNG"), 2, 4, 0, "", ""));
                list.Add(new UpgradeModel(customTowerUpgrade5Bottom, customTowerCost5Bottom, 0, new SpriteReference(customTowerImages + "005.PNG"), 2, 5, 0, "", ""));

                Game.instance.model.upgrades = Game.instance.model.upgrades.Add(list);
                Il2CppSystem.Collections.Generic.List<TowerModel> list2 = new Il2CppSystem.Collections.Generic.List<TowerModel>();

                list2.Add(getT0(Game.instance.model));

                list2.Add(getT1Top(Game.instance.model));
                list2.Add(getT2Top(Game.instance.model));
                list2.Add(getT3Top(Game.instance.model));
                list2.Add(getT4Top(Game.instance.model));
                list2.Add(getT5Top(Game.instance.model));

                list2.Add(getT110(Game.instance.model));
                list2.Add(getT210(Game.instance.model));
                list2.Add(getT310(Game.instance.model));
                list2.Add(getT410(Game.instance.model));
                list2.Add(getT510(Game.instance.model));

                list2.Add(getT120(Game.instance.model));
                list2.Add(getT220(Game.instance.model));
                list2.Add(getT320(Game.instance.model));
                list2.Add(getT420(Game.instance.model));
                list2.Add(getT520(Game.instance.model));

                list2.Add(getT101(Game.instance.model));
                list2.Add(getT201(Game.instance.model));
                list2.Add(getT301(Game.instance.model));
                list2.Add(getT401(Game.instance.model));
                list2.Add(getT501(Game.instance.model));

                list2.Add(getT102(Game.instance.model));
                list2.Add(getT202(Game.instance.model));
                list2.Add(getT302(Game.instance.model));
                list2.Add(getT402(Game.instance.model));
                list2.Add(getT502(Game.instance.model));

                list2.Add(getT1Mid(Game.instance.model));
                list2.Add(getT2Mid(Game.instance.model));
                list2.Add(getT3Mid(Game.instance.model));
                list2.Add(getT4Mid(Game.instance.model));
                list2.Add(getT5Mid(Game.instance.model));

                list2.Add(getT130(Game.instance.model));
                list2.Add(getT140(Game.instance.model));
                list2.Add(getT150(Game.instance.model));

                list2.Add(getT230(Game.instance.model));
                list2.Add(getT240(Game.instance.model));
                list2.Add(getT250(Game.instance.model));

                list2.Add(getT011(Game.instance.model));
                list2.Add(getT021(Game.instance.model));
                list2.Add(getT031(Game.instance.model));
                list2.Add(getT041(Game.instance.model));
                list2.Add(getT051(Game.instance.model));

                list2.Add(getT012(Game.instance.model));
                list2.Add(getT022(Game.instance.model));
                list2.Add(getT032(Game.instance.model));
                list2.Add(getT042(Game.instance.model));
                list2.Add(getT052(Game.instance.model));

                list2.Add(getT1Bottom(Game.instance.model));
                list2.Add(getT2Bottom(Game.instance.model));
                list2.Add(getT3Bottom(Game.instance.model));
                list2.Add(getT4Bottom(Game.instance.model));
                list2.Add(getT5Bottom(Game.instance.model));

                list2.Add(getT103(Game.instance.model));
                list2.Add(getT104(Game.instance.model));
                list2.Add(getT105(Game.instance.model));

                list2.Add(getT203(Game.instance.model));
                list2.Add(getT204(Game.instance.model));
                list2.Add(getT205(Game.instance.model));

                list2.Add(getT013(Game.instance.model));
                list2.Add(getT014(Game.instance.model));
                list2.Add(getT015(Game.instance.model));

                list2.Add(getT023(Game.instance.model));
                list2.Add(getT024(Game.instance.model));
                list2.Add(getT025(Game.instance.model));

                Game.instance.model.towers = Game.instance.model.towers.Add(list2);
                Il2CppSystem.Collections.Generic.List<TowerDetailsModel> list3 = new Il2CppSystem.Collections.Generic.List<TowerDetailsModel>();
                foreach (TowerDetailsModel item in Game.instance.model.towerSet)
                {
                    list3.Add(item);
                }
                ShopTowerDetailsModel newPart = new ShopTowerDetailsModel(customTowerName, customTowerTowerIndex, 5, 5, 5, -1, 0, null);
                Game.instance.model.towerSet = Game.instance.model.towerSet.Add(newPart);
                bool flag = false;
                foreach (TowerDetailsModel towerDetailsModel in Game.instance.model.towerSet)
                {
                    if (flag)
                    {
                        int towerIndex = towerDetailsModel.towerIndex;
                        towerDetailsModel.towerIndex = towerIndex + 1;
                    }
                    if (towerDetailsModel.towerId.Contains(customTowerName))
                    {
                        flag = true;
                    }
                }
                Console.WriteLine(customTowerName + " initialized");

            }
        }





        public static TowerModel getT0(GameModel gameModel)
        {
            TowerModel towerModel = gameModel.GetTowerFromId("Quincy").Duplicate<TowerModel>();
            towerModel.name = customTowerName;
            towerModel.baseId = customTowerName;
            towerModel.portrait = new SpriteReference(customTowerImageID);
            towerModel.icon = new SpriteReference(customTowerImageID);
            towerModel.instaIcon = new SpriteReference(customTowerImageID);
            towerModel.display = customTowerDisplay;
            towerModel.GetBehavior<DisplayModel>().display = customTowerDisplay;
            towerModel.towerSet = customTowerTowerSet;
            towerModel.dontDisplayUpgrades = false;
            towerModel.cost = 300;
            towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(new UpgradePathModel[]
            {
                        new UpgradePathModel(customTowerUpgrade1Top, customTowerName + "-100", 1, 1),
                        new UpgradePathModel(customTowerUpgrade1Mid, customTowerName + "-010", 1, 1),
                        new UpgradePathModel(customTowerUpgrade1Bottom, customTowerName + "-001", 1, 1),
            });
            towerModel.tiers = new int[] { 0, 0, 0 };


            //balance stuff
            towerModel.mods = new Il2CppReferenceArray<Assets.Scripts.Models.Towers.Mods.ApplyModModel>(0);
            towerModel.RemoveBehavior<HeroModel>();
            towerModel.RemoveBehavior<CreateSoundOnBloonEnterTrackModel>();
            towerModel.RemoveBehavior<CreateSoundOnBloonLeakModel>();
            towerModel.RemoveBehavior<CreateSoundOnSelectedModel>();
            towerModel.RemoveBehavior<AbilityModel>();
            towerModel.RemoveBehavior<AbilityModel>();

            var attack = gameModel.GetTowerFromId("Quincy").Duplicate<TowerModel>().GetBehavior<AttackModel>();//towerModel.GetBehavior<AttackModel>();
            //attack.weapons[0].GetBehavior<AlternateProjectileModel>().projectile.RemoveBehavior<BloonSlapModel>();

            //wtf why does it still pop leads
            //attack.weapons[0].projectile.GetBehavior<DamageModel>().damageTypes[0] = "Sharp";
            //attack.weapons[0].projectile.GetBehavior<DamageModel>().ignoreImmunityForBloonTypes = new Il2CppStringArray(0);
            attack.weapons[0].projectile.pierce = 2;
            attack.weapons[0].projectile.maxPierce = 99999;
            attack.weapons[0].projectile.CapPierce(99999);
            attack.weapons[0].projectile.GetBehavior<DamageModel>().damage = 1;
            attack.weapons[0].projectile.GetBehavior<DamageModel>().CapDamage(9999);
            attack.weapons[0].projectile.GetBehavior<DamageModel>().maxDamage = 9999;
            attack.weapons[0].Rate = 1;
            towerModel.RemoveBehavior<AttackModel>();
            towerModel.AddBehavior(attack);

            FileIOUtil.SaveObject("sword0.json", towerModel);

            return towerModel;

        }




        public static TowerModel getT1Top(GameModel gameModel)
        {
            TowerModel towerModel = getT0(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 0, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }


        public static TowerModel getT2Top(GameModel gameModel)
        {
            TowerModel towerModel = getT1Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 0, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.AddWeapon(attackModel.weapons[0]);
            return towerModel;
        }


        public static TowerModel getT3Top(GameModel gameModel)
        {
            TowerModel towerModel = getT2Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 3, 0, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);
            //2 swords
            towerModel.display = customTowerDisplay;
            towerModel.GetBehavior<DisplayModel>().display = customTowerDisplay;

            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.AddWeapon(attackModel.weapons[0]);


            return towerModel;
        }


        public static TowerModel getT4Top(GameModel gameModel)
        {
            TowerModel towerModel = getT3Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 4, 0, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);


            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            foreach (var item in attackModel.weapons)
            {
                item.projectile.GetDamageModel().damage = 5;
            }


            return towerModel;
        }


        public static TowerModel getT5Top(GameModel gameModel)
        {
            TowerModel towerModel = getT4Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 5, 0, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);


            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.25f;
                item.projectile.GetDamageModel().damage *= 3;
                item.projectile.pierce *= 10;
            }
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            //attackModel.weapons[0].projectile.pierce = 8;
            //attackModel.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.pierce = 8; ;

            return towerModel;
        }


        public static TowerModel getT1Mid(GameModel gameModel)
        {
            TowerModel towerModel = getT0(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 1, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;

            return towerModel;
        }


        public static TowerModel getT2Mid(GameModel gameModel)
        {
            TowerModel towerModel = getT1Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 2, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }
            return towerModel;
        }


        public static TowerModel getT3Mid(GameModel gameModel)
        {
            TowerModel towerModel = getT2Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 3, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);


            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            AbilityModel abilityModel = gameModel.towers.FirstOrDefault((TowerModel quincy) => quincy.name.Contains("Quincy") && quincy.tier == 3).behaviors.FirstOrDefault((Model ab) => ab.name.Contains("Rapid")).Clone().Cast<AbilityModel>();
            towerModel.behaviors = towerModel.behaviors.Add(abilityModel);

            return towerModel;
        }


        public static TowerModel getT4Mid(GameModel gameModel)
        {
            TowerModel towerModel = getT2Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 4, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);


            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            AbilityModel abilityModel = gameModel.towers.FirstOrDefault((TowerModel quincy) => quincy.name.Contains("Quincy") && quincy.tier == 20).behaviors.FirstOrDefault((Model ab) => ab.name.Contains("Rapid")).Clone().Cast<AbilityModel>();
            towerModel.behaviors = towerModel.behaviors.Add(abilityModel);
            AbilityModel abilityModel2 = gameModel.towers.FirstOrDefault((TowerModel quincy) => quincy.name.Contains("Quincy") && quincy.tier == 10).behaviors.FirstOrDefault((Model ab) => ab.name.Contains("Storm")).Clone().Cast<AbilityModel>();
            towerModel.behaviors = towerModel.behaviors.Add(abilityModel2);
            return towerModel;
        }


        public static TowerModel getT5Mid(GameModel gameModel)
        {
            TowerModel towerModel = getT2Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 5, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);


            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            AbilityModel abilityModel2 = gameModel.towers.FirstOrDefault((TowerModel quincy) => quincy.name.Contains("Quincy") && quincy.tier == 20).behaviors.FirstOrDefault((Model ab) => ab.name.Contains("Storm")).Clone().Cast<AbilityModel>();
            towerModel.behaviors = towerModel.behaviors.Add(abilityModel2);

            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.25f;
            }

            return towerModel;
        }



        public static TowerModel getT1Bottom(GameModel gameModel)
        {
            TowerModel towerModel = getT0(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 0, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }


        public static TowerModel getT2Bottom(GameModel gameModel)
        {
            TowerModel towerModel = getT1Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 0, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            //balance stuff
            //attackModel.weapons[0].projectile.GetBehavior<DamageModel>().damageTypes[0] = "Normal";
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
            //FileIOUtil.SaveObject("sword2.json", towerModel);
            return towerModel;
        }


        public static TowerModel getT3Bottom(GameModel gameModel)
        {
            TowerModel towerModel = getT2Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 0, 3);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            var attack = gameModel.GetTowerFromId("HeliPilot-500").Duplicate<TowerModel>().GetBehavior<AttackModel>();//towerModel.GetBehavior<AttackModel>();
            //attack.weapons[0].GetBehavior<AlternateProjectileModel>().projectile.RemoveBehavior<BloonSlapModel>();

            //wtf why does it still pop leads
            //attack.weapons[0].projectile.GetBehavior<DamageModel>().damageTypes[0] = "Sharp";
            //attack.weapons[0].projectile.GetBehavior<DamageModel>().ignoreImmunityForBloonTypes = new Il2CppStringArray(0);
            attackModel.weapons[0].projectile = attack.weapons[2].projectile;
            attackModel.weapons[0].projectile.pierce = 5;
            attackModel.weapons[0].projectile.maxPierce = 99999;
            attackModel.weapons[0].projectile.CapPierce(99999);
            attackModel.weapons[0].projectile.GetBehavior<DamageModel>().damage = 10;
            attackModel.weapons[0].projectile.GetBehavior<DamageModel>().CapDamage(9999);
            attackModel.weapons[0].projectile.GetBehavior<DamageModel>().maxDamage = 9999;
            attackModel.weapons[0].Rate = 0.5f;
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;

            return towerModel;
        }


        public static TowerModel getT4Bottom(GameModel gameModel)
        {
            TowerModel towerModel = getT3Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 0, 4);
            towerModel.portrait = new SpriteReference(customTowerImageID);


            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].projectile.GetDamageModel().damage = 25;
            attackModel.weapons[0].projectile.pierce = 20;
            attackModel.weapons[0].Rate = 0.1f;
            attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
            return towerModel;
        }


        public static TowerModel getT5Bottom(GameModel gameModel)
        {
            TowerModel towerModel = getT4Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 0, 5);
            towerModel.portrait = new SpriteReference(customTowerImageID);


            //balance stuff
            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.weapons[0].Rate = 0.01f;
            attackModel.weapons[0].projectile.pierce = 100;

            return towerModel;
        }

        public static TowerModel getT110(GameModel gameModel)
        {
            TowerModel towerModel = getT1Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 1, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;

            return towerModel;
        }

        public static TowerModel getT210(GameModel gameModel)
        {
            TowerModel towerModel = getT2Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 1, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;

            return towerModel;
        }

        public static TowerModel getT310(GameModel gameModel)
        {
            TowerModel towerModel = getT3Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 3, 1, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;

            return towerModel;
        }

        public static TowerModel getT410(GameModel gameModel)
        {
            TowerModel towerModel = getT4Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 4, 1, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;

            return towerModel;
        }

        public static TowerModel getT510(GameModel gameModel)
        {
            TowerModel towerModel = getT5Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 5, 1, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;

            return towerModel;
        }

        public static TowerModel getT120(GameModel gameModel)
        {
            TowerModel towerModel = getT1Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 2, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT220(GameModel gameModel)
        {
            TowerModel towerModel = getT2Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 2, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT320(GameModel gameModel)
        {
            TowerModel towerModel = getT3Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 3, 2, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT420(GameModel gameModel)
        {
            TowerModel towerModel = getT4Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 4, 2, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT520(GameModel gameModel)
        {
            TowerModel towerModel = getT5Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 5, 2, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT101(GameModel gameModel)
        {
            TowerModel towerModel = getT1Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 0, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT201(GameModel gameModel)
        {
            TowerModel towerModel = getT2Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 0, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT301(GameModel gameModel)
        {
            TowerModel towerModel = getT3Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 3, 0, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT401(GameModel gameModel)
        {
            TowerModel towerModel = getT4Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 4, 0, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT501(GameModel gameModel)
        {
            TowerModel towerModel = getT5Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 5, 0, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT102(GameModel gameModel)
        {
            TowerModel towerModel = getT1Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 0, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT202(GameModel gameModel)
        {
            TowerModel towerModel = getT2Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 0, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT302(GameModel gameModel)
        {
            TowerModel towerModel = getT3Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 3, 0, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT402(GameModel gameModel)
        {
            TowerModel towerModel = getT4Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 4, 0, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT502(GameModel gameModel)
        {
            TowerModel towerModel = getT5Top(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 5, 0, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT130(GameModel gameModel)
        {
            TowerModel towerModel = getT3Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 3, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT140(GameModel gameModel)
        {
            TowerModel towerModel = getT4Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 4, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT150(GameModel gameModel)
        {
            TowerModel towerModel = getT5Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 5, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT230(GameModel gameModel)
        {
            TowerModel towerModel = getT3Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 3, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;
            attackModel.AddWeapon(attackModel.weapons[0]);

            return towerModel;
        }

        public static TowerModel getT240(GameModel gameModel)
        {
            TowerModel towerModel = getT4Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 4, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;
            attackModel.AddWeapon(attackModel.weapons[0]);

            return towerModel;
        }

        public static TowerModel getT250(GameModel gameModel)
        {
            TowerModel towerModel = getT5Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 5, 0);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;
            attackModel.AddWeapon(attackModel.weapons[0]);

            return towerModel;
        }

        public static TowerModel getT011(GameModel gameModel)
        {
            TowerModel towerModel = getT1Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 1, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT021(GameModel gameModel)
        {
            TowerModel towerModel = getT2Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 2, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT031(GameModel gameModel)
        {
            TowerModel towerModel = getT3Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 3, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT041(GameModel gameModel)
        {
            TowerModel towerModel = getT4Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 4, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT051(GameModel gameModel)
        {
            TowerModel towerModel = getT5Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 5, 1);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;

            return towerModel;
        }

        public static TowerModel getT012(GameModel gameModel)
        {
            TowerModel towerModel = getT1Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 1, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT022(GameModel gameModel)
        {
            TowerModel towerModel = getT2Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 2, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT032(GameModel gameModel)
        {
            TowerModel towerModel = getT3Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 3, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT042(GameModel gameModel)
        {
            TowerModel towerModel = getT4Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 4, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT052(GameModel gameModel)
        {
            TowerModel towerModel = getT5Mid(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 5, 2);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
            attackModel.range *= 1.5f;
            towerModel.range *= 1.5f;
            towerModel.radius *= 1.5f;
            towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));

            return towerModel;
        }

        public static TowerModel getT103(GameModel gameModel)
        {
            TowerModel towerModel = getT3Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 0, 3);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT104(GameModel gameModel)
        {
            TowerModel towerModel = getT4Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 0, 4);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT105(GameModel gameModel)
        {
            TowerModel towerModel = getT5Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 1, 0, 5);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT203(GameModel gameModel)
        {
            TowerModel towerModel = getT3Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 0, 3);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;
            attackModel.AddWeapon(attackModel.weapons[0]);

            return towerModel;
        }

        public static TowerModel getT204(GameModel gameModel)
        {
            TowerModel towerModel = getT4Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 0, 4);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;
            attackModel.AddWeapon(attackModel.weapons[0]);

            return towerModel;
        }

        public static TowerModel getT205(GameModel gameModel)
        {
            TowerModel towerModel = getT5Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 2, 0, 5);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.pierce *= 2;
            attackModel.AddWeapon(attackModel.weapons[0]);

            return towerModel;
        }

        public static TowerModel getT013(GameModel gameModel)
        {
            TowerModel towerModel = getT3Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 1, 3);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT014(GameModel gameModel)
        {
            TowerModel towerModel = getT4Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 1, 4);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT015(GameModel gameModel)
        {
            TowerModel towerModel = getT5Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 1, 5);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            return towerModel;
        }

        public static TowerModel getT023(GameModel gameModel)
        {
            TowerModel towerModel = getT3Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 2, 3);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT024(GameModel gameModel)
        {
            TowerModel towerModel = getT4Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 2, 4);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }

        public static TowerModel getT025(GameModel gameModel)
        {
            TowerModel towerModel = getT5Bottom(gameModel).Duplicate<TowerModel>();
            SetTiersAndUpgrades(ref towerModel, 0, 2, 5);
            towerModel.portrait = new SpriteReference(customTowerImageID);

            AttackModel attackModel = towerModel.GetBehavior<AttackModel>();

            attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= 2;
            foreach (var item in attackModel.weapons)
            {
                item.rate *= 0.75f;
            }

            attackModel.weapons[0].projectile.pierce *= 2;

            return towerModel;
        }


        [HarmonyPatch(typeof(ProfileModel), "Validate")]
        public class ProfileModel_Patch
        {

            [HarmonyPostfix]
            public static void Postfix(ref ProfileModel __instance)
            {
                var unlockedTowers = __instance.unlockedTowers;
                var acquiredUpgrades = __instance.acquiredUpgrades;
                if (!unlockedTowers.Contains(customTowerName))
                {
                    unlockedTowers.Add(customTowerName);
                }
                //string[] array = new string[]
                //{
                //    customTowerUpgrade1Mid,
                //    customTowerUpgrade2Mid,
                //    customTowerUpgrade3Mid,
                //    customTowerUpgrade4Mid,
                //    customTowerUpgrade5Mid
                //};
                for (int i = 0; i < upgrades.Length; i++)
                {
                    if (!acquiredUpgrades.Contains(upgrades[i]))
                    {
                        acquiredUpgrades.Add(upgrades[i]);
                    }
                }
            }
        }




        
        //Utility
        public static void SetTiersAndUpgrades(ref TowerModel towerModel, int top, int mid, int bottom)
        {

            towerModel.name = customTowerName + "-" + top + "" + mid + "" + bottom + "";
            towerModel.tiers = new int[] { top, mid, bottom };

            if (top == 5)
            {
                towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(new UpgradePathModel[]
                    {
                    new UpgradePathModel(upgrades[5 + mid], towerModel.name, 1, towerModel.tiers[1]+1),
                    new UpgradePathModel(upgrades[10 + bottom], towerModel.name, 1, towerModel.tiers[2]+1)
                    });
            } else if (mid == 5)
            {
                towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(new UpgradePathModel[]
                    {
                    new UpgradePathModel(upgrades[top], towerModel.name, 1, towerModel.tiers[0]+1),
                    new UpgradePathModel(upgrades[10 + bottom], towerModel.name, 1, towerModel.tiers[2]+1)
                    });
            } else if (bottom == 5)
            {
                towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(new UpgradePathModel[]
                    {
                    new UpgradePathModel(upgrades[top], towerModel.name, 1, towerModel.tiers[0]+1),
                    new UpgradePathModel(upgrades[5 + mid], towerModel.name, 1, towerModel.tiers[1]+1)
                    });
            } else
            {
                towerModel.upgrades = new Il2CppReferenceArray<UpgradePathModel>(new UpgradePathModel[]
                    {
                    new UpgradePathModel(upgrades[top], towerModel.name, 1, towerModel.tiers[0]+1),
                    new UpgradePathModel(upgrades[5 + mid], towerModel.name, 1, towerModel.tiers[1]+1),
                    new UpgradePathModel(upgrades[10 + bottom], towerModel.name, 1, towerModel.tiers[2]+1)
                    });
            }
        }

        //Utility
        public static Texture2D TextureFromPNG(string path)
        {
            Texture2D text = new Texture2D(2, 2);

            if (!ImageConversion.LoadImage(text, File.ReadAllBytes(path)))
            {
                throw new Exception("Could not acquire texture from file " + Path.GetFileName(path) + ".");
            }

            return text;
        }

        static string lastTower;

        [HarmonyPatch(typeof(UpgradeScreen), "UpdateUi")]
        private class UpgradeScreen3
        {

            [HarmonyPrefix]
            internal static bool UpdateUi(ref UpgradeScreen __instance, ref string towerId, string upgradeID)
            {
                lastTower = towerId;
                if (towerId == customTowerName)
                {
                    //if (__instance == null) return false;

                    towerId = "DartMonkey";

                    //Console.WriteLine("UpdateUi called");
                    //Console.WriteLine(towerId);
                    //Console.WriteLine(upgradeID);
                    //Console.WriteLine("populating paths");
                    //if (__instance != null)
                    //    __instance.PopulatePaths(getT0(Game.instance.model), "", true);
                    //return false;
                }
                return true;
            }


            [HarmonyPostfix]
            internal static void UpdateUi2(ref UpgradeScreen __instance, ref string towerId, string upgradeID)
            {
                if (lastTower == customTowerName)
                {
                    //Console.WriteLine("postfix sword");
                    __instance.towerTitle.text = "Quince";
                    __instance.path1Upgrades[0].upgradeName.text = customTowerDescription1Top;
                    __instance.path1Upgrades[0].portrait = new SpriteReference(customTowerImageID);
                    __instance.path1Upgrades[0].upgradeCost.text = customTowerCost1Top.ToString();

                    __instance.path1Upgrades[1].upgradeName.text = customTowerDescription2Top;
                    __instance.path1Upgrades[1].portrait = new SpriteReference(customTowerImageID);
                    __instance.path1Upgrades[1].upgradeCost.text = customTowerCost2Top.ToString();

                    __instance.path1Upgrades[2].upgradeName.text = customTowerDescription3Top;
                    __instance.path1Upgrades[2].portrait = new SpriteReference(customTowerImageID);
                    __instance.path1Upgrades[2].upgradeCost.text = customTowerCost3Top.ToString();

                    __instance.path1Upgrades[3].upgradeName.text = customTowerDescription4Top;
                    __instance.path1Upgrades[3].portrait = new SpriteReference(customTowerImageID);
                    __instance.path1Upgrades[3].upgradeCost.text = customTowerCost4Top.ToString();

                    __instance.path1Upgrades[4].upgradeName.text = customTowerDescription5Top;
                    __instance.path1Upgrades[4].portrait = new SpriteReference(customTowerImageID);
                    __instance.path1Upgrades[4].upgradeCost.text = customTowerCost5Top.ToString();

                    __instance.path2Upgrades[0].upgradeName.text = customTowerDescription1Mid;
                    __instance.path2Upgrades[0].portrait = new SpriteReference(customTowerImageID);
                    __instance.path1Upgrades[0].upgradeCost.text = customTowerCost1Mid.ToString();

                    __instance.path2Upgrades[1].upgradeName.text = customTowerDescription2Mid;
                    __instance.path2Upgrades[1].portrait = new SpriteReference(customTowerImageID);
                    __instance.path2Upgrades[1].upgradeCost.text = customTowerCost2Mid.ToString();

                    __instance.path2Upgrades[2].upgradeName.text = customTowerDescription3Mid;
                    __instance.path2Upgrades[2].portrait = new SpriteReference(customTowerImageID);
                    __instance.path2Upgrades[2].upgradeCost.text = customTowerCost3Mid.ToString();

                    __instance.path2Upgrades[3].upgradeName.text = customTowerDescription4Mid;
                    __instance.path2Upgrades[3].portrait = new SpriteReference(customTowerImageID);
                    __instance.path2Upgrades[3].upgradeCost.text = customTowerCost4Mid.ToString();

                    __instance.path2Upgrades[4].upgradeName.text = customTowerDescription5Mid;
                    __instance.path2Upgrades[4].portrait = new SpriteReference(customTowerImageID);
                    __instance.path2Upgrades[4].upgradeCost.text = customTowerCost5Mid.ToString();

                    __instance.path3Upgrades[0].upgradeName.text = customTowerDescription1Bottom;
                    __instance.path3Upgrades[0].portrait = new SpriteReference(customTowerImageID);
                    __instance.path3Upgrades[0].upgradeCost.text = customTowerCost1Bottom.ToString();

                    __instance.path3Upgrades[1].upgradeName.text = customTowerDescription2Bottom;
                    __instance.path3Upgrades[1].portrait = new SpriteReference(customTowerImageID);
                    __instance.path3Upgrades[1].upgradeCost.text = customTowerCost2Bottom.ToString();

                    __instance.path3Upgrades[2].upgradeName.text = customTowerDescription3Bottom;
                    __instance.path3Upgrades[2].portrait = new SpriteReference(customTowerImageID);
                    __instance.path3Upgrades[2].upgradeCost.text = customTowerCost3Bottom.ToString();

                    __instance.path3Upgrades[3].upgradeName.text = customTowerDescription4Bottom;
                    __instance.path3Upgrades[3].portrait = new SpriteReference(customTowerImageID);
                    __instance.path3Upgrades[3].upgradeCost.text = customTowerCost4Bottom.ToString();

                    __instance.path3Upgrades[4].upgradeName.text = customTowerDescription5Bottom;
                    __instance.path3Upgrades[4].portrait = new SpriteReference(customTowerImageID);
                    __instance.path3Upgrades[4].upgradeCost.text = customTowerCost5Bottom.ToString();

                    //__instance.path1Upgrades[0].upgradeCost.text = Game.instance.model.upgradesByName[customTowerUpgrade1Top].name;



                }
            }
        }
    }
}
