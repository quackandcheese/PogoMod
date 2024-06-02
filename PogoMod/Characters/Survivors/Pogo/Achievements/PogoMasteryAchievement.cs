using RoR2;
using PogoMod.Modules.Achievements;

namespace PogoMod.Survivors.Pogo.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, null)]
    public class PogoMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = PogoSurvivor.POGO_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = PogoSurvivor.POGO_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => PogoSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}