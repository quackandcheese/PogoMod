using EntityStates;
using PogoMod.Survivors.Pogo.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace PogoMod.Modules.BaseContent.BaseStates
{
    public abstract class BasePogoState : BaseState
    {
        protected PogoController pogoController;

        public override void OnEnter()
        {
            pogoController = GetComponent<PogoController>();
            base.OnEnter();
        }
    }
}
