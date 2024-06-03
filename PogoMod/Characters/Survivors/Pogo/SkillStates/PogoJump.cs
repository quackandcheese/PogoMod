using EntityStates;
using PogoMod.Characters.Survivors.Pogo.Components;
using PogoMod.Survivors.Pogo;
using RoR2;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class PogoJump : BaseState
    {
        public static float minimumYVelocityToBounce = -10f;

        public override void OnEnter()
        {
            base.OnEnter();

            if (characterMotor != null)
                characterMotor.onHitGroundServer += CharacterMotor_onHitGroundServer;
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.inputBank.jump.justPressed && base.isGrounded)
            {
                Debug.Log("JUMPED!");
            }
        }

        private void CharacterMotor_onHitGroundServer(ref CharacterMotor.HitGroundInfo hitGroundInfo)
        {
            Vector3 vector = hitGroundInfo.velocity;
            if (vector.y <= minimumYVelocityToBounce)
            {
                vector.y = Mathf.Abs(vector.y / 2);
                characterMotor.velocity = vector;
                characterMotor.Motor.ForceUnground();
            }
        }
    }
}
