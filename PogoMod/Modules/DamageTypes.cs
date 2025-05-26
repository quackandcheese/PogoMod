using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
using R2API;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Modules
{
    internal static class DamageTypes
    {
        public static DamageAPI.ModdedDamageType PogoBoomkick;

        public static void RegisterDamageTypes()
        {
            PogoBoomkick = DamageAPI.ReserveDamageType();
            SetHooks();
        }

        private static void SetHooks()
        {
            GlobalEventManager.onServerDamageDealt += GlobalEventManager_onServerDamageDealt;
        }

        private static void GlobalEventManager_onServerDamageDealt(DamageReport damageReport)
        {
            DamageInfo damageInfo = damageReport.damageInfo;
            HealthComponent victim = damageReport.victim;

            if (damageInfo.HasModdedDamageType(PogoBoomkick))
            {
                Vector3 kickVelocity = damageReport.attackerBody.inputBank.aimDirection * PogoStaticValues.kickForce;
                DamageInfo val = damageInfo;
                if (damageReport.victimBody.characterMotor)
                {
                    damageReport.victimBody.characterMotor.velocity = Vector3.zero;
                }
                val.damageType = DamageType.Generic;
                val.damage = 0f;
                val.force = kickVelocity;
                float effectiveMass = 0f;
                if (damageReport.victimBody.rigidbody)
                {
                    float mass = damageReport.victimBody.rigidbody.mass;
                    float levelFactor = Mathf.Min(damageReport.attackerBody.level / 40f, 1f);
                    effectiveMass = (mass >= 700f) ? mass * levelFactor : mass;
                }
                val.force *= effectiveMass;
                damageReport.victimBody.healthComponent.TakeDamageForce(val, false, false);

                victim.gameObject.AddComponent<EnemyRicochet>().attacker = damageReport.attacker;
            }
        }
    }
}
