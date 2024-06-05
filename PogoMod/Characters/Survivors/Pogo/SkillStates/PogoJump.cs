using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Modules.BaseContent.BaseStates;
using PogoMod.Survivors.Pogo;
using RoR2;
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
    }
}
