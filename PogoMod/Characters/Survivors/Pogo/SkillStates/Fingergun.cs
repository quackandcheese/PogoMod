﻿using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
using RoR2;
using UnityEngine;
using static UnityEngine.ParticleSystem.PlaybackState;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Fingergun : BaseSkillState
    {
        public string side;
        public string muzzleString;
        public GameObject indicatorPrefab;

        // Firing
        public static float damageCoefficient = PogoStaticValues.fingergunDamageCoefficient;
        public static float procCoefficient = 1f;
        public static float baseDuration = 0.2f;
        public static float firePercentTime = 0.0f;
        public static float force = 200f;
        public static float recoil = 0.8f;
        public static float range = 256f;
        public static float spreadBloomValue = 0.2f;
        public static GameObject tracerEffectPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/Tracers/TracerCommandoShotgun");

        public static float baseDelayBetweenBulletsMax = 0.16f;
        public static float delayBetweenBulletsMax;
        private float delayBetweenBullets = 0f;
        private float duration;
        private float fireTime;

        /// Targeting
        public static float maxAngle = 10f;
        public static float maxDistance = 200f;

        private HurtBox target;
        private BullseyeSearch search = new BullseyeSearch();
        private Indicator indicator;

        private bool hasKilledTarget = false;

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Death;
        }

        public override void OnEnter()
        {
            base.OnEnter();

            //rightHandTracker = GetComponent<RightHandTracker>();
            //rightHandTracker.enabled = true;
            //target = rightHandTracker.GetTrackingTarget();
            SetupFingergun();

            if (isAuthority)
            {
                if (indicator == null)
                {
                    indicator = new Indicator(gameObject, indicatorPrefab);
                    indicator.active = false;
                }
            }

            delayBetweenBulletsMax = baseDelayBetweenBulletsMax / attackSpeedStat;
            delayBetweenBullets = delayBetweenBulletsMax;
            duration = baseDuration / attackSpeedStat;
            fireTime = firePercentTime * duration;
        }

        public virtual void SetupFingergun() 
        {
            muzzleString = "Muzzle";
            side = "Left";
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.isAuthority)
            {
                if (!hasKilledTarget)
                {
                    DetermineTargetRemoval();
                    if (target == null)
                    {
                        indicator.active = false;

                        HurtBox hurtBox;
                        HealthComponent y;
                        GetCurrentTargetInfo(out hurtBox, out y);

                        target = hurtBox;
                    }
                    else
                    {
                        indicator.targetTransform = target.transform;
                        indicator.active = true;

                        // Firing
                        delayBetweenBullets += Time.fixedDeltaTime;
                        if (delayBetweenBullets >= delayBetweenBulletsMax)
                        {
                            Ray aimRay = new Ray(inputBank.aimOrigin, target.transform.position - inputBank.aimOrigin);

                            PlayAnimation("LeftArm, Override", "ShootGun", "ShootGun.playbackRate", 1.8f);
                            Fire(aimRay);

                            delayBetweenBullets = 0f;
                        }
                    }
                }


                if ((inputBank.skill1.justReleased && side == "Left") || (inputBank.skill2.justReleased && side == "Right"))
                {
                    Debug.Log("released " + side);
                    outer.SetNextStateToMain();
                    return;
                }
            }
        }

        public override void OnExit()
        {
            //rightHandTracker.enabled = false;
            if (indicator != null)
            {
                indicator.active = false;
            }

            hasKilledTarget = false;

            base.OnExit();
        }

        private void DetermineTargetRemoval()
        {
            // TODO: Remove target if line of sight is cut off or distance is too far
            if (target != null)
            {
                HurtBox hurtBox = target;
                if (!hurtBox.healthComponent || !hurtBox.healthComponent.alive)
                {
                    target = null;

                    hasKilledTarget = true;
                }
            }
            else
            {
                indicator.active = false;
            }
        }

        private void GetCurrentTargetInfo(out HurtBox currentTargetHurtBox, out HealthComponent currentTargetHealthComponent)
        {
            Ray aimRay = base.GetAimRay();
            this.search.filterByDistinctEntity = true;
            this.search.filterByLoS = true;
            this.search.minDistanceFilter = 0f;
            this.search.maxDistanceFilter = maxDistance;
            this.search.minAngleFilter = 0f;
            this.search.maxAngleFilter = maxAngle;
            this.search.viewer = base.characterBody;
            this.search.searchOrigin = aimRay.origin;
            this.search.searchDirection = aimRay.direction;
            this.search.sortMode = BullseyeSearch.SortMode.DistanceAndAngle;
            this.search.teamMaskFilter = TeamMask.GetUnprotectedTeams(base.GetTeam());
            this.search.RefreshCandidates();
            this.search.FilterOutGameObject(base.gameObject);
            foreach (HurtBox hurtBox in this.search.GetResults())
            {
                if (hurtBox.healthComponent && hurtBox.healthComponent.alive)
                {
                    currentTargetHurtBox = hurtBox;
                    currentTargetHealthComponent = hurtBox.healthComponent;
                    return;
                }
            }
            currentTargetHurtBox = null;
            currentTargetHealthComponent = null;
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
                    hitEffectPrefab = EntityStates.Commando.CommandoWeapon.FireShotgun.hitEffectPrefab,
                }.Fire();
            }
        }
    }
}
