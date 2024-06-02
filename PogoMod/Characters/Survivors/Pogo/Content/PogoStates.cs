using PogoMod.Survivors.Pogo.SkillStates;

namespace PogoMod.Survivors.Pogo
{
    public static class PogoStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(Fingerguns));

            Modules.Content.AddEntityState(typeof(Ambidextrous));

            Modules.Content.AddEntityState(typeof(Roll));

            Modules.Content.AddEntityState(typeof(ThrowBomb));
        }
    }
}
