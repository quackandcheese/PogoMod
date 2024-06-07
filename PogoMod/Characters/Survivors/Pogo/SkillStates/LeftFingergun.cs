using System;
using System.Collections.Generic;
using System.Text;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class LeftFingergun : Fingergun
    {
        public override void SetupFingergun()
        {
            muzzleString = "LeftMuzzle";
            side = "Left";
            indicatorPrefab = PogoAssets.leftFingergunIndicator;
        }
    }
}
