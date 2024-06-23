using PogoMod.Modules.BaseContent.BaseStates;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class PowerSurge : BasePogoSkillState
    {
        public static float baseDuration = 0.1f;
        private float duration;
        public override void OnEnter()
        {
            base.OnEnter();

            pogoController.pogoComboCoefficient = 1f + (pogoController.pogoCounter / 100);

            pogoController.pogoCounter = 0;
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.fixedAge >= this.duration && base.isAuthority)
            {
                this.outer.SetNextStateToMain();
                return;
            }
        }
    }
}
