using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Ambidextrous : BaseSkillState
    {
        private RightHandTracker rightHandTracker;
        private HurtBox target;

        public override void OnEnter()
        {
            base.OnEnter();

            rightHandTracker = GetComponent<RightHandTracker>();
            rightHandTracker.enabled = true;
            target = rightHandTracker.GetTrackingTarget();
        }

        public override void OnExit()
        {
            base.OnExit();

            rightHandTracker.enabled = false;
        }
    }
}
