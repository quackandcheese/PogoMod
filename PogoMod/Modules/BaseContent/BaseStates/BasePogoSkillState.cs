using EntityStates;
using PogoMod.Survivors.Pogo.Components;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;

namespace PogoMod.Modules.BaseContent.BaseStates
{
    public abstract class BasePogoSkillState : BaseSkillState
    {
        protected PogoController pogoController;

        public override void OnEnter()
        {
            pogoController = GetComponent<PogoController>();
            base.OnEnter();
        }
    }
}
