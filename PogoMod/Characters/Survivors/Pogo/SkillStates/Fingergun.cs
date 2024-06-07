using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Modules.BaseContent.BaseStates;
using PogoMod.Survivors.Pogo;
using RoR2;
using System;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Fingergun : BasePogoSkillState
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

        public static float baseDelayBetweenBulletsMax = 0.18f;
        public static float delayBetweenBulletsMax;
        private float delayBetweenBullets = 0f;
        private float duration;
        private float fireTime;

        /// Targeting
        public static float maxAngle = 15f;
        public static float maxDistance = 200f;

        private HurtBox target;
        private BullseyeSearch search = new BullseyeSearch();
        private Indicator indicator;

        private bool hasKilledTarget = false;
        private bool foundTarget;


        private float pitchRangeMax = 90.0f;
        private float pitchRangeMin = -90.0f;

        private float yawRangeMax = 90.0f;
        private float yawRangeMin = -90.0f;

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
                DetermineTargetRemoval();

                if (!hasKilledTarget)
                {
                    if (target == null)
                    {
                        indicator.active = false;

                        HurtBox hurtBox;
                        HealthComponent y;
                        GetCurrentTargetInfo(out hurtBox, out y);

                        target = hurtBox;
                        foundTarget = target != null;
                    }
                    else
                    {
                        HasTargetFixedUpdate();
                    }
                }


                if (!IsKeyDownAuthority())
                {
                    Debug.Log("released " + side);
                    outer.SetNextStateToMain();
                    return;
                }
            }
        }

        public void HasTargetFixedUpdate()
        {
            indicator.targetTransform = target.transform;
            indicator.active = true;

            Animator animator = GetModelAnimator();



            Vector3 direction = target.transform.position - inputBank.aimOrigin;

            float pitch, yaw;
            GetPitchYaw(direction, out pitch, out yaw);


            int layerIndex = animator.GetLayerIndex(side + "ArmPitch");
            AnimatorClipInfo[] currentAnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex);
            AnimationClip clip = currentAnimatorClipInfo[0].clip;
            double timeInSeconds = (double)(clip.length * clip.frameRate);

            float pitchClipCycleEnd = (float)((timeInSeconds - 1.0) / timeInSeconds);
            float yawClipCycleEnd = 0.999f;


            animator.SetFloat(Animator.StringToHash("aimPitchCycle"), Remap(pitch, pitchRangeMin, pitchRangeMax, pitchClipCycleEnd, 0f));
            animator.SetFloat(Animator.StringToHash("aimYawCycle"), Remap(yaw, yawRangeMin, yawRangeMax, 0f, yawClipCycleEnd));

            // Firing
            delayBetweenBullets += Time.fixedDeltaTime;
            if (delayBetweenBullets >= delayBetweenBulletsMax)
            {
                Ray aimRay = new Ray(inputBank.aimOrigin, target.transform.position - inputBank.aimOrigin);

                PlayAnimation(side + "Hand", "Shoot", $"Shoot{side}.playbackRate", 1.8f);
                Fire(aimRay);

                delayBetweenBullets = 0f;
            }
        }

        void GetPitchYaw(Vector3 direction, out float pitch, out float yaw)
        {
            // Normalize the direction vector
            direction.Normalize();

            // Calculate yaw
            yaw = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Calculate pitch
            float magnitude = new Vector2(direction.x, direction.z).magnitude;
            pitch = Mathf.Atan2(direction.y, magnitude) * Mathf.Rad2Deg;
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
                if (foundTarget)
                {
                    hasKilledTarget = true;
                }

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
                    damage = damageCoefficient * damageStat * pogoController.currentPogoDamageCoefficient,
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

        private static float Remap(float value, float inMin, float inMax, float outMin, float outMax)
        {
            return outMin + (value - inMin) / (inMax - inMin) * (outMax - outMin);
        }
    }
}

