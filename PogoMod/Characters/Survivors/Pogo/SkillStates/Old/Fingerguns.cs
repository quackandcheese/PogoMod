using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Fingerguns : BaseSkillState
    {
        public static float damageCoefficient = PogoStaticValues.shotgunDamageCoefficient;
        public static float procCoefficient = 1f;
        public static float baseDuration = 0.2f;
        // delay on fire
        public static float firePercentTime = 0.0f;
        public static float force = 800f;
        public static float recoil = 0.8f;
        public static float range = 256f;
        public static float spreadBloomValue = 0.2f;
        public static GameObject tracerEffectPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/TracerCommandoShotgun");
        public static float delayBetweenBulletsMax = 0.16f;

        private RightHandTracker rightHandTracker;
        private float delayBetweenBullets = 0f;
        private float duration;
        private float fireTime;
        private string muzzleString;

        public override void OnEnter()
        {
            base.OnEnter();
            rightHandTracker = GetComponent<RightHandTracker>();

            duration = baseDuration / attackSpeedStat;
            fireTime = firePercentTime * duration;
            characterBody.SetAimTimer(2f);
            muzzleString = "Muzzle";

            PlayAnimation("LeftArm, Override", "ShootGun", "ShootGun.playbackRate", 1.8f);
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();


            delayBetweenBullets += Time.fixedDeltaTime;
            if (delayBetweenBullets >= delayBetweenBulletsMax)
            {
                Ray leftAimRay = GetAimRay();
                Ray rightAimRay = GetAimRay();
                if (rightHandTracker.enabled)
                {
                    HurtBox target = rightHandTracker.trackingTarget;

                    if (target != null)
                        rightAimRay = new Ray(inputBank.aimOrigin, target.transform.position - inputBank.aimOrigin);
                }

                Fire(leftAimRay);
                Fire(rightAimRay);

                delayBetweenBullets = 0f;
            }

            if (fixedAge >= fireTime)
            {

            }

            if (fixedAge >= duration && isAuthority)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        private void Fire(Ray aimRay)
        {
            characterBody.AddSpreadBloom(spreadBloomValue);
            EffectManager.SimpleMuzzleFlash(EntityStates.Commando.CommandoWeapon.FirePistol2.muzzleEffectPrefab, gameObject, muzzleString, false);
            Util.PlaySound("HenryShootPistol", gameObject);

            if (isAuthority)
            {
                AddRecoil(-1f * recoil, -2f * recoil, -0.5f * recoil, 0.5f * recoil);

                new BulletAttack
                {
                    bulletCount = 1,
                    aimVector = aimRay.direction,
                    origin = aimRay.origin,
                    damage = damageCoefficient * damageStat,
                    damageColorIndex = DamageColorIndex.Default,
                    damageType = DamageType.Generic,
                    falloffModel = BulletAttack.FalloffModel.None,
                    maxDistance = range,
                    force = force,
                    hitMask = LayerIndex.CommonMasks.bullet,
                    minSpread = 0f,
                    maxSpread = 0f,
                    isCrit = RollCrit(),
                    owner = gameObject,
                    muzzleName = muzzleString,
                    smartCollision = true,
                    procChainMask = default,
                    procCoefficient = procCoefficient,
                    radius = 0.2f,
                    sniper = false,
                    stopperMask = LayerIndex.CommonMasks.bullet,
                    weapon = null,
                    tracerEffectPrefab = tracerEffectPrefab,
                    spreadPitchScale = 0f,
                    spreadYawScale = 0f,
                    queryTriggerInteraction = QueryTriggerInteraction.UseGlobal,
                    hitEffectPrefab = EntityStates.Commando.CommandoWeapon.FirePistol2.hitEffectPrefab,
                }.Fire();
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    
    }
}
