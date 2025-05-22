using PogoMod.Modules.BaseStates;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class MeleeCombo : BaseMeleeAttack
    {
        public override void OnEnter()
        {
            hitboxGroupName = "MeleeHitboxGroup";

            damageType = DamageType.Generic;
            damageCoefficient = PogoStaticValues.meleeDamageCoefficient;
            procCoefficient = 1f;
            pushForce = 300f;
            bonusForce = new Vector3(0, PogoStaticValues.meleeHitHop, 0);
            baseDuration = 0.45f;

            //0-1 multiplier of baseduration, used to time when the hitbox is out (usually based on the run time of the animation)
            //for example, if attackStartPercentTime is 0.5, the attack will start hitting halfway through the ability. if baseduration is 3 seconds, the attack will start happening at 1.5 seconds
            attackStartPercentTime = 0.3f;
            attackEndPercentTime = 0.6f;

            //this is the point at which the attack can be interrupted by itself, continuing a combo
            earlyExitPercentTime = 0.6f;

            hitStopDuration = 0.012f;
            attackRecoil = 0.5f;
            hitHopVelocity = PogoStaticValues.meleeHitHop;

            swingSoundString = "PogoSwordSwing";
            hitSoundString = "";
            muzzleString = swingIndex % 2 == 0 ? "SwingLeft" : "SwingRight";
            playbackRateParam = "Slash.playbackRate";
            swingEffectPrefab = PogoAssets.swordSwingEffect;
            hitEffectPrefab = PogoAssets.swordHitImpactEffect;

            impactSound = PogoAssets.swordHitSoundEvent.index;

            characterMotor.velocity /= 2;

            base.OnEnter();
        }

        protected override void FireAttack()
        {
            if (base.isAuthority)
            {
                Vector3 direction = this.GetAimRay().direction;
                direction.y = Mathf.Max(direction.y, direction.y * 0.5f);
                this.FindModelChild("MeleePivot").rotation = Util.QuaternionSafeLookRotation(direction);
            }

            base.FireAttack();
        }

        protected override void PlayAttackAnimation()
        {
            //PlayCrossfade("Gesture, Override", "Slash" + (1 + swingIndex), playbackRateParam, duration, 0.1f * duration);
        }

        protected override void PlaySwingEffect()
        {
            base.PlaySwingEffect();
        }

        protected override void OnHitEnemyAuthority()
        {
            base.OnHitEnemyAuthority();

            for (int i = 0; i < hitResults.Count; i++)
            {
                HurtBox hurtBox = hitResults[i];

                CharacterMotor component = hurtBox.healthComponent.GetComponent<CharacterMotor>();
                if (component)
                {
                    component.velocity /= 2;
                }
                Rigidbody component2 = hurtBox.healthComponent.GetComponent<Rigidbody>();
                if (component2)
                {
                    component2.velocity /= 2;
                }
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}