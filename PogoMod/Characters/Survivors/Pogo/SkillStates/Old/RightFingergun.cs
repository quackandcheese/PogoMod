using System;
using System.Collections.Generic;
using System.Text;

namespace PogoMod.Survivors.Pogo.SkillStates
{
    public class RightFingergun : Fingergun
    {
        public override void SetupFingergun()
        {
            muzzleString = "RightMuzzle";
            side = "Right";
            indicatorPrefab = PogoAssets.rightFingergunIndicator;
        }
    }
}
