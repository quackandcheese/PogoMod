using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PogoMod.Characters.Survivors.Pogo.Components
{
    // 99% of code copied from base HuntressTracker class in RoR2 namespace

    [RequireComponent(typeof(InputBankTest))]
    [RequireComponent(typeof(CharacterBody))]
    [RequireComponent(typeof(TeamComponent))]
    public class RightHandTracker : MonoBehaviour
    {
        public float maxTrackingDistance = 60f;
        public float maxTrackingAngle = 40f;
        public float trackerUpdateFrequency = 10f;

        private HurtBox trackingTarget;
        private TeamComponent teamComponent;
        private InputBankTest inputBank;
        private Indicator indicator;
        private float trackerUpdateStopwatch;

        private readonly BullseyeSearch search = new BullseyeSearch();


        private void Awake()
        {
            indicator = new Indicator(gameObject, LegacyResourcesAPI.Load<GameObject>("Prefabs/HuntressTrackingIndicator"));
        }

        private void Start()
        {
            inputBank = GetComponent<InputBankTest>();
            teamComponent = GetComponent<TeamComponent>();
        }

        public HurtBox GetTrackingTarget()
        {
            Ray aimRay = new Ray(inputBank.aimOrigin, inputBank.aimDirection);
            SearchForTarget(aimRay);
            indicator.targetTransform = (trackingTarget ? trackingTarget.transform : null);
            return trackingTarget;
        }

        private void FixedUpdate()
        {
            this.trackerUpdateStopwatch += Time.fixedDeltaTime;
            if (this.trackerUpdateStopwatch >= 1f / this.trackerUpdateFrequency)
            {
                this.trackerUpdateStopwatch -= 1f / this.trackerUpdateFrequency;
                this.indicator.targetTransform = (this.trackingTarget ? this.trackingTarget.transform : null);
            }
        }

        private void OnEnable()
        {
            indicator.active = true;
        }

        private void OnDisable()
        {
            indicator.active = false;
        }

        private void SearchForTarget(Ray aimRay)
        {
            search.teamMaskFilter = TeamMask.GetUnprotectedTeams(teamComponent.teamIndex);
            search.filterByLoS = true;
            search.searchOrigin = aimRay.origin;
            search.searchDirection = aimRay.direction;
            search.sortMode = BullseyeSearch.SortMode.Distance;
            search.maxDistanceFilter = maxTrackingDistance;
            search.maxAngleFilter = maxTrackingAngle;
            search.RefreshCandidates();
            search.FilterOutGameObject(gameObject);
            trackingTarget = search.GetResults().FirstOrDefault<HurtBox>();
        }
    }
}
