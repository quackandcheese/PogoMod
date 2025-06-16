using EntityStates;
using PogoMod.Modules.BaseContent.BaseStates;
using PogoMod.Modules.BaseStates;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Dropkick : BasicMeleeAttack
    {
        public static float launchSpeed = 30f;
        public static float speedCoefficientOnExit = 0.4f;

        protected Vector3 launchVelocity;
        private float bonusDamage = 0f;
        private float kickForce = 500f;

        public override void OnEnter()
        {
            this.damageCoefficient = PogoStaticValues.kickDamageCoefficient;
            this.pushAwayForce = 1200f;
            this.hitPauseDuration = 0.1f;
            this.hitBoxGroupName = "KickHitboxGroup";

            base.OnEnter();

            if (base.isAuthority)
            {
                base.gameObject.layer = LayerIndex.fakeActor.intVal;
                base.characterMotor.Motor.RebuildCollidableLayers();
                base.characterMotor.Motor.ForceUnground();
                launchVelocity = CalculateLaunchVelocity(base.characterMotor.velocity, GetAimRay().direction);
                base.characterMotor.velocity = launchVelocity;
                base.characterDirection.forward = base.characterMotor.velocity.normalized;
            }
        }

        public override float CalcDuration()
        {
            return 0.45f;
        }

        public override void PlayAnimation()
        {
            base.PlayAnimation();
            base.PlayCrossfade("FullBody, Override", "Dropkick", "Dropkick.playbackRate", this.duration, 0.075f);
        }

        public static Vector3 CalculateLaunchVelocity(Vector3 currentVelocity, Vector3 aimDirection)
        {
            currentVelocity = ((Vector3.Dot(currentVelocity, aimDirection) < 0f) ? Vector3.zero : Vector3.Project(currentVelocity, aimDirection));
            return currentVelocity + aimDirection * launchSpeed;
        }

        public override void AuthorityFixedUpdate()
        {
            base.AuthorityFixedUpdate();

            if (!authorityInHitPause)
            {
                base.characterMotor.velocity = launchVelocity;
                base.characterDirection.forward = launchVelocity;
                base.characterBody.isSprinting = true;
            }
        }

        public override void AuthorityModifyOverlapAttack(OverlapAttack overlapAttack)
        {
            base.AuthorityModifyOverlapAttack(overlapAttack);
            overlapAttack.damage = this.damageCoefficient * this.damageStat + this.bonusDamage;
            overlapAttack.forceVector = base.characterMotor.velocity + base.GetAimRay().direction * kickForce;
            if (base.fixedAge + Time.fixedDeltaTime >= this.duration)
            {
                HitBoxGroup hitBoxGroup = base.FindHitBoxGroup("KickHitboxGroup");
                if (hitBoxGroup)
                {
                    this.hitBoxGroup = hitBoxGroup;
                    overlapAttack.hitBoxGroup = hitBoxGroup;
                }
            }
        }

        public override void OnExit()
        {
            base.characterMotor.velocity *= speedCoefficientOnExit;

            base.gameObject.layer = LayerIndex.defaultLayer.intVal;
            base.characterMotor.Motor.RebuildCollidableLayers();
            base.OnExit();
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}
