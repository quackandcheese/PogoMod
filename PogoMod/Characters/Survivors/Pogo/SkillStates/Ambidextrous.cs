using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class Ambidextrous : BaseSkillState
    {
        public static float maxAngle = 40f;
        public static float maxDistance = 80f;

        private RightHandTracker rightHandTracker;
        private HurtBox target;
        private BullseyeSearch search;
        private Indicator indicator;

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
            if (isAuthority)
            {
                indicator = new Indicator(gameObject, LegacyResourcesAPI.Load<GameObject>("Prefabs/HuntressTrackingIndicator"));
                indicator.active = false;
                search = new BullseyeSearch();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.isAuthority)
            {
                CleanTargetsList();
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
                }

                if (base.inputBank.skill2.justReleased)
                {
                    this.outer.SetNextStateToMain();
                    return;
                }
            }
        }

        public override void OnExit()
        {
            //rightHandTracker.enabled = false;
            if (indicator != null)
            {
                Debug.Log("Itasss");
                indicator.active = false;
            }

            base.OnExit();
        }

        private void CleanTargetsList()
        {
            // TODO: Remove target if line of sight is cut off or distance is too far
            if (target != null) {
                HurtBox hurtBox = target;
                if (!hurtBox.healthComponent || !hurtBox.healthComponent.alive)
                {
                    target = null;
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
    }
}
