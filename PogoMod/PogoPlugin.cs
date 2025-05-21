using BepInEx;
using PogoMod.Survivors.Pogo;
using R2API.Utils;
using RoR2;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using ShaderSwapper;
using PogoMod.Modules;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace PogoMod
{
    //[BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    public class PogoPlugin : BaseUnityPlugin
    {
        public const string MODUID = "com.QuackAndCheese.PogoMod";
        public const string MODNAME = "PogoMod";
        public const string MODVERSION = "1.0.0";

        public const string DEVELOPER_PREFIX = "QUACKANDCHEESE";

        public static PogoPlugin instance;
        internal static BepInEx.Logging.ManualLogSource logger;

        void Awake()
        {
            instance = this;
            logger = Logger;

            Log.Init(Logger);

            // used when you want to properly set up language folders
            Modules.Language.Init();

            PogoAssets.Init(Asset.LoadAssetBundle("pogobundle"));
            StartCoroutine(PogoAssets.mainAssetBundle.UpgradeStubbedShadersAsync());

            new PogoSurvivor().Initialize();

            // make a content pack and add it. this has to be last
            new Modules.ContentPacks().Initialize();
        }
    }
}
