using EntityStates;
using PogoMod.Modules.BaseContent.BaseStates;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class BlastOff : BasePogoSkillState
    {
        public static float speedCoefficientOnExit = 0.5f;

        public static float baseDuration = 0.5f;
        protected float duration;

        public float charge;

        public float minLaunchSpeed = 20;
        public float maxLaunchSpeed = 90;

        public float minDuration = 0.3f;
        public float maxDuration = 0.5f;

        protected Vector3 launchVelocity;
        public float launchSpeed { get; private set; }

        public override void OnEnter()
        {
            base.OnEnter();

            duration = Mathf.Lerp(minDuration, maxDuration, charge);

            if (base.isAuthority)
            {
                base.characterMotor.Motor.ForceUnground();
                launchVelocity = CalculateLaunchVelocity(base.characterMotor.velocity, GetAimRay().direction, charge, minLaunchSpeed, maxLaunchSpeed);
                base.characterMotor.velocity = launchVelocity;
                base.characterDirection.forward = base.characterMotor.velocity.normalized;
                launchSpeed = base.characterMotor.velocity.magnitude;
            }
        }

        public static Vector3 CalculateLaunchVelocity(Vector3 currentVelocity, Vector3 aimDirection, float charge, float minLungeSpeed, float maxLungeSpeed)
        {
            currentVelocity = ((Vector3.Dot(currentVelocity, aimDirection) < 0f) ? Vector3.zero : Vector3.Project(currentVelocity, aimDirection));
            return currentVelocity + aimDirection * Mathf.Lerp(minLungeSpeed, maxLungeSpeed, charge);
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
