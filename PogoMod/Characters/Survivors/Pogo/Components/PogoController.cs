﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.Components
{
    public class PogoController : MonoBehaviour
    {
        public bool withinPerfectJumpTiming = false;
        public bool jumpQueued = false;

        public int pogoCounterMax = 2;
        public int pogoCounter = 0;
        public float extraBoostPerPogo = 0.25f;
    }
}