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
        public static float spreadBloomValue = 1f;
        public const float recoilJumpForce = 20.0f;
        public static int bulletCount = 8;
        public static GameObject hitEffectPrefab = LegacyResourcesAPI.Load<GameObject>("prefabs/effects/impacteffects/MissileExplosionVFX");
        public static GameObject tracerEffectPrefab = LegacyResourcesAPI.Load<GameObject>("prefabs/effects/tracers/tracerembers");
        public static GameObject smokeEffectPrefab = LegacyResourcesAPI.Load<GameObject>("prefabs/effects/muzzleflashes/muzzleflashLoader");
        public static GameObject flashEffectPrefab = LegacyResourcesAPI.Load<GameObject>("prefabs/effects/muzzleflashes/muzzleflashfire");

        private float duration;
        private float fireTime;
        private bool hasFired;
        private string muzzleString = "Muzzle";


        private Quaternion major = Quaternion.FromToRotation(Vector3.forward, Vector3.down);


        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = baseDuration / this.attackSpeedStat;
            this.Fire();
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

        public void Fire()
        {
            if (base.isAuthority)
            {
                //Ray aimRay = base.GetAimRay();

                Vector3 aimer = Vector3.down;

                BulletAttack bulletAttack = new BulletAttack
                {
                    owner = base.gameObject,
                    weapon = base.gameObject,
                    // TODO: Change muzzle name (for other abilities too)
                    muzzleName = "Muzzle",
                    origin = characterBody.footPosition,
                    aimVector = aimer,
                    minSpread = 0f,
                    maxSpread = base.characterBody.spreadBloomAngle,
                    radius = 0.5f,  //was 0.35
                    bulletCount = 1U,
                    procCoefficient = .7f,
                    damage = base.characterBody.damage * PogoStaticValues.shotgunDamageCoefficient,
                    force = 3,
                    falloffModel = BulletAttack.FalloffModel.None,
                    tracerEffectPrefab = tracerEffectPrefab,
                    hitEffectPrefab = hitEffectPrefab,
                    isCrit = base.RollCrit(),
                    HitEffectNormal = false,
                    stopperMask = LayerIndex.world.mask,
                    smartCollision = true,
                    maxDistance = 300f
                };

                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i <= 4; i++)    //was 9
                    {
                        float theta = Random.Range(0.0f, 6.28f);
                        float x = Mathf.Cos(theta);
                        float z = Mathf.Sin(theta);
                        float c = i * 0.7555f; //0.3777f * 10/5
                        c *= (1f / 12f);
                        aimer.x += c * x;
                        aimer.z += c * z;
                        bulletAttack.aimVector = aimer;
                        bulletAttack.Fire();
                        aimer = Vector3.down;
                    }
                }

                EffectData effectData = new EffectData();
                effectData.origin = characterBody.footPosition + (1 * Vector3.down);
                effectData.scale = 8;
                effectData.rotation = major;

                EffectManager.SpawnEffect(smokeEffectPrefab, effectData, true);
                effectData.scale = 16;
                EffectManager.SpawnEffect(flashEffectPrefab, effectData, true);
            }
        }
    }
}
