using EntityStates;
using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;
using System.Linq;
using TMPro;

namespace PogoMod.Characters.Survivors.Pogo.SkillStates
{

    public class Reposition : BaseSkillState
    {
        public static float duration = 1.0f;

        private CharacterMotor motor;
        private Vector3 startPosition;
        private HurtBox lockedTarget;

        private Vector3 vxz;

        private Vector3 CalculateProjectileVelocity(Vector3 start, Vector3 end, float timeToTarget)
        {
            Vector3 toTarget = end - start;
            Vector3 toTargetXZ = new Vector3(toTarget.x, 0f, toTarget.z);

            float yOffset = toTarget.y;
            float xzDistance = toTargetXZ.magnitude;

            vxz = toTargetXZ.normalized * (xzDistance / timeToTarget);
            float vy = (yOffset + 0.5f * Mathf.Abs(Physics.gravity.y * motor.gravityScale) * timeToTarget * timeToTarget) / timeToTarget;

            Vector3 v = new Vector3(vxz.x, vy, vxz.z);
            return v;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            motor = characterMotor;
            startPosition = motor.transform.position;


            // Find a target (nearest enemy under aim)
            lockedTarget = FindTarget();

            if (lockedTarget)
            {
                base.characterMotor.Motor.ForceUnground();

                Vector3 targetPosition = lockedTarget.transform.position;
                Vector3 velocity = CalculateProjectileVelocity(startPosition, targetPosition, duration);
                motor.velocity = velocity;
            }

            else
            {
                // No target found: exit early
                outer.SetNextStateToMain();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixedAge >= duration || !lockedTarget)
            {
                outer.SetNextStateToMain();
            }

            // Keep XZ velocity constant and add homing.
            Vector3 toTargetXZ = lockedTarget.transform.position - base.characterBody.corePosition;
            toTargetXZ.y = 0f;

            if (toTargetXZ != Vector3.zero)
            {
                Vector3 desiredDir = toTargetXZ.normalized;
                Vector3 currentDir = new Vector3(motor.velocity.x, 0f, motor.velocity.z).normalized;

                float homingStrength = 5f; // tweak this
                Vector3 newDir = Vector3.RotateTowards(currentDir, desiredDir, homingStrength * Time.fixedDeltaTime, 0f);

                float timeLeft = Mathf.Max(duration - fixedAge, Time.fixedDeltaTime);
                float distanceXZ = toTargetXZ.magnitude;
                float speed = distanceXZ / timeLeft;

                motor.velocity = new Vector3(newDir.x * speed, motor.velocity.y, newDir.z * speed);
            }
        }

        public override void OnExit()
        {
            base.OnExit();
            if (motor) motor.velocity = Vector3.zero;
        }

        private HurtBox FindTarget()
        {
            // Try finding enemy under crosshair (or nearest in aim direction)
            Ray aimRay = GetAimRay();
            BullseyeSearch search = new BullseyeSearch
            {
                teamMaskFilter = TeamMask.AllExcept(GetTeam()),
                maxDistanceFilter = 60f,
                maxAngleFilter = 20f,
                searchOrigin = aimRay.origin,
                searchDirection = aimRay.direction,
                sortMode = BullseyeSearch.SortMode.DistanceAndAngle,
                filterByLoS = true,
                viewer = characterBody
            };
            search.RefreshCandidates();
            return search.GetResults().FirstOrDefault();
        }
    }

}
