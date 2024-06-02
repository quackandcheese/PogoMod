using PogoMod.Survivors.Pogo.Achievements;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo
{
    public static class PogoUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                PogoMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(PogoMasteryAchievement.identifier),
                PogoSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
