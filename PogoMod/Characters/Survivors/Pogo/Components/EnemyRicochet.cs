using PogoMod.Modules;
using PogoMod.Survivors.Pogo;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace PogoMod.Characters.Survivors.Pogo.Components
{
    public class EnemyRicochet : MonoBehaviour
    {
        public enum MotorType
        {
            NONE,
            CHARACTERMOTOR,
            RIGIDBODYMOTOR,
            RIGIDBODY
        }
        public GameObject attacker;
        public CharacterBody attackerBody;
        private CharacterBody body;
        private CharacterMotor characterMotor;
        private MotorType motorType = MotorType.NONE;

        private void Start()
        {
            body = GetComponent<CharacterBody>();
            attackerBody = attacker.GetComponent<CharacterBody>();
            if (TryGetComponent(out characterMotor))
            {
                On.RoR2.CharacterMotor.OnMovementHit += CharacterMotor_OnMovementHit;
            }

            PogoPlugin.logger.LogInfo("Ricochet init");
        }
        private void OnDestroy()
        {
            On.RoR2.CharacterMotor.OnMovementHit -= CharacterMotor_OnMovementHit;
        }
        private void CharacterMotor_OnMovementHit(On.RoR2.CharacterMotor.orig_OnMovementHit orig, CharacterMotor self, Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref KinematicCharacterController.HitStabilityReport hitStabilityReport)
        {
            orig(self, hitCollider, hitNormal, hitPoint, ref hitStabilityReport);
            if (characterMotor == null || self != characterMotor)
                return;
            Ricochet(hitCollider, self.velocity, hitPoint, hitNormal);
        }

        public void OnCollisionEnter(Collision collision)
        {
            PogoPlugin.logger.LogInfo("Collided");
            if (body && body.healthComponent)
            {
                IPhysMotor motor = body.GetComponent<IPhysMotor>();
                if (motor == null || characterMotor != null)
                    return;
                Ricochet(collision.collider, motor.velocity, collision.contacts[0].point, collision.contacts[0].normal);
            }
        }

        private void Ricochet(Collider hitCollider, Vector3 velocity, Vector3 contactPoint, Vector3 contactNormal)
        {

            // Ricochet logic here
            Vector3 ricochetDirection = Vector3.Reflect(velocity.normalized, contactNormal);
            //Rigidbody rb = collision.rigidbody;
            //if (rb)
            //{
            //    rb.velocity = ricochetDirection * rb.velocity.magnitude;
            //}
            float damage = Mathf.Abs(velocity.magnitude);
            DamageInfo collisionDamage = new DamageInfo
            {
                attacker = attacker,
                damage = damage, // Example damage value
                damageType = DamageType.Generic,
                position = contactPoint,
                force = ricochetDirection * velocity.magnitude//10f //Example force value
            };
            body.healthComponent.TakeDamage(collisionDamage);
            GlobalEventManager.instance.OnHitEnemy(collisionDamage, body.healthComponent.gameObject);
            GlobalEventManager.instance.OnHitAll(collisionDamage, body.healthComponent.gameObject);
            PogoPlugin.logger.LogInfo("Damage: " + damage);

            // Check if the collided object is an enemy
            CharacterBody enemy = hitCollider.gameObject.GetComponent<CharacterBody>();
            if (enemy && enemy.teamComponent && enemy.teamComponent.teamIndex != body.teamComponent.teamIndex)
            {
                // Apply damage to the enemy
                DamageInfo damageInfo = new DamageInfo
                {
                    attacker = attacker,
                    damage = attackerBody.damage * damage, // Example damage value
                    damageType = DamageType.Generic,
                    position = contactPoint,
                    force = velocity//10f //Example force value
                };
                enemy.healthComponent.TakeDamage(damageInfo);
            }

            CreateBlast(contactPoint, velocity);

            Destroy(this);
        }

        private void CreateBlast(Vector3 position, Vector3 velocity)
        {
            float blastRadius = 10;
            if (NetworkServer.active)
            {
                if (velocity.magnitude < 10)
                    return;
                float blastDamage = velocity.magnitude * 0.2f;
                //Log.Warning("amountFell: " + amountFell + "damage: " + blastDamage);

                //EffectManager.SpawnEffect(WyattEffects.tiredOfTheDingDingDing, new EffectData
                //{
                //    scale = blastRadius,
                //    rotation = Quaternion.identity,
                //    origin = position,
                //}, true);

                BlastAttack blastAttack = new BlastAttack
                {
                    position = position,
                    //baseForce = 3000,
                    attacker = attacker,
                    inflictor = attacker,
                    teamIndex = attackerBody.teamComponent.teamIndex,
                    baseDamage = attackerBody.damage * blastDamage, //3,
                    attackerFiltering = AttackerFiltering.NeverHitSelf,
                    //bonusForce = new Vector3(0, -3000, 0),
                    damageType = new DamageTypeCombo(DamageType.Stun1s, DamageTypeExtended.Generic, DamageSource.Secondary), //| DamageTypeCore.spiked,
                    crit = attackerBody.RollCrit(),
                    damageColorIndex = DamageColorIndex.WeakPoint,
                    falloffModel = BlastAttack.FalloffModel.SweetSpot,
                    //impactEffect = BandaidConvert.Resources.Load<GameObject>("prefabs/effects/impacteffects/PulverizedEffect").GetComponent<EffectIndex>(),
                    procCoefficient = 1,
                    radius = blastRadius
                };
                //R2API.DamageAPI.AddModdedDamageType(blastAttack, WyattDamageTypes.antiGravDamage);
                blastAttack.Fire();
            }

            Util.PlaySound("Play_grandParent_attack1_boulderLarge_impact", gameObject);

            List<CharacterBody> hitBodies = HG.CollectionPool<CharacterBody, List<CharacterBody>>.RentCollection();
            PogoUtilities.CharacterOverlapSphereAll(ref hitBodies, transform.position, blastRadius, LayerIndex.CommonMasks.bullet);

            for (int i = 0; i < hitBodies.Count; i++)
            {
                CharacterBody characterBody = hitBodies[i];

                bool canHit = PogoUtilities.ShouldKnockup(characterBody, attackerBody.teamComponent.teamIndex);
                if (canHit && characterBody.gameObject != gameObject && characterBody.gameObject != attacker)
                {
                    PogoUtilities.AddUpwardImpulseToBody(characterBody.gameObject, PogoStaticValues.knockUpForce);// 10);
                    //CCUtilities.AddExplosionForce(characterBody.characterMotor, characterBody.characterMotor.mass * 25, transform.position, 25, 5, false);
                    //CCUtilities.AddUpwardForceToBody(characterBody.gameObject, 10);                    
                }
            }
            HG.CollectionPool<CharacterBody, List<CharacterBody>>.ReturnCollection(hitBodies);
        }
    }
}
