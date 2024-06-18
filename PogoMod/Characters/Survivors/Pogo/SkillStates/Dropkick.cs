using EntityStates;
using PogoMod.Modules.BaseContent.BaseStates;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Dropkick : BasePogoSkillState
    {
        public static float baseDuration = 0.3f;
        public static float launchSpeed = 30f;
        public static float speedCoefficientOnExit = 0.64f;

        protected float duration;

        protected Vector3 launchVelocity;

        public override void OnEnter()
        {
            base.OnEnter();

            duration = baseDuration;

            if (base.isAuthority)
            {
                base.characterMotor.Motor.ForceUnground();
                launchVelocity = CalculateLaunchVelocity(base.characterMotor.velocity, GetAimRay().direction);
                base.characterMotor.velocity = launchVelocity;
                base.characterDirection.forward = base.characterMotor.velocity.normalized;
            }
        }

        public static Vector3 CalculateLaunchVelocity(Vector3 currentVelocity, Vector3 aimDirection)
        {
            currentVelocity = ((Vector3.Dot(currentVelocity, aimDirection) < 0f) ? Vector3.zero : Vector3.Project(currentVelocity, aimDirection));
            return currentVelocity + aimDirection * launchSpeed;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (isAuthority)
            {
                base.characterMotor.velocity = launchVelocity;
                base.characterDirection.forward = launchVelocity;
                base.characterBody.isSprinting = true;

                if (fixedAge >= duration)
                {
                    outer.SetNextStateToMain();
                    return;
                }
            }
        }
        public override void OnExit()
        {
            base.OnExit();
            base.characterMotor.velocity *= speedCoefficientOnExit;
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}
