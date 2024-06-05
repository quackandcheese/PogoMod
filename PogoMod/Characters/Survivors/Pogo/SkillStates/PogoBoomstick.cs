using EntityStates;
using PogoMod.Modules.BaseContent.BaseStates;
using PogoMod.Survivors.Pogo;
using PogoMod.Survivors.Pogo.Components;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class PogoBoomstick : BasePogoSkillState
    {
        public static float damageCoefficient = PogoStaticValues.shotgunDamageCoefficient;
        public static float procCoefficient = 1f;
        public static float baseDuration = 0.6f;
        //delay on firing is usually ass-feeling. only set this if you know what you're doing
        public static float firePercentTime = 0.0f;
        public static float force = 200f;
        public static float range = 1000f;
        public static float radius = 0.3f;
        public static float spreadBloomValue = 0.2f;
        public const float recoilJumpForce = 20.0f;
        public static int bulletCount = 8;
        public static GameObject tracerEffectPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/TracerGoldGat");
        public static GameObject hitEffectPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/HitsparkCaptainShotgun");

        private float duration;
        private float fireTime;
        private bool hasFired;
        private string muzzleString = "Muzzle";

        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = baseDuration / this.attackSpeedStat;
            this.FireBullet(new Ray(inputBank.aimOrigin, Vector3.down));
            base.characterBody.AddSpreadBloom(spreadBloomValue);

            if (base.characterMotor)
            {
                //base.characterMotor.ApplyForce(new Vector3(0, recoilJumpForce, 0));
                base.characterMotor.Motor.ForceUnground();
                base.characterMotor.velocity = new Vector3(base.characterMotor.velocity.x, recoilJumpForce, base.characterMotor.velocity.z);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.fixedAge >= this.duration)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        protected virtual void FireBullet(Ray aimRay)
        {
            if (base.isAuthority)
            {
                BulletAttack bulletAttack = this.GenerateBulletAttack(aimRay);
                bulletAttack.Fire();
            }
        }

        protected BulletAttack GenerateBulletAttack(Ray aimRay)
        {
            float num = 0f;
            if (base.characterBody)
            {
                num = base.characterBody.spreadBloomAngle;
            }
            return new BulletAttack
            {
                aimVector = aimRay.direction,
                origin = aimRay.origin,
                owner = base.gameObject,
                weapon = null,
                bulletCount = (uint)bulletCount,
                damage = this.damageStat * damageCoefficient * pogoController.currentPogoDamageCoefficient,
                damageColorIndex = DamageColorIndex.Default,
                damageType = DamageType.Generic,
                falloffModel = BulletAttack.FalloffModel.Buckshot,
                force = force,
                HitEffectNormal = false,
                procChainMask = default(ProcChainMask),
                procCoefficient = procCoefficient,
                maxDistance = range,
                radius = radius,
                isCrit = base.RollCrit(),
                muzzleName = muzzleString,
                minSpread = 0,
                maxSpread = 1 + num,
                hitEffectPrefab = hitEffectPrefab,
                smartCollision = true,
                sniper = false,
                tracerEffectPrefab = tracerEffectPrefab,

                spreadPitchScale = 2f,
                spreadYawScale = 2f,
            };
        }
    }
}
