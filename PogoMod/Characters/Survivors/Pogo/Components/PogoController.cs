using PogoMod.Characters.Survivors.Pogo.Components;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Survivors.Pogo.Components
{
    public class PogoController : MonoBehaviour
    {
        public Animator animator;
        public ArmAimAnimator armAimAnimator;

        public bool withinPerfectJumpTiming = false;
        public bool jumpQueued = false;

        public int pogoCounterMax = 2;
        public int pogoCounter = 0;
        public float extraBoostPerPogo = 0.25f;

        public float pogoDamageCoefficient = 1.125f;
        public float currentPogoDamageCoefficient = 1.0f;

        private void Start()
        {
            ModelLocator modelLocator = GetComponent<ModelLocator>();
            animator = modelLocator.modelTransform.GetComponent<Animator>();
            armAimAnimator = animator.gameObject.AddComponent<ArmAimAnimator>();
        }
    }
}
