using EntityStates;
using PogoMod.Modules.BaseContent.BaseStates;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class ChargeBlastOff : BasePogoSkillState
    {
        protected float chargeDuration { get; private set; }
        protected float charge { get; private set; }

        public float baseChargeDuration = 2.5f;
        public static float minChargeForChargedAttack = 0;

        public static string startChargeLoopSFXString = "Play_loader_shift_charge_loop";
        public static string endChargeLoopSFXString = "Stop_loader_shift_charge_loop";
        public static string enterSFXString = "Play_loader_shift_activate";

        private uint soundID;

        public override void OnEnter()
        {
            base.OnEnter();
            chargeDuration = baseChargeDuration / attackSpeedStat;
            Util.PlaySound(enterSFXString, base.gameObject);
            soundID = Util.PlaySound(startChargeLoopSFXString, base.gameObject);
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }

        public override void OnExit()
        {
            base.characterMotor.walkSpeedPenaltyCoefficient = 1f;
            Util.PlaySound(endChargeLoopSFXString, base.gameObject);
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            charge = Mathf.Clamp01(base.fixedAge / chargeDuration);

            base.characterBody.SetSpreadBloom(charge);
            base.characterBody.SetAimTimer(3f);

            if (base.isAuthority)
            {
                AuthorityFixedUpdate();
            }
        }

        private void AuthorityFixedUpdate()
        {
            if (!ShouldKeepChargingAuthority())
            {
                outer.SetNextState(GetNextStateAuthority());
            }
        }


        public override void Update()
        {
            base.Update();
            Mathf.Clamp01(base.age / chargeDuration);
        }

        protected virtual bool ShouldKeepChargingAuthority()
        {
            return IsKeyDownAuthority();
        }

        protected virtual EntityState GetNextStateAuthority()
        {
            return new BlastOff
            {
                charge = charge
            };
        }
    }
}
