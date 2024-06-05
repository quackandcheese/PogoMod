using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Modules.BaseContent.BaseStates;
using PogoMod.Survivors.Pogo;
using RoR2;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class PogoJump : BasePogoState
    {
        public float jumpBuffer = 0.1f;
        public float jumpBufferTimer = 0.0f;

        public float perfectJumpBuffer = 0.1f;
        public float perfectJumpBufferTimer = 0.0f;


        public override void OnEnter()
        {
            base.OnEnter();

            characterMotor.onHitGroundAuthority += CharacterMotor_onHitGroundAuthority;
        }

        private void CharacterMotor_onHitGroundAuthority(ref CharacterMotor.HitGroundInfo hitGroundInfo)
        {
            perfectJumpBufferTimer = perfectJumpBuffer;
            pogoController.withinPerfectJumpTiming = true;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.inputBank.jump.justPressed && !base.isGrounded)
            {
                Debug.Log("JUMPED in air!");
                jumpBufferTimer = jumpBuffer;

                if (this.AttemptEnemyStep(out HurtBox enemy))
                {
                    // TODO: Make damage scale with height fallen or something

                    //base.PlayAnimation("Body", "JumpEnemy");
                    //Util.PlaySound("sfx_ravager_enemystep", this.gameObject);

                    //float dist = Mathf.Max(0f, this.initialY - this.body.footPosition.y);
                    //float t = Mathf.InverseLerp(0f, HeadstompersFall.maxDistance, dist);
                    //if (dist > 0f)
                    //{
                    float damageCoefficient = 20;//Mathf.Lerp(PogoStaticValues.minimumStompDamageCoefficient, PogoStaticValues.maximumStompDamageCoefficient, t);
                    float radius = 5;//Mathf.Lerp(HeadstompersFall.minimumRadius, HeadstompersFall.maximumRadius, t);
                    BlastAttack blastAttack = new BlastAttack();
                    blastAttack.attacker = characterBody.gameObject;
                    blastAttack.inflictor = characterBody.gameObject;
                    blastAttack.teamIndex = TeamComponent.GetObjectTeam(blastAttack.attacker);
                    blastAttack.position = characterBody.footPosition;
                    blastAttack.procCoefficient = 1f;
                    blastAttack.radius = radius;
                    blastAttack.baseForce = 100f * damageCoefficient;
                    blastAttack.bonusForce = Vector3.up * 500f;
                    blastAttack.baseDamage = characterBody.damage * damageCoefficient;
                    blastAttack.falloffModel = BlastAttack.FalloffModel.SweetSpot;
                    blastAttack.crit = Util.CheckRoll(characterBody.crit, characterBody.master);
                    blastAttack.damageColorIndex = DamageColorIndex.Item;
                    blastAttack.attackerFiltering = AttackerFiltering.NeverHitSelf;
                    blastAttack.Fire();
                    EffectData effectData = new EffectData();
                    effectData.origin = characterBody.footPosition;
                    effectData.scale = radius;
                    EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/BootShockwave"), effectData, true);
                    //}

                    GenericCharacterMain.ApplyJumpVelocity(base.characterMotor, base.characterBody, 1.5f, 1.5f, false);
                    return;
                }
            }

            if (jumpBufferTimer > 0.0f)
            {
                jumpBufferTimer -= Time.fixedDeltaTime;

                if (isGrounded)
                {
                    pogoController.withinPerfectJumpTiming = true;
                    pogoController.jumpQueued = true;
                    jumpBufferTimer = 0;
                }
            }

            if (pogoController.withinPerfectJumpTiming)
            {
                perfectJumpBufferTimer -= Time.fixedDeltaTime;


                if (perfectJumpBufferTimer <= 0.0f)
                {
                    pogoController.withinPerfectJumpTiming = false;
                }
            }
        }

        private bool AttemptEnemyStep(out HurtBox enemy)
        {
            enemy = null;

            BullseyeSearch bullseyeSearch = new BullseyeSearch
            {
                teamMaskFilter = TeamMask.GetEnemyTeams(base.GetTeam()),
                filterByLoS = false,
                searchOrigin = this.transform.position + (Vector3.up * 0.5f),
                searchDirection = UnityEngine.Random.onUnitSphere,
                sortMode = BullseyeSearch.SortMode.Distance,
                maxDistanceFilter = 5f,
                maxAngleFilter = 360f
            };

            bullseyeSearch.RefreshCandidates();
            bullseyeSearch.FilterOutGameObject(base.gameObject);
            List<HurtBox> list = bullseyeSearch.GetResults().ToList<HurtBox>();
            foreach (HurtBox hurtBox in list)
            {
                if (hurtBox)
                {
                    if (hurtBox.healthComponent && hurtBox.healthComponent.body)
                    {
                        enemy = hurtBox;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
