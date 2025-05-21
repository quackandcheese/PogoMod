using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Characters.Survivors.Pogo.Components
{
    public class EnemyRicochet : MonoBehaviour
    {
        public GameObject attacker;
        private CharacterBody body;
        private CharacterMotor characterMotor;
        private void Awake()
        {
            body = GetComponent<CharacterBody>();
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
                    damage = 10f, // Example damage value
                    damageType = DamageType.Generic,
                    position = contactPoint,
                    force = velocity//10f //Example force value
                };
                enemy.healthComponent.TakeDamage(damageInfo);
            }

            Destroy(this);
        }
    }
}
