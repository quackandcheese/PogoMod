using EntityStates;
using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;
using System.Linq;
using TMPro;
using static Rewired.ComponentControls.Effects.RotateAroundAxis;

namespace PogoMod.Characters.Survivors.Pogo.SkillStates
{

    public class Reposition : BaseSkillState
    {
        public static float baseDuration = 2.0f;
        public static float minVerticalVelocity = 6.0f;
        public float timeToTarget = baseDuration;

        private CharacterMotor motor;
        private Vector3 startPosition;
        private HurtBox lockedTarget;

        private Vector3 initialVelocity;

        private Vector3 CalculateProjectileVelocity(Vector3 startPos, Vector3 targetPos)
        {
            Vector3 distanceVector = (targetPos - startPos);
            Vector2 xzDistanceVec = new Vector2(distanceVector.x, distanceVector.z);
            float distanceToTarget = xzDistanceVec.magnitude;
            // timeToTarget is the amount of time the moving body will spend in the air, for fisherman it scales up to a maximum of 2 seconds based on distance. changing this will have a big effect on the feel of the arc
            timeToTarget = Mathf.Min(distanceToTarget * 0.05f, baseDuration);
            Vector2 xzDistanceVecNormalized = xzDistanceVec / distanceToTarget;
            // Calculates the initial Y speed needed to reach the target Y position in the given time, resulting in a parabolic arc
            float y = Trajectory.CalculateInitialYSpeed(timeToTarget, distanceVector.y);
            float travelRate = distanceToTarget / timeToTarget;
            initialVelocity = new Vector3(xzDistanceVecNormalized.x * travelRate, y, xzDistanceVecNormalized.y * travelRate);
            return initialVelocity;
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
                Vector3 targetPosition = lockedTarget.transform.position;
                Vector3 velocity = CalculateProjectileVelocity(startPosition, targetPosition);

                motor.Motor.ForceUnground();
                motor.disableAirControlUntilCollision = true;
                motor.velocity = Vector3.zero;
                motor.velocity = velocity;
            }
            else
            {
                outer.SetNextStateToMain();
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixedAge >= timeToTarget || !lockedTarget || Vector3.Distance(lockedTarget.transform.position, transform.position) <= 3.0)
            {
                outer.SetNextStateToMain();
            }

            // Keep XZ velocity constant and add homing.
            Vector3 toTargetXZ = lockedTarget.transform.position - transform.position;
            toTargetXZ.y = 0f;

            if (toTargetXZ != Vector3.zero)
            {
                Vector3 desiredDir = toTargetXZ.normalized;
                Vector3 currentDir = new Vector3(motor.velocity.x, 0f, motor.velocity.z).normalized;

                float homingStrength = 5f; // tweak this
                Vector3 newDir = Vector3.RotateTowards(currentDir, desiredDir, homingStrength * Time.fixedDeltaTime, 0f);

                float timeLeft = Mathf.Max(timeToTarget - fixedAge, Time.fixedDeltaTime);
                float distanceXZ = toTargetXZ.magnitude;
                float speed = distanceXZ / timeLeft;

                motor.velocity = new Vector3(newDir.x * speed, motor.velocity.y, newDir.z * speed);
            }
        }

        public override void OnExit()
        {
            motor.disableAirControlUntilCollision = false;
            motor.velocity = Vector3.zero;

            base.OnExit();
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
