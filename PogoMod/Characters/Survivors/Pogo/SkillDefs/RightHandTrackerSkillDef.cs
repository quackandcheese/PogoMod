using PogoMod.Characters.Survivors.Pogo.Components;
using RoR2;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace PogoMod.Characters.Survivors.Pogo.SkillDefs
{
    public class RightHandTrackerSkillDef : SkillDef
    {
        public override BaseSkillInstanceData OnAssigned([NotNull] GenericSkill skillSlot)
        {
            return new InstanceData
            {
                rightHandTracker = skillSlot.GetComponent<RightHandTracker>()
            };
        }

        private static bool HasTarget([NotNull] GenericSkill skillSlot)
        {
            RightHandTracker rightHandTracker = ((InstanceData)skillSlot.skillInstanceData).rightHandTracker;
            return (rightHandTracker != null) ? rightHandTracker.GetTrackingTarget() : null;
        }

        public override bool CanExecute([NotNull] GenericSkill skillSlot)
        {
            return HasTarget(skillSlot) && base.CanExecute(skillSlot);
        }

        public override bool IsReady([NotNull] GenericSkill skillSlot)
        {
            return base.IsReady(skillSlot) && HasTarget(skillSlot);
        }

        protected class InstanceData : BaseSkillInstanceData
        {
            public RightHandTracker rightHandTracker;
        }
    }
}
