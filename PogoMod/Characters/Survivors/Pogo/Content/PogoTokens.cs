using System;
using PogoMod.Modules;
using PogoMod.Survivors.Pogo.Achievements;

namespace PogoMod.Survivors.Pogo
{
    public static class PogoTokens
    {
        public static void Init()
        {
            AddPogoTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Pogo.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddPogoTokens()
        {
            string prefix = PogoSurvivor.POGO_PREFIX;

            string desc = "Pogo is a fast-paced cyborg combatant focused on verticality and movement, wielding cybernetic fingerguns and shotgun-pogosticks for legs.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > Sword is a good all-rounder while Boxing Gloves are better for laying a beatdown on more powerful foes." + Environment.NewLine + Environment.NewLine
             + "< ! > Pistol is a powerful anti air, with its low cooldown and high damage." + Environment.NewLine + Environment.NewLine
             + "< ! > Roll has a lingering armor buff that helps to use it aggressively." + Environment.NewLine + Environment.NewLine
             + "< ! > Bomb can be used to wipe crowds with ease." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so she left, taking one giant leap for mankind.";
            string outroFailure = "..and so she vanished, as her luck ran out.";

            Language.Add(prefix + "NAME", "Pogo");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "Cybernetic Piston");
            Language.Add(prefix + "LORE", "sample lore");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_NAME", "Spring");
            Language.Add(prefix + "PASSIVE_DESCRIPTION", "Jumping as you land increases the height of the jump. Jumps can be charged for extra height and can be redirected.");
            #endregion

            #region Primary
            Language.Add(prefix + "PRIMARY_FINGERGUNS_NAME", "Fingerguns");
            Language.Add(prefix + "PRIMARY_FINGERGUNS_DESCRIPTION", Tokens.agilePrefix + $"Fire both fingerguns for <style=cIsDamage>{100f * PogoStaticValues.fingergunDamageCoefficient}% damage</style> each.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_AMBIDEXTROUS_NAME", "Ambidextrous");
            Language.Add(prefix + "SECONDARY_AMBIDEXTROUS_DESCRIPTION", Tokens.agilePrefix + $"Hold to lock onto a target. Right fingergun will shoot targeted enemy when primary is used.");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_BOOMSTICK_NAME", "Pogo-Boomstick");
            Language.Add(prefix + "UTILITY_BOOMSTICK_DESCRIPTION", $"Shoot from both legs downwards, boosting you upwards and dealing <style=cIsDamage>8x{100f * PogoStaticValues.shotgunDamageCoefficient}% damage</style> to enemies underneath.");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_KICK_NAME", "Kick");
            Language.Add(prefix + "SPECIAL_KICK_DESCRIPTION", $"Kick forward, dealing <style=cIsDamage>{100f * PogoStaticValues.kickDamageCoefficient}% damage</style>. Utility can be activated during kick to blast a shotgun shot forwards for <style=cIsDamage>{100f * PogoStaticValues.shotgunDamageCoefficient}% damage</style>.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(PogoMasteryAchievement.identifier), "Pogo: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(PogoMasteryAchievement.identifier), "As Pogo, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
