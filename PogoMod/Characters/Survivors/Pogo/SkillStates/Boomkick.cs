using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
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
        private float kickForce = 4500f;

        public override void OnEnter()
        {
            this.damageCoefficient = PogoStaticValues.kickDamageCoefficient;

            Vector3 aimDirection = base.GetAimRay().direction.normalized;
            Vector2 spread = UnityEngine.Random.insideUnitCircle * characterBody.spreadBloomAngle * Mathf.Deg2Rad;

            // Build a local coordinate system around the aim direction
            Vector3 right = Vector3.Cross(Vector3.up, aimDirection).normalized;
            if (right == Vector3.zero)
                right = Vector3.Cross(Vector3.forward, aimDirection).normalized;
            Vector3 up = Vector3.Cross(aimDirection, right);

            // Apply spread around the aim direction
            Vector3 spreadDirection = aimDirection
                                      + spread.x * right
                                      + spread.y * up;
            spreadDirection.Normalize();

            forceVector = spreadDirection * kickForce;



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
            }
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

        public override void OnMeleeHitAuthority()
        {
            foreach (HurtBox enemyHit in hitResults)
            {
                EnemyRicochet ricochet;
                if (enemyHit.healthComponent.TryGetComponent<EnemyRicochet>(out ricochet))
                {
                    ricochet.attacker = base.gameObject;
                    continue;
                }
                ricochet = enemyHit.healthComponent.gameObject.AddComponent<EnemyRicochet>();
                ricochet.attacker = characterBody.gameObject;
            }
        }

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
