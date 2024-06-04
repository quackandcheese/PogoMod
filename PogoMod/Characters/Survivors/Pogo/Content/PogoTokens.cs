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
            string outroFailure = "..and so she vanished, unable to spring back.";
            string lore = "PLACEHOLDER";

            Language.Add(prefix + "NAME", "Pogo");
            Language.Add(prefix + "SUBTITLE", "Cybernetic Piston");

            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "LORE", lore);
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_NAME", "Pogostick");
            // Not putting it in the description, but when fall damage would have been taken, the jump "combo" is auto-set to max and maximum height is reached immediately.
            Language.Add(prefix + "PASSIVE_DESCRIPTION", "Jump as you hit the ground to <style=cIsUtility>jump higher and further</style>. Height and speed maxes out after 3 consecutive successful <style=cIsUtility>pogos</style>. A successful <style=cIsUtility>pogo</style> negates fall damage and <style=cIsDamage>stuns/deals damage</style> to an enemy if they are landed on.");
            #endregion

            #region Primary
            Language.Add(prefix + "PRIMARY_LEFTFINGERGUN_NAME", "Lefty");
            Language.Add(prefix + "PRIMARY_FINGERGUN_DESCRIPTION", Tokens.agilePrefix + $" Lock onto a target and shoot them for <style=cIsDamage>{100f * PogoStaticValues.fingergunDamageCoefficient}% damage</style> per bullet. You can still <style=cIsDamage>look around use other abilities while enemy is targeted</style>.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_RIGHTFINGERGUN_NAME", "Righty");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_BOOMSTICK_NAME", "Blast Off");
            Language.Add(prefix + "UTILITY_BOOMSTICK_DESCRIPTION", $"Charge up an <style=cIsDamage>explosive</style> shotgun blast from both legs downwards that <style=cIsUtility>launches you up upwards</style> and deals <style=cIsDamage>9x{100f * PogoStaticValues.shotgunDamageCoefficient}%-{100f * PogoStaticValues.shotgunDamageCoefficientMax}% damage</style> to enemies underneath.");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_KICK_NAME", "Kickback Flip");
            Language.Add(prefix + "SPECIAL_KICK_DESCRIPTION", $"Perform a <style=cIsUtility>backflip</style> and fire explosive shotgun shells out of each leg mid-air at aimed location for <style=cIsDamage>9x{100f * PogoStaticValues.shotgunDamageCoefficient}% damage</style>.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(PogoMasteryAchievement.identifier), "Pogo: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(PogoMasteryAchievement.identifier), "As Pogo, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
