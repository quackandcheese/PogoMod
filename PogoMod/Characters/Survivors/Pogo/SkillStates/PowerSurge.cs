using PogoMod.Modules.BaseContent.BaseStates;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class PowerSurge : BasePogoSkillState
    {
        public static float baseDuration = 0.1f;
        private float duration;
        public override void OnEnter()
        {
            base.OnEnter();

            pogoController.pogoComboCoefficient += (float)pogoController.pogoCounter / 1.0f;
            Debug.Log(pogoController.pogoCounter);
            Debug.Log(pogoController.pogoComboCoefficient);

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
