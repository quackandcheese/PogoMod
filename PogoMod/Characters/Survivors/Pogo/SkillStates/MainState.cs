﻿using System;
using RoR2;
using EntityStates;
using UnityEngine;
using System.Collections;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class MainState : GenericCharacterMain
    {
        public float jumpHeldDurationMax = 2f;
        public float jumpHeldDuration;
        float horizontalBonus = 1f;
        float verticalBonus = 1f;

        bool queueJump = false;

        public override void Update()
        {
            base.Update();

            if (inputBank.jump.down)
            {
                jumpHeldDuration = Mathf.Clamp(jumpHeldDuration + Time.deltaTime, 0, jumpHeldDurationMax);
            }
            if (inputBank.jump.justReleased && queueJump)
            {
                queueJump = false;

                verticalBonus = 1 + (jumpHeldDuration / jumpHeldDurationMax);

                AttemptJump();

                jumpHeldDuration = 0f;
            }
        }

        public override void ProcessJump()
        {
            if (jumpInputReceived && !inputBank.jump.down) 
            {
                AttemptJump();

                jumpHeldDuration = 0f;
                return;
            }

            queueJump = true;
        }

        public void AttemptJump()
        {
            if (!hasCharacterMotor)
            {
                return;
            }
            bool hopooFeather = false;
            bool waxQuail = false;
            if (!base.characterBody || base.characterMotor.jumpCount >= base.characterBody.maxJumpCount)
            {
                return;
            }
            int waxQuailCount = base.characterBody.inventory.GetItemCount(RoR2Content.Items.JumpBoost);
            if (base.characterMotor.jumpCount >= base.characterBody.baseJumpCount)
            {
                hopooFeather = true;
                horizontalBonus = 1.5f;
                verticalBonus = 1.5f;
            }
            else if (waxQuailCount > 0 && base.characterBody.isSprinting)
            {
                float v = base.characterBody.acceleration * base.characterMotor.airControl;
                if (base.characterBody.moveSpeed > 0f && v > 0f)
                {
                    waxQuail = true;
                    float num2 = Mathf.Sqrt(10f * waxQuailCount / v);
                    float num3 = base.characterBody.moveSpeed / v;
                    horizontalBonus = (num2 + num3) / num3;
                }
            }
            ApplyJumpVelocity(base.characterMotor, base.characterBody, horizontalBonus, verticalBonus);
            if (hasModelAnimator)
            {
                int layerIndex = base.modelAnimator.GetLayerIndex("Body");
                if (layerIndex >= 0)
                {
                    if (base.characterMotor.jumpCount == 0 || base.characterBody.baseJumpCount == 1)
                    {
                        base.modelAnimator.CrossFadeInFixedTime("Jump", smoothingParameters.intoJumpTransitionTime, layerIndex);
                    }
                    else
                    {
                        base.modelAnimator.CrossFadeInFixedTime("BonusJump", smoothingParameters.intoJumpTransitionTime, layerIndex);
                    }
                }
            }
            if (hopooFeather)
            {
                EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/FeatherEffect"), new EffectData
                {
                    origin = base.characterBody.footPosition
                }, transmit: true);
            }
            else if (base.characterMotor.jumpCount > 0)
            {
                EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/ImpactEffects/CharacterLandImpact"), new EffectData
                {
                    origin = base.characterBody.footPosition,
                    scale = base.characterBody.radius
                }, transmit: true);
            }
            if (waxQuail)
            {
                EffectManager.SpawnEffect(LegacyResourcesAPI.Load<GameObject>("Prefabs/Effects/BoostJumpEffect"), new EffectData
                {
                    origin = base.characterBody.footPosition,
                    rotation = Util.QuaternionSafeLookRotation(base.characterMotor.velocity)
                }, transmit: true);
            }
            base.characterMotor.jumpCount++;
        }
    }
}