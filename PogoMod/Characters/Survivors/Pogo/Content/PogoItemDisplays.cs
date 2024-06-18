using PogoMod.Modules;
using PogoMod.Modules.Characters;
using RoR2;
using System.Collections.Generic;
using UnityEngine;

/* for custom copy format in keb's helper
{childName},
                    {localPos}, 
                    {localAngles},
                    {localScale})
*/

namespace PogoMod.Survivors.Pogo
{
    public class PogoItemDisplays : ItemDisplaysBase
    {
        protected override void SetItemDisplayRules(List<ItemDisplayRuleSet.KeyAssetRuleGroup> itemDisplayRules)
        {
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AlienHead"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAlienHead"),
                    "Pelvis",
                    new Vector3(-0.23904F, 0.03095F, -0.07823F),
                    new Vector3(35.41798F, 77.17166F, 204.8131F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ArmorPlate"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRepulsionArmorPlate"),
                    "ThighL",
                    new Vector3(0.05671F, 0.19089F, 0.07995F),
                    new Vector3(86.83807F, 253.6766F, 55.20719F),
                    new Vector3(0.34F, 0.34F, 0.34F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ArmorReductionOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarhammer"),
                    "Chest",
                    new Vector3(0.21537F, 0.39689F, -0.28211F),
                    new Vector3(316.1172F, 119.5393F, 241.0765F),
                    new Vector3(0.34F, 0.34F, 0.34F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedAndMoveSpeed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCoffee"),
                    "Chest",
                    new Vector3(-0.18896F, -0.10045F, 0.07998F),
                    new Vector3(351.5361F, 7.21466F, 332.3582F),
                    new Vector3(0.15865F, 0.15865F, 0.15865F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWolfPelt"),
                    "Head",
                    new Vector3(0F, 0.22929F, 0.02F),
                    new Vector3(0.06506F, 354.9998F, 359.9943F),
                    new Vector3(0.6F, 0.6F, 0.6F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AutoCastEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFossil"),
                    "Pelvis",
                    new Vector3(-0.18906F, 0.00981F, 0.07952F),
                    new Vector3(1.50825F, 18.85318F, 32.72843F),
                    new Vector3(0.61133F, 0.61133F, 0.61133F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Bandolier"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBandolier"),
                    "Chest",
                    new Vector3(0.03099F, 0.17655F, 0.01862F),
                    new Vector3(325.8073F, 272.2189F, 90.79084F),
                    new Vector3(0.65F, 0.65F, 0.65F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrierOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrooch"),
                    "Chest",
                    new Vector3(0.00358F, 0.23507F, 0.21109F),
                    new Vector3(61.8529F, 1.32068F, 6.66135F),
                    new Vector3(0.6F, 0.6F, 0.6F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrierOnOverHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAegis"),
                    "LowerArmL",
                    new Vector3(-0.03639F, 0.05091F, 0.04765F),
                    new Vector3(86.05048F, 101.8809F, 306.1761F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Bear"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBear"),
                    "Chest",
                    new Vector3(-0.15314F, 0.5001F, -0.04922F),
                    new Vector3(0.09832F, 359.1789F, 13.65848F),
                    new Vector3(0.15402F, 0.15402F, 0.15402F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BearVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBearVoid"),
                    "Chest",
                    new Vector3(-0.15314F, 0.5001F, -0.04922F),
                    new Vector3(0.09832F, 359.1789F, 13.65848F),
                    new Vector3(0.15402F, 0.15402F, 0.15402F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BeetleGland"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeetleGland"),
                    "Chest",
                    new Vector3(0.26902F, -0.16111F, 0.00791F),
                    new Vector3(356.2571F, 152.9436F, 311.4961F),
                    new Vector3(0.10258F, 0.10578F, 0.10578F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Behemoth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBehemoth"),
                    "Chest",
                    new Vector3(-0.07022F, 0.01161F, -0.17047F),
                    new Vector3(306.2223F, 272.9689F, 191.2178F),
                    new Vector3(0.1F, 0.1F, 0.1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTip"),
                    "Pelvis",
                    new Vector3(0.19782F, 0.06875F, 0.08377F),
                    new Vector3(289.532F, 78.0827F, 98.98547F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHitAndExplode"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBleedOnHitAndExplode"),
                    "Chest",
                    new Vector3(-0.16044F, -0.2267F, -0.10126F),
                    new Vector3(334.84F, 1.71427F, 340.8119F),
                    new Vector3(0.10397F, 0.10397F, 0.10397F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHitVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTipVoid"),
                    "Chest",
                    new Vector3(-0.25703F, 0.48684F, -0.11026F),
                    new Vector3(47.2635F, 47.76472F, 223.6329F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BonusGoldPackOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTome"),
                    "ThighL",
                    new Vector3(0.14704F, 0.17491F, 0.02078F),
                    new Vector3(5.77171F, 73.43825F, 186.8631F),
                    new Vector3(0.0973F, 0.0973F, 0.0973F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAPRound"),
                    "CalfR",
                    new Vector3(0.14483F, 0.04333F, -0.00831F),
                    new Vector3(275.4995F, 51.30243F, 39.29582F),
                    new Vector3(0.7F, 0.7F, 0.7F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BounceNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHook"),
                    "Chest",
                    new Vector3(0.00973F, 0.07502F, -0.12599F),
                    new Vector3(325.8474F, 358.639F, 353.9168F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ChainLightning"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkulele"),
                    "Chest",
                    new Vector3(-0.05651F, 0.06796F, -0.14373F),
                    new Vector3(12.83571F, 186.7411F, 36.97393F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ChainLightningVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkuleleVoid"),
                    "Chest",
                    new Vector3(-0.02164F, 0.11161F, -0.14177F),
                    new Vector3(13.01929F, 186.746F, 36.9962F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Clover"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayClover"),
                    "Head",
                    new Vector3(0.00361F, 0.29643F, -0.01096F),
                    new Vector3(343.1115F, -0.00002F, 0F),
                    new Vector3(0.5F, 0.5F, 0.5F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CloverVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCloverVoid"),
                    "Head",
                    new Vector3(0F, 0.30878F, 0.00133F),
                    new Vector3(352.366F, -0.00004F, -0.00004F),
                    new Vector3(0.75F, 0.75F, 0.75F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CooldownOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkull"),
                    "Chest",
                    new Vector3(-0.00331F, 0.3056F, 0.15967F),
                    new Vector3(299.1747F, 181.078F, 180.9835F),
                    new Vector3(0.15F, 0.15F, 0.15F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserSight"),
                    "LeftMuzzle",
                    new Vector3(0.00867F, -0.03353F, -0.00507F),
                    new Vector3(2.85582F, 8.62536F, 255.4125F),
                    new Vector3(0.04F, 0.04F, 0.04F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserSight"),
                    "RightMuzzle",
                    new Vector3(-0.01611F, -0.0308F, -0.00342F),
                    new Vector3(353.7731F, 178.924F, 264.5021F),
                    new Vector3(0.04F, 0.04F, 0.04F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritGlasses"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlasses"),
                    "Head",
                    new Vector3(0F, 0.14715F, 0.13514F),
                    new Vector3(0.0006F, 359.9548F, 1.86518F),
                    new Vector3(0.28F, 0.28F, 0.28F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritGlassesVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlassesVoid"),
                    "Head",
                    new Vector3(0F, 0.15177F, 0.15256F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.25F, 0.25F, 0.25F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Crowbar"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCrowbar"),
                    "Chest",
                    new Vector3(-0.03712F, 0.04463F, -0.15399F),
                    new Vector3(29.63123F, 92.60905F, 355.2203F),
                    new Vector3(0.50935F, 0.50935F, 0.50935F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Dagger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDagger"),
                    "UpperArmR",
                    new Vector3(0.0558F, -0.11667F, -0.00139F),
                    new Vector3(30.75428F, 231.9843F, 125.9346F),
                    new Vector3(0.91742F, 0.91742F, 0.91742F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DeathMark"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathMark"),
                    "LowerArmL",
                    new Vector3(-0.05356F, 0.24462F, 0.03008F),
                    new Vector3(284.0605F, 286.9774F, 15.96666F),
                    new Vector3(0.02F, 0.02F, 0.02F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ElementalRingVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVoidRing"),
                    "HandR",
                    new Vector3(0.0082F, 0.00239F, 0.00011F),
                    new Vector3(282.1854F, 270.6395F, 170.7254F),
                    new Vector3(0.54468F, 0.54468F, 0.54468F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EmpowerAlways"],
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.Head),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHeadNeck"),
                    "Chest",
                    new Vector3(0F, 0.3902F, -0.00617F),
                    new Vector3(1.98248F, 20.70284F, 3.68133F),
                    new Vector3(1.5F, 1.5F, 1.5F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHead"),
                    "Head",
                    new Vector3(-0.00149F, 0.17198F, 0.02873F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1.05F, 1.05F, 1.05F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EnergizedOnEquipmentUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarHorn"),
                    "Pelvis",
                    new Vector3(0.2499F, 0.13231F, -0.03964F),
                    new Vector3(331.2552F, 284.6252F, 86.06881F),
                    new Vector3(0.35F, 0.35F, 0.35F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EquipmentMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBattery"),
                    "Chest",
                    new Vector3(-0.0319F, -0.11096F, -0.09321F),
                    new Vector3(359.2515F, 88.51431F, 98.19724F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EquipmentMagazineVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFuelCellVoid"),
                    "Chest",
                    new Vector3(0.04648F, -0.11042F, -0.08784F),
                    new Vector3(8.22137F, 356.1381F, 90.40149F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExecuteLowHealthElite"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGuillotine"),
                    "ThighL",
                    new Vector3(0.14302F, 0.11044F, 0.01145F),
                    new Vector3(78.28942F, 217.458F, 324.143F),
                    new Vector3(0.23425F, 0.23425F, 0.23425F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExplodeOnDeath"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWilloWisp"),
                    "Chest",
                    new Vector3(0.27888F, -0.1854F, 0.00737F),
                    new Vector3(2.85769F, 359.4591F, 11.87494F),
                    new Vector3(0.10542F, 0.10542F, 0.10542F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExplodeOnDeathVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWillowWispVoid"),
                    "Chest",
                    new Vector3(0.2714F, -0.14995F, 0.00907F),
                    new Vector3(2.85769F, 359.459F, 11.87494F),
                    new Vector3(0.11938F, 0.11938F, 0.11938F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraLife"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippo"),
                    "Chest",
                    new Vector3(-0.22058F, 0.45386F, -0.05491F),
                    new Vector3(349.3331F, 337.7769F, 10.13284F),
                    new Vector3(0.1464F, 0.1464F, 0.1464F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraLifeVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippoVoid"),
                    "Chest",
                    new Vector3(-0.18824F, 0.45137F, -0.11074F),
                    new Vector3(346.1329F, 270.6207F, 7.90792F),
                    new Vector3(0.15503F, 0.15503F, 0.15503F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FallBoots"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "LeftLegMuzzle",
                    new Vector3(0.00169F, -0.01231F, 0.03811F),
                    new Vector3(60.92217F, 179.3294F, 357.576F),
                    new Vector3(0.19788F, 0.19788F, 0.19788F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "RightLegMuzzle",
                    new Vector3(0.00169F, -0.01231F, 0.03811F),
                    new Vector3(60.92215F, 179.3294F, 357.576F),
                    new Vector3(0.19788F, 0.19788F, 0.19788F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Feather"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFeather"),
                    "ShoulderL",
                    new Vector3(0.00261F, 0.13925F, -0.06885F),
                    new Vector3(343.9676F, 289.7533F, 78.50441F),
                    new Vector3(0.02F, 0.02F, 0.02F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireRing"],
                 ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireRing"),
                    "HandR",
                    new Vector3(0.0082F, 0.00239F, 0.00011F),
                    new Vector3(282.1854F, 270.6395F, 170.7254F),
                    new Vector3(0.54468F, 0.54468F, 0.54468F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireballsOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireballsOnHit"),
                    "Chest",
                    new Vector3(-0.00208F, 0.7996F, -0.03397F),
                    new Vector3(277.0211F, 352.1004F, 9.68095F),
                    new Vector3(0.07659F, 0.07659F, 0.07659F)
                    )
                ));

            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Firework"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFirework"),
                    "Pelvis",
                    new Vector3(0.20901F, 0.06879F, -0.05676F),
                    new Vector3(74.96593F, 260.3159F, 92.40174F),
                    new Vector3(0.18998F, 0.18998F, 0.18998F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FlatHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySteakCurved"),
                    "Chest",
                    new Vector3(-0.16712F, -0.08538F, 0.09708F),
                    new Vector3(333.4857F, 277.6298F, 126.9583F),
                    new Vector3(0.08683F, 0.08683F, 0.08683F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FocusConvergence"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFocusedConvergence"),
                    "Chest",
                    new Vector3(0.50878F, 0.88959F, -0.76309F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.06349F, 0.06349F, 0.06349F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FragileDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDelicateWatch"),
                    "HandR",
                    new Vector3(0F, 0.00001F, -0.00383F),
                    new Vector3(90F, 270F, 0F),
                    new Vector3(0.34198F, 0.5758F, 0.32066F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FreeChest"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShippingRequestForm"),
                    "ThighL",
                    new Vector3(0.14206F, 0.17922F, 0.04663F),
                    new Vector3(279.9932F, 19.45695F, 232.4752F),
                    new Vector3(0.62927F, 0.62927F, 0.62927F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GhostOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMask"),
                    "Head",
                    new Vector3(0.00161F, 0.17729F, 0.07384F),
                    new Vector3(355.7014F, 0F, 0F),
                    new Vector3(0.6F, 0.6F, 0.6F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBoneCrown"),
                    "Head",
                    new Vector3(0.0017F, 0.17584F, 0.00205F),
                    new Vector3(358.2061F, -0.00002F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldOnHurt"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRollOfPennies"),
                    "Chest",
                    new Vector3(-0.10036F, 0.24403F, 0.19746F),
                    new Vector3(46.39439F, 41.28191F, 322.0235F),
                    new Vector3(0.34955F, 0.34955F, 0.34955F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HalfAttackSpeedHalfCooldowns"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderNature"),
                    "UpperArmR",
                    new Vector3(-0.0301F, 0.0364F, -0.0664F),
                    new Vector3(357.7384F, 124.971F, 230.8443F),
                    new Vector3(0.69622F, 0.69622F, 0.69622F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HalfSpeedDoubleHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderStone"),
                    "UpperArmL",
                    new Vector3(0.07303F, 0.07266F, -0.046F),
                    new Vector3(355.9841F, 36.68033F, 217.1042F),
                    new Vector3(0.69622F, 0.69622F, 0.69622F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HeadHunter"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkullcrown"),
                    "Stomach",
                    new Vector3(0F, -0.00231F, 0.01621F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.45F, 0.2F, 0.09086F)
                    )
                ));

            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScythe"),
                    "Chest",
                    new Vector3(-0.01428F, 0.17565F, -0.15807F),
                    new Vector3(50.93688F, 83.69206F, 75.26823F),
                    new Vector3(0.38442F, 0.38442F, 0.38442F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealWhileSafe"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySnail"),
                    "Chest",
                    new Vector3(-0.20324F, -0.14697F, 0.1256F),
                    new Vector3(7.24479F, 129.7015F, 6.88009F),
                    new Vector3(0.05975F, 0.05975F, 0.05975F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealingPotion"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHealingPotion"),
                    "Chest",
                    new Vector3(0.13991F, -0.02051F, -0.0662F),
                    new Vector3(10.60892F, 323.2793F, 336.3398F),
                    new Vector3(0.05569F, 0.05569F, 0.05569F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Hoof"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHoof"),
                    "CalfR",
                    new Vector3(0.00287F, 0.49994F, -0.02991F),
                    new Vector3(76.21252F, 11.91886F, 16.56724F),
                    new Vector3(0.061F, 0.061F, 0.061F)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightCalf)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IceRing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIceRing"),
                    "HandL",
                    new Vector3(0.0082F, 0.00239F, 0.00011F),
                    new Vector3(282.1852F, 270.6395F, 170.725F),
                    new Vector3(0.54468F, 0.54468F, 0.54468F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Icicle"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFrostRelic"),
                    "Base",
                    new Vector3(-0.659F, 0.394F, -0.787F),
                    new Vector3(-0.0003F, 180.079F, 180.4018F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IgniteOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasoline"),
                    "Chest",
                    new Vector3(-0.03808F, 0.06082F, -0.14273F),
                    new Vector3(279.5221F, 181.8137F, 268.2113F),
                    new Vector3(0.75F, 0.75F, 0.75F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ImmuneToDebuff"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRainCoatBelt"),
                    "Chest",
                    new Vector3(0.00299F, -0.11393F, 0.07722F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IncreaseHealing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(-0.05811F, 0.27193F, 0.01875F),
                    new Vector3(0F, 90F, 180F),
                    new Vector3(-0.33047F, -0.33047F, -0.33047F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(0.06204F, 0.27535F, 0.02001F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.33047F, 0.33047F, 0.33047F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Incubator"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAncestralIncubator"),
                    "Chest",
                    new Vector3(0.2736F, -0.35517F, 0.03423F),
                    new Vector3(0F, 0F, 13.79489F),
                    new Vector3(0.03338F, 0.03338F, 0.03338F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Infusion"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInfusion"),
                    "Chest",
                    new Vector3(-0.13307F, 0.32729F, 0.14488F),
                    new Vector3(314.9149F, 348.2475F, 291.1531F),
                    new Vector3(0.27402F, 0.27402F, 0.27402F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["JumpBoost"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaxBird"),
                    "Head",
                    new Vector3(0F, -0.28084F, -0.26346F),
                    new Vector3(20.10192F, -0.00001F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["KillEliteFrenzy"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrainstalk"),
                    "Head",
                    new Vector3(0F, 0.22047F, 0.02458F),
                    new Vector3(8.13732F, -0.00003F, 0.00003F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Knurl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKnurl"),
                    "Chest",
                    new Vector3(0.25657F, -0.14036F, 0.00563F),
                    new Vector3(274.7333F, -0.00002F, 349.4195F),
                    new Vector3(0.08402F, 0.08402F, 0.08402F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LaserTurbine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserTurbine"),
                    "UpperArmL",
                    new Vector3(0.01391F, 0.04298F, -0.08303F),
                    new Vector3(358.4569F, 336.1057F, 3.22807F),
                    new Vector3(0.28394F, 0.28394F, 0.28394F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LightningStrikeOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayChargedPerforator"),
                    "Chest",
                    new Vector3(0F, 0.24924F, 0.13783F),
                    new Vector3(56.67709F, -0.00023F, 179.9998F),
                    new Vector3(1.39348F, 1.39348F, 1.39348F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarDagger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarDagger"),
                    "Chest",
                    new Vector3(0.03414F, 0.22879F, -0.18522F),
                    new Vector3(24.00754F, 268.8818F, 106.4685F),
                    new Vector3(0.58518F, 0.58518F, 0.58518F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarPrimaryReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdEye"),
                    "Head",
                    new Vector3(-0.00183F, 0.15902F, 0.11914F),
                    new Vector3(273.1185F, 198.608F, 158.0697F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarSecondaryReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdClaw"),
                    "Chest",
                    new Vector3(-0.16368F, 0.30821F, -0.09371F),
                    new Vector3(357.8297F, 321.7283F, 341.6811F),
                    new Vector3(0.59643F, 0.59643F, 0.59643F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarSpecialReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdHeart"),
                    "Base",
                    new Vector3(-1.072F, 0.931F, -0.757F),
                    new Vector3(7.40916F, 270.837F, 94.74821F),
                    new Vector3(0.34151F, 0.34151F, 0.34151F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarTrinket"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeads"),
                    "HandR",
                    new Vector3(-0.01139F, 0.1402F, 0.00034F),
                    new Vector3(8.04592F, 32.52031F, 286.5076F),
                    new Vector3(0.75225F, 0.75225F, 0.75225F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarUtilityReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdFoot"),
                    "Head",
                    new Vector3(0.00706F, 0.2841F, -0.08589F),
                    new Vector3(358.9657F, 85.64923F, 306.3941F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Medkit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMedkit"),
                    "Chest",
                    new Vector3(0.13903F, -0.09277F, -0.01158F),
                    new Vector3(291.3135F, 216.6488F, 271.4429F),
                    new Vector3(0.6F, 0.6F, 0.6F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MinorConstructOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDefenseNucleus"),
                    "Base",
                    new Vector3(0.73675F, 0.95619F, 1.10098F),
                    new Vector3(270F, 0.32262F, 0F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Missile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncher"),
                    "Chest",
                    new Vector3(-0.29146F, 0.58267F, -0.13946F),
                    new Vector3(347.5833F, 8.04755F, 24.89467F),
                    new Vector3(0.0861F, 0.0861F, 0.0861F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MissileVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncherVoid"),
                    "Chest",
                    new Vector3(-0.29146F, 0.58267F, -0.13946F),
                    new Vector3(347.5833F, 8.04755F, 24.89467F),
                    new Vector3(0.0861F, 0.0861F, 0.0861F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MonstersOnShrineUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMonstersOnShrineUse"),
                    "ThighR",
                    new Vector3(-0.0829F, 0.20082F, 0.10987F),
                    new Vector3(70.37606F, 59.50587F, 14.48756F),
                    new Vector3(0.05146F, 0.05146F, 0.05146F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MoreMissile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayICBM"),
                    "Chest",
                    new Vector3(-0.00377F, 0.10095F, -0.17138F),
                    new Vector3(43.40301F, 77.61505F, 342.1941F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MoveSpeedOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGrappleHook"),
                    "Pelvis",
                    new Vector3(0.18255F, -0.02507F, 0.02481F),
                    new Vector3(329.3344F, 225.73F, 187.7799F),
                    new Vector3(0.23818F, 0.23818F, 0.23818F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Mushroom"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroom"),
                    "ShoulderR",
                    new Vector3(0.0397F, 0.15221F, -0.06858F),
                    new Vector3(288.9477F, 55.59521F, 300.2047F),
                    new Vector3(0.075F, 0.075F, 0.075F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MushroomVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroomVoid"),
                    "ShoulderR",
                    new Vector3(0.0397F, 0.15221F, -0.06858F),
                    new Vector3(288.9477F, 55.59521F, 300.2047F),
                    new Vector3(0.075F, 0.075F, 0.075F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NearbyDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDiamond"),
                    "HandL",
                    new Vector3(0.08623F, 0.07702F, -0.00006F),
                    new Vector3(0F, 0F, 356.4876F),
                    new Vector3(0.1F, 0.1F, 0.1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NovaOnHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(0.03197F, 0.24684F, 0.00141F),
                    new Vector3(14.74238F, 180F, 9.84322F),
                    new Vector3(-0.8F, -0.8F, -0.8F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(-0.02929F, 0.25047F, -0.00104F),
                    new Vector3(357.8429F, 357.8336F, 186.076F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NovaOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayJellyGuts"),
                    "Head",
                    new Vector3(-0.03174F, 0.14282F, -0.0579F),
                    new Vector3(7.58213F, 356.8672F, 6.81687F),
                    new Vector3(0.15F, 0.15F, 0.15F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["OutOfCombatArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOddlyShapedOpal"),
                    "Base",
                    new Vector3(0.3029F, 0.0034F, -0.28644F),
                    new Vector3(3.40159F, 245.6042F, 270.0852F),
                    new Vector3(0.44379F, 0.44379F, 0.44379F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ParentEgg"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayParentEgg"),
                    "Chest",
                    new Vector3(0.15168F, 0.3255F, 0.14684F),
                    new Vector3(0F, 0F, 10.80585F),
                    new Vector3(0.06853F, 0.06853F, 0.06853F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Pearl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPearl"),
                    "LowerArmL",
                    new Vector3(0.00001F, 0.15093F, -0.00001F),
                    new Vector3(270F, 0F, 0F),
                    new Vector3(0.07F, 0.07F, 0.07F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PermanentDebuffOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScorpion"),
                    "UpperArmR",
                    new Vector3(0.40172F, 0.23208F, 0.24758F),
                    new Vector3(6.92331F, 321.7478F, 129.8595F),
                    new Vector3(0.7299F, 0.7299F, 0.7299F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PersonalShield"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldGenerator"),
                    "Chest",
                    new Vector3(0.00561F, 0.25008F, 0.1612F),
                    new Vector3(276.9266F, 181.0562F, 179.5026F),
                    new Vector3(0.19646F, 0.19646F, 0.19646F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Phasing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStealthkit"),
                    "Chest",
                    new Vector3(-0.0003F, 0.19641F, 0.20137F),
                    new Vector3(283.87F, 187.1017F, 172.0406F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Plant"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInterstellarDeskPlant"),
                    "Head",
                    new Vector3(0F, 0.3574F, 0.02561F),
                    new Vector3(270F, 0F, 0F),
                    new Vector3(0.07318F, 0.07318F, 0.07318F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PrimarySkillShuriken"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShuriken"),
                    "HandL",
                    new Vector3(0.06945F, 0.12256F, -0.00042F),
                    new Vector3(5.48174F, 89.06695F, 354.9421F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShuriken"),
                    "HandR",
                    new Vector3(-0.06861F, 0.13584F, -0.00268F),
                    new Vector3(5.48174F, 89.06694F, 354.9421F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomDamageZone"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRandomDamageZone"),
                    "HandR",
                    new Vector3(-0.06699F, 0.06489F, -0.01583F),
                    new Vector3(8.51908F, 86.9767F, 258.3855F),
                    new Vector3(0.03F, 0.03F, 0.03F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomEquipmentTrigger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBottledChaos"),
                    "Base",
                    new Vector3(0.25024F, 0.11146F, -0.14331F),
                    new Vector3(349.7761F, 81.03706F, 91.60354F),
                    new Vector3(0.22944F, 0.22944F, 0.22944F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomlyLunar"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDomino"),
                    "Base",
                    new Vector3(0.52899F, -0.91221F, 0.9409F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RegeneratingScrap"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRegeneratingScrap"),
                    "Base",
                    new Vector3(-0.3427F, 0.14125F, -0.00136F),
                    new Vector3(356.7812F, 276.3944F, 265.1483F),
                    new Vector3(0.21911F, 0.21911F, 0.21911F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RepeatHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCorpseflower"),
                    "Chest",
                    new Vector3(0.00698F, 0.18602F, 0.15103F),
                    new Vector3(72.07514F, 2.08503F, 0.70319F),
                    new Vector3(0.44177F, 0.44177F, 0.44177F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SecondarySkillMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                    "Head",
                    new Vector3(0.00035F, 0.04584F, -0.14374F),
                    new Vector3(48.7375F, 3.91532F, 5.20242F),
                    new Vector3(0.05F, 0.05F, 0.05F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Seed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySeed"),
                    "Chest",
                    new Vector3(-0.15906F, -0.0129F, 0.1785F),
                    new Vector3(335.8303F, 287.7627F, 12.86907F),
                    new Vector3(0.04447F, 0.04447F, 0.04447F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShieldOnly"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(-0.07012F, 0.29556F, 0.07925F),
                    new Vector3(-0.00001F, 270F, 180F),
                    new Vector3(-0.2F, -0.2F, -0.2F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(0.07012F, 0.29163F, 0.07911F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShinyPearl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShinyPearl"),
                    "LowerArmR",
                    new Vector3(0F, 0.14627F, 0F),
                    new Vector3(270F, 0F, 0F),
                    new Vector3(0.07F, 0.07F, 0.07F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShockNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeslaCoil"),
                    "Chest",
                    new Vector3(0F, 0.28457F, -0.13087F),
                    new Vector3(270F, 0F, 0F),
                    new Vector3(0.53835F, 0.53835F, 0.53835F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SiphonOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySiphonOnLowHealth"),
                    "Base",
                    new Vector3(0.29801F, 0.15162F, -0.32532F),
                    new Vector3(334.8931F, 90.00002F, 89.99997F),
                    new Vector3(0.09927F, 0.09927F, 0.09927F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SlowOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBauble"),
                    "ThighR",
                    new Vector3(-0.10888F, 0.51713F, 0.28689F),
                    new Vector3(358.8084F, 112.663F, 182.8512F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SlowOnHitVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBaubleVoid"),
                    "ThighR",
                    new Vector3(-0.10888F, 0.51713F, 0.28689F),
                    new Vector3(358.8084F, 112.663F, 182.8512F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBuckler"),
                    "LowerArmL",
                    new Vector3(-0.00162F, 0.19126F, 0.05183F),
                    new Vector3(0F, 0.95302F, 0F),
                    new Vector3(0.25F, 0.25F, 0.25F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySoda"),
                    "Base",
                    new Vector3(-0.18967F, 0.00851F, 0.01389F),
                    new Vector3(0F, 19.63885F, 0F),
                    new Vector3(0.28406F, 0.28406F, 0.28406F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintOutOfCombat"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWhip"),
                    "ThighL",
                    new Vector3(0.10968F, 0.16505F, 0.01777F),
                    new Vector3(0F, 155.2993F, 182.6342F),
                    new Vector3(0.49425F, 0.49425F, 0.49425F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintWisp"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrokenMask"),
                    "UpperArmL",
                    new Vector3(0.06376F, 0.05978F, -0.03774F),
                    new Vector3(8.23342F, 134.366F, 193.3722F),
                    new Vector3(0.25F, 0.25F, 0.25F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Squid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySquidTurret"),
                    "ThighR",
                    new Vector3(-0.0362F, 0.16265F, -0.09384F),
                    new Vector3(288.2866F, 13.30656F, 2.51238F),
                    new Vector3(0.05F, 0.05F, 0.05F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StickyBomb"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStickyBomb"),
                    "ThighL",
                    new Vector3(0.159F, 0.18236F, 0.01305F),
                    new Vector3(6.83458F, 6.25651F, 186.0579F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StrengthenBurn"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasTank"),
                    "CalfL",
                    new Vector3(-0.16489F, 0.16676F, -0.00392F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.24F, 0.24F, 0.24F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StunChanceOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStunGrenade"),
                    "Pelvis",
                    new Vector3(-0.17483F, -0.00225F, 0.01479F),
                    new Vector3(55.42948F, 120.6572F, 179.1134F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Syringe"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySyringeCluster"),
                    "ThighR",
                    new Vector3(-0.07448F, 0.14176F, 0.01707F),
                    new Vector3(349.752F, 206.5508F, 243.8433F),
                    new Vector3(0.21584F, 0.21584F, 0.21584F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TPHealingNova"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlowFlower"),
                    "Chest",
                    new Vector3(0.10632F, 0.34855F, 0.09456F),
                    new Vector3(318.4038F, 0F, 342.7366F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Talisman"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTalisman"),
                    "Base",
                    new Vector3(0.65799F, -1.09896F, 1.10461F),
                    new Vector3(87.90875F, 0.00038F, 0.32302F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Thorns"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRazorwireLeft"),
                    "Chest",
                    new Vector3(2, 2, 2),
                    new Vector3(0, 0, 0),
                    new Vector3(1, 1, 1)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TitanGoldDuringTP"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldHeart"),
                    "Base",
                    new Vector3(0.22382F, -0.02173F, -0.00004F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.18704F, 0.18704F, 0.18704F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Tooth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothNecklaceDecal"),
                    "Chest",
                    new Vector3(0F, 0.45338F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                    "Chest",
                    new Vector3(0F, 0.29659F, 0.16196F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(2F, 2F, 2F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                    "Chest",
                    new Vector3(0.04753F, 0.32086F, 0.13925F),
                    new Vector3(0F, 0F, 47.25098F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                    "Chest",
                    new Vector3(-0.04753F, 0.32086F, 0.13925F),
                    new Vector3(0F, 0F, 312.749F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                    "Chest",
                    new Vector3(-0.08835F, 0.35908F, 0.11049F),
                    new Vector3(355.488F, 336.5051F, 311.2128F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                    "Chest",
                    new Vector3(0.08835F, 0.35908F, 0.11049F),
                    new Vector3(333.3396F, 25.68828F, 43.92077F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TreasureCache"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKey"),
                    "Base",
                    new Vector3(0.04375F, -0.14263F, 0.019F),
                    new Vector3(14.68406F, 268.1919F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TreasureCacheVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKeyVoid"),
                    "Base",
                    new Vector3(0.04375F, -0.14263F, 0.019F),
                    new Vector3(14.68406F, 268.1919F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["UtilitySkillMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "UpperArmL",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(27.90346F, 134.9909F, 95.18579F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "UpperArmR",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(38.3644F, 193.0413F, 225.9187F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["VoidMegaCrabItem"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMegaCrabItem"),
                    "Pelvis",
                    new Vector3(-0.01028F, 0.13059F, -0.14611F),
                    new Vector3(4.50174F, 180.5975F, 180.0469F),
                    new Vector3(0.14306F, 0.14306F, 0.14306F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["WarCryOnMultiKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPauldron"),
                    "UpperArmL",
                    new Vector3(0.06998F, 0.06659F, -0.04845F),
                    new Vector3(70.50645F, 116.4982F, 341.8174F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["WardOnLevel"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarbanner"),
                    "Chest",
                    new Vector3(-0.02672F, -0.17388F, -0.05571F),
                    new Vector3(270F, 270F, 0F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BFG"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBFG"),
                    "Chest",
                    new Vector3(0.10379F, 0.34969F, -0.00221F),
                    new Vector3(320.1385F, 2.49748F, 309.7993F),
                    new Vector3(0.29733F, 0.29733F, 0.29733F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Blackhole"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravCube"),
                    "Base",
                    new Vector3(-0.65985F, 0.04181F, 0.77701F),
                    new Vector3(270F, 0.32262F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossHunter"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornGhost"),
                    "Head",
                    new Vector3(0F, 0.28803F, -0.05475F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBlunderbuss"),
                    "Base",
                    new Vector3(0.98663F, -0.45197F, 0.38909F),
                    new Vector3(0.30344F, 184.4128F, 181.5068F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossHunterConsumed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornUsed"),
                    "Head",
                    new Vector3(0F, 0.28803F, -0.05475F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BurnNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPotion"),
                    "Base",
                    new Vector3(0.1436F, 0.21409F, -0.01811F),
                    new Vector3(330.4779F, 83.02779F, 75.05534F),
                    new Vector3(0.05F, 0.05F, 0.05F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Cleanse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaterPack"),
                    "Chest",
                    new Vector3(0F, -0.00227F, -0.13666F),
                    new Vector3(6.74809F, 183.046F, 1.31122F),
                    new Vector3(0.175F, 0.175F, 0.175F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CommandMissile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileRack"),
                    "Chest",
                    new Vector3(-0.00286F, 0.36246F, -0.20178F),
                    new Vector3(90F, 174.2094F, 0F),
                    new Vector3(0.5F, 0.5F, 0.5F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CrippleWard"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEffigy"),
                    "Head",
                    new Vector3(0.00488F, 0.03777F, -0.17672F),
                    new Vector3(347.1897F, 180F, 0F),
                    new Vector3(0.55447F, 0.55447F, 0.55447F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritOnUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayNeuralImplant"),
                    "Head",
                    new Vector3(0F, 0.20967F, 0.37532F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.43383F, 0.43383F, 0.43383F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DeathProjectile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathProjectile"),
                    "Chest",
                    new Vector3(0.14234F, -0.21507F, -0.18946F),
                    new Vector3(5.92411F, 169.7061F, 342.7529F),
                    new Vector3(0.15F, 0.15F, 0.15F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DroneBackup"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRadio"),
                    "Chest",
                    new Vector3(0.14328F, -0.11181F, -0.0049F),
                    new Vector3(344.2375F, 121.3032F, 340.4598F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteEarthEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteMendingAntlers"),
                    "Head",
                    new Vector3(0F, 0.26789F, -0.07551F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.6377F, 0.6377F, 0.6377F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteFireEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(-0.07218F, 0.24505F, 0.10534F),
                    new Vector3(351.1953F, 179.286F, 149.4119F),
                    new Vector3(-0.06753F, -0.06753F, -0.06753F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(0.0596F, 0.24586F, 0.10536F),
                    new Vector3(11.89723F, 0.55079F, 326.5483F),
                    new Vector3(0.06753F, 0.06753F, 0.06753F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteHauntedEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteStealthCrown"),
                    "Head",
                    new Vector3(0F, 0.23989F, -0.00176F),
                    new Vector3(90F, 180F, 0F),
                    new Vector3(0.04F, 0.04F, 0.04F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteIceEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteIceCrown"),
                    "Head",
                    new Vector3(0F, 0.31166F, -0.00309F),
                    new Vector3(277.5701F, 179.9999F, 180.0001F),
                    new Vector3(0.025F, 0.025F, 0.025F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteLightningEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(-0.00345F, 0.26332F, 0.07376F),
                    new Vector3(325.0977F, 4.03581F, 352.0529F),
                    new Vector3(0.16F, 0.16F, 0.16F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(-0.00195F, 0.24449F, 0.15188F),
                    new Vector3(314.2533F, 357.8721F, 358.271F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteLunarEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteLunar,Eye"),
                    "Head",
                    new Vector3(0F, 0.12912F, 0.23751F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.16167F, 0.16167F, 0.16167F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ElitePoisonEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteUrchinCrown"),
                    "Head",
                    new Vector3(0F, 0.23766F, 0.00045F),
                    new Vector3(270.4006F, 359.9874F, 0.01282F),
                    new Vector3(0.04F, 0.04F, 0.04F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteVoidEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAffixVoid"),
                    "Head",
                    new Vector3(0F, 0.18373F, 0.07523F),
                    new Vector3(281.1483F, 0.00006F, 180F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireBallDash"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEgg"),
                    "Chest",
                    new Vector3(0.21708F, -0.21853F, 0.26624F),
                    new Vector3(307.646F, 208.5567F, 158.0741F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Fruit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFruit"),
                    "Base",
                    new Vector3(-0.0631F, -0.17773F, 0.04752F),
                    new Vector3(39.53217F, 86.46424F, 84.4554F),
                    new Vector3(0.3509F, 0.3509F, 0.3509F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GainArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElephantFigure"),
                    "CalfL",
                    new Vector3(-0.21334F, 0.2582F, 0.03092F),
                    new Vector3(71.80514F, 356.8267F, 87.97798F),
                    new Vector3(0.8F, 0.8F, 0.8F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Gateway"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVase"),
                    "Chest",
                    new Vector3(0.00304F, 0.18562F, -0.21785F),
                    new Vector3(90F, 180F, 0F),
                    new Vector3(0.22015F, 0.22015F, 0.22015F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldGat"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldGat"),
                    "Chest",
                    new Vector3(0.29504F, 0.44144F, -0.38593F),
                    new Vector3(29.91891F, 84.32085F, 301.3222F),
                    new Vector3(0.15F, 0.15F, 0.15F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GummyClone"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGummyClone"),
                    "CalfR",
                    new Vector3(0.00362F, 0.58742F, 0.01685F),
                    new Vector3(13.64345F, 125.9495F, 0F),
                    new Vector3(0.20012F, 0.20012F, 0.20012F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IrradiatingLaser"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIrradiatingLaser"),
                    "Chest",
                    new Vector3(-0.1507F, 0.30441F, -0.0779F),
                    new Vector3(326.7607F, 345.5274F, 30.32052F),
                    new Vector3(0.172F, 0.172F, 0.172F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Jetpack"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBugWings"),
                    "Chest",
                    new Vector3(0F, 0.2132F, -0.04201F),
                    new Vector3(322.8122F, -0.00011F, 0.00001F),
                    new Vector3(0.14742F, 0.14742F, 0.14742F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LifestealOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLifestealOnHit"),
                   "Stomach",
                    new Vector3(-0.23453F, 0.03533F, 0.01059F),
                    new Vector3(336.5651F, 95.35621F, 264.4277F),
                    new Vector3(0.08F, 0.08F, 0.08F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Lightning"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLightningArmRight"),
                    "Chest",
                    new Vector3(2, 2, 2),
                    new Vector3(0, 0, 0),
                    new Vector3(1, 1, 1)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightArm)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarPortalOnUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarPortalOnUse"),
                    "Base",
                    new Vector3(0.49698F, 0.26002F, 0.7488F),
                    new Vector3(78.08119F, 55.41177F, 57.52744F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Meteor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMeteor"),
                    "Base",
                    new Vector3(-0.74222F, 0.26422F, 0.76691F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.68939F, 0.68939F, 0.68939F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Molotov"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMolotov"),
                    "ThighL",
                    new Vector3(0.14551F, 0.07678F, -0.00225F),
                    new Vector3(18.15746F, 209.6198F, 183.9065F),
                    new Vector3(0.25F, 0.25F, 0.25F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MultiShopCard"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayExecutiveCard"),
                    "Chest",
                    new Vector3(0.13193F, 0.28226F, 0.13035F),
                    new Vector3(6.464F, 104.1467F, 72.63767F),
                    new Vector3(0.50539F, 0.50539F, 0.50539F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["QuestVolatileBattery"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBatteryArray"),
                    "Chest",
                    new Vector3(0F, 0.14276F, -0.25852F),
                    new Vector3(349.381F, -0.00018F, 0.00008F),
                    new Vector3(0.4F, 0.4F, 0.4F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Recycle"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRecycler"),
                    "Chest",
                    new Vector3(0.002F, -0.14767F, -0.10352F),
                    new Vector3(359.7892F, 89.4603F, 338.6458F),
                    new Vector3(0.1F, 0.1F, 0.1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Saw"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySawmerangFollower"),
                    "Base",
                    new Vector3(-0.78475F, 0.20096F, 0.92172F),
                    new Vector3(359.868F, 179.6774F, 180.0007F),
                    new Vector3(0.15F, 0.15F, 0.15F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Scanner"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScanner"),
                    "UpperArmL",
                    new Vector3(0.02278F, 0.17024F, -0.03086F),
                    new Vector3(17.07704F, 153.0925F, 264.0455F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TeamWarCry"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeamWarCry"),
                    "Base",
                    new Vector3(0.13847F, -0.17778F, 0.00823F),
                    new Vector3(60.78023F, 108.2805F, 107.0431F),
                    new Vector3(0.06962F, 0.06962F, 0.06962F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Tonic"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTonic"),
                    "ThighL",
                    new Vector3(0.11612F, 0.07004F, -0.04802F),
                    new Vector3(1.52979F, 93.40291F, 164.4546F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["VendingMachine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVendingMachine"),
                    "Pelvis",
                    new Vector3(0.16892F, -0.03141F, -0.02793F),
                    new Vector3(309.1987F, 113.6312F, 256.3498F),
                    new Vector3(0.2F, 0.2F, 0.2F)
                    )
                ));
        }
    }
}