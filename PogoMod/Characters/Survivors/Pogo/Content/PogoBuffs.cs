using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo
{
    public static class PogoBuffs
    {
        // armor buff gained during roll
        public static BuffDef armorBuff;
        public static BuffDef pogoPogoBuff;

        public static void Init(AssetBundle assetBundle)
        {
            armorBuff = Modules.Content.CreateAndAddBuff("HenryArmorBuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
                Color.white,
                false,
                false);
            pogoPogoBuff = Modules.Content.CreateAndAddBuff("PogoBuff", assetBundle.LoadAsset<Sprite>("texPogostickIcon"),
                PogoAssets.pogoColor, true, false);
        }
    }
}
