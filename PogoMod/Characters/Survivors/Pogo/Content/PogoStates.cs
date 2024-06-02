﻿using PogoMod.Survivors.Pogo.SkillStates;

namespace PogoMod.Survivors.Pogo
{
    public static class PogoStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(SlashCombo));

            Modules.Content.AddEntityState(typeof(Shoot));

            Modules.Content.AddEntityState(typeof(Roll));

            Modules.Content.AddEntityState(typeof(ThrowBomb));
        }
    }
}
