using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Ambidextrous : BaseSkillState
    {
        public static float maxAngle = 40f;
        public static float maxDistance = 80f;

        private RightHandTracker rightHandTracker;
        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Death;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            rightHandTracker = GetComponent<RightHandTracker>();
            rightHandTracker.enabled = false;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority)
            {
                DetermineTargetRemoval();
                if (rightHandTracker.trackingTarget == null)
                {
                    rightHandTracker.enabled = true;

                    rightHandTracker.TrackTarget();
                }
                else
                {
                    rightHandTracker.enabled = true;
                }

                if (base.inputBank.skill2.justReleased)
                {
                    this.outer.SetNextStateToMain();
                    return;
                }
            }
        }

        public override void OnExit()
        {
            if (rightHandTracker != null)
            {
                rightHandTracker.enabled = false;
                rightHandTracker.trackingTarget = null;
            }

            base.OnExit();
        }

        private void DetermineTargetRemoval()
        {
            // TODO: Remove target if line of sight is cut off or distance is too far
            if (rightHandTracker.trackingTarget != null) {
                HurtBox hurtBox = rightHandTracker.trackingTarget;
                if (!hurtBox.healthComponent || !hurtBox.healthComponent.alive)
                {
                    rightHandTracker.trackingTarget = null;
                }
            }
            else
            {
                rightHandTracker.enabled = false;
            }
        }
    }
}
