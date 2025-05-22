using RoR2;
using RoR2.CharacterAI;
using RoR2.Projectile;
using RoR2.Skills;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering.PostProcessing;
using R2API.Utils;
using System.Runtime.CompilerServices;
using BepInEx.Logging;

namespace PogoMod.Modules
{
    public static class PogoUtilities
    {
        // LIFTED FROM https://github.com/TheTimeSweeper/Cloudburst/blob/main/Cloudburst/Modules/CCUtilities.cs

        #region UNITY2ROR2
        //ref here so we can pass in a rented collection from HG.CollectionPool
        public static void CharacterOverlapSphereAll(ref List<CharacterBody> hitBodies, Vector3 position, float radius, LayerMask layerMask)
        {
            Collider[] colliders = Physics.OverlapSphere(position, radius, layerMask);
            foreach (Collider collider in colliders)
            {
                HurtBox hurtBox = collider.gameObject.GetComponent<HurtBox>();
                if (hurtBox)
                {
                    CharacterBody characterBody = hurtBox.healthComponent.body;
                    if (characterBody && !hitBodies.Contains(characterBody))
                    {
                        hitBodies.Add(characterBody);
                    }
                }
            }
        }


        public static void AddUpwardImpulseToBody(GameObject victimBody, float upwardImpulseAmount)
        {
            Vector3 upwardImpulse = Vector3.up * upwardImpulseAmount;
            CharacterMotor hitMotor = victimBody.GetComponent<CharacterMotor>();
            if (hitMotor)
            {
                hitMotor.velocity = Vector3.zero;
                hitMotor.ApplyForce(upwardImpulse * hitMotor.mass, true, true);
                return;
            }
            RigidbodyMotor rigidMotor = victimBody.GetComponent<RigidbodyMotor>();
            if (rigidMotor)
            {
                rigidMotor.rigid.velocity = Vector3.zero;
                rigidMotor.rigid.AddForce(upwardImpulse * rigidMotor.mass, ForceMode.Impulse);
            }
        }
        public static void AddForwardImpulseToBody(GameObject victimBody, Vector3 directionAuthority, float forwardImpulseAmount)
        {
            Vector3 Impulse = directionAuthority;
            Impulse.y = 0;
            Impulse = Impulse.normalized * forwardImpulseAmount;

            CharacterMotor hitMotor = victimBody.GetComponent<CharacterMotor>();
            if (hitMotor)
            {
                hitMotor.ApplyForce(Impulse * hitMotor.mass, true, true);
                return;
            }
            RigidbodyMotor rigidMotor = victimBody.GetComponent<RigidbodyMotor>();
            if (rigidMotor)
            {
                rigidMotor.rigid.AddForce(Impulse * rigidMotor.mass, ForceMode.Impulse);
            }
        }

        public static void AddExplosionForce(CharacterMotor body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier = 0, bool useWearoff = false)
        {
            var dir = (body.transform.position - explosionPosition);

            Vector3 baseForce = Vector3.zero;

            if (useWearoff)
            {
                float wearoff = 1 - (dir.magnitude / explosionRadius);
                baseForce = dir.normalized * explosionForce * wearoff;
            }
            else
            {
                baseForce = dir.normalized * explosionForce;
            }
            //baseForce.z = 0;
            body.ApplyForce(baseForce);

            //if (upliftModifier != 0)
            //{
            float upliftWearoff = 1 - upliftModifier / explosionRadius;
            Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
            //upliftForce.z = 0;
            body.ApplyForce(upliftForce);
            //}

        }
        #endregion

        public static bool FriendlyFire_ShouldKnockupProceed(CharacterBody victimBody, TeamIndex attackerTeamIndex)
        {
            return victimBody.teamComponent.teamIndex != attackerTeamIndex || FriendlyFireManager.friendlyFireMode != FriendlyFireManager.FriendlyFireMode.Off || attackerTeamIndex == TeamIndex.None;
        }

        public static bool ShouldKnockup(CharacterBody victimBody, TeamIndex attackerTeamIndex)
        {
            bool canHit = true;

            if (!FriendlyFire_ShouldKnockupProceed(victimBody, attackerTeamIndex))
            {
                canHit = false;
            }

            return canHit;
        }
    }
}
