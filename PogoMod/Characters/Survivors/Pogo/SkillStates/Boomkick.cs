using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Modules;
using PogoMod.Survivors.Pogo;
using R2API;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Boomkick : BasicMeleeAttack
    {
        public static float launchSpeed = 20f;
        public static float speedCoefficientOnExit = 0.4f;

        protected Vector3 launchVelocity;
        private float bonusDamage = 0f;

        public override void OnEnter()
        {
            this.damageCoefficient = PogoStaticValues.kickDamageCoefficient;

            Vector3 aimDirection = base.GetAimRay().direction.normalized;

            //forceVector = aimDirection * PogoStaticValues.kickForce;

            this.hitPauseDuration = 0.1f;
            this.hitBoxGroupName = "KickHitboxGroup";

            base.OnEnter();

            if (base.isAuthority)
            {
                //base.gameObject.layer = LayerIndex.fakeActor.intVal;
                //base.characterMotor.Motor.RebuildCollidableLayers();
                //base.characterMotor.Motor.ForceUnground();
                //launchVelocity = CalculateLaunchVelocity(base.characterMotor.velocity, GetAimRay().direction);
                //base.characterMotor.velocity = launchVelocity;
                //base.characterDirection.forward = base.characterMotor.velocity.normalized;

                Vector3 direction = this.GetAimRay().direction;
                direction.y = Mathf.Max(direction.y, direction.y * 0.5f);
                this.FindModelChild("MeleePivot").rotation = Util.QuaternionSafeLookRotation(direction);
            }
        }
        public override void AuthorityModifyOverlapAttack(OverlapAttack overlapAttack)
        {
            DamageAPI.AddModdedDamageType(overlapAttack, DamageTypes.PogoBoomkick);
        }
        public override float CalcDuration()
        {
            return 0.3f;
        }

        public override void PlayAnimation()
        {
            base.PlayAnimation();
            base.PlayCrossfade("FullBody, Override", "Dropkick", "Dropkick.playbackRate", this.duration, 0.075f);
        }

        public static Vector3 CalculateLaunchVelocity(Vector3 currentVelocity, Vector3 aimDirection)
        {
            currentVelocity = (Vector3.Dot(currentVelocity, aimDirection) < 0f) ? Vector3.zero : Vector3.Project(currentVelocity, aimDirection);
            return currentVelocity + aimDirection * launchSpeed;
        }

        //public override void AuthorityFixedUpdate()
        //{
        //    base.AuthorityFixedUpdate();

        //    if (!authorityInHitPause)
        //    {
        //        base.characterMotor.velocity = launchVelocity;
        //        base.characterDirection.forward = launchVelocity;
        //        base.characterBody.isSprinting = true;
        //    }
        //}

        public override void OnExit()
        {
            //base.characterMotor.velocity *= speedCoefficientOnExit;

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
