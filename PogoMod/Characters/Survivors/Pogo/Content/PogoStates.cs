using PogoMod.Modules.BaseContent.BaseStates;
using PogoMod.Survivors.Pogo.SkillStates;

namespace PogoMod.Survivors.Pogo
{
    public static class PogoStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(MainState));
            Modules.Content.AddEntityState(typeof(BasePogoState));
            Modules.Content.AddEntityState(typeof(BasePogoSkillState));
            Modules.Content.AddEntityState(typeof(Fingergun));
            Modules.Content.AddEntityState(typeof(MeleeCombo));
            Modules.Content.AddEntityState(typeof(PogoJump));

            Modules.Content.AddEntityState(typeof(RightFingergun));

            Modules.Content.AddEntityState(typeof(Dropkick));
            Modules.Content.AddEntityState(typeof(Boomkick));

            Modules.Content.AddEntityState(typeof(PowerSurge));
        }
    }
}
