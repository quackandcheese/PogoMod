using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace PogoMod.Characters.Survivors.Pogo.Components
{
    [RequireComponent(typeof(Animator))]
    public class ArmAimAnimator : MonoBehaviour, ILifeBehavior
    {
        private Animator animatorComponent;

        private float pitchRangeMax = 80.0f;
        private float pitchRangeMin = -80.0f;

        private float yawRangeMax = 0.0f;
        private float yawRangeMin = -180.0f;


        private float pitchClipCycleEnd;
        private float yawClipCycleEnd;

        private AimAnimator.AimAngles currentLocalAngles;
        private AimAnimator.AimAngles localAnglesToAimVector;
        private AimAnimator.AimAngles clampedLocalAnglesToAimVector;
        private AimAnimator.AimAngles smoothingVelocity;


        private struct AimAngles
        {
            public float pitch;
            public float yaw;
        }

        private static float NormalizeAngle(float angle)
        {
            return Mathf.Repeat(angle + 180f, 360f) - 180f;
        }

        private static float Remap(float value, float inMin, float inMax, float outMin, float outMax)
        {
            return outMin + (value - inMin) / (inMax - inMin) * (outMax - outMin);
        }

        private void Awake()
        {
            this.animatorComponent = base.GetComponent<Animator>();
        }

        private void Start()
        {
            int layerIndex = this.animatorComponent.GetLayerIndex("LeftArmPitch");
            int layerIndex2 = this.animatorComponent.GetLayerIndex("LeftArmYaw");
            this.animatorComponent.Play("PitchControl", layerIndex);
            this.animatorComponent.Play("YawControl", layerIndex2);
            this.animatorComponent.Update(0f);
            AnimatorClipInfo[] currentAnimatorClipInfo = this.animatorComponent.GetCurrentAnimatorClipInfo(layerIndex);
            AnimatorClipInfo[] currentAnimatorClipInfo2 = this.animatorComponent.GetCurrentAnimatorClipInfo(layerIndex2);
            if (currentAnimatorClipInfo.Length != 0)
            {
                AnimationClip clip = currentAnimatorClipInfo[0].clip;
                double num = (double)(clip.length * clip.frameRate);
                this.pitchClipCycleEnd = (float)((num - 1.0) / num);
            }
            if (currentAnimatorClipInfo2.Length != 0)
            {
                AnimationClip clip2 = currentAnimatorClipInfo2[0].clip;
                float length = clip2.length;
                float frameRate = clip2.frameRate;
                this.yawClipCycleEnd = 0.999f;
            }
        }

        private void Update()
        {
            if (Time.deltaTime <= 0f)
            {
                return;
            }
            this.UpdateLocalAnglesToAimVector(transform.forward);
            this.UpdateGiveup();
            this.ApproachDesiredAngles();
            this.UpdateAnimatorParameters(this.animatorComponent, this.pitchRangeMin, this.pitchRangeMax, this.yawRangeMin, this.yawRangeMax);
        }

        public void AimImmediate(string side, Vector3 directionVector)
        {
            this.UpdateLocalAnglesToAimVector(directionVector);
            this.ResetGiveup();
            this.currentLocalAngles = this.clampedLocalAnglesToAimVector;
            this.smoothingVelocity = new AimAnimator.AimAngles
            {
                pitch = 0f,
                yaw = 0f
            };
            this.UpdateAnimatorParameters(this.animatorComponent, this.pitchRangeMin, this.pitchRangeMax, this.yawRangeMin, this.yawRangeMax);
        }

        private void UpdateLocalAnglesToAimVector(Vector3 directionVector)
        {
            Vector3 eulerAngles = Util.QuaternionSafeLookRotation(base.transform.InverseTransformDirection(directionVector), base.transform.up).eulerAngles;
            this.localAnglesToAimVector = new AimAnimator.AimAngles
            {
                pitch = NormalizeAngle(eulerAngles.x),
                yaw = NormalizeAngle(eulerAngles.y)
            };

            this.overshootAngles = new AimAnimator.AimAngles
            {
                pitch = Mathf.Max(this.pitchRangeMin - this.localAnglesToAimVector.pitch, this.localAnglesToAimVector.pitch - this.pitchRangeMax),
                yaw = Mathf.Max(Mathf.DeltaAngle(this.localAnglesToAimVector.yaw, this.yawRangeMin), Mathf.DeltaAngle(this.yawRangeMax, this.localAnglesToAimVector.yaw))
            };

            this.clampedLocalAnglesToAimVector = new AimAnimator.AimAngles
            {
                pitch = Mathf.Clamp(this.localAnglesToAimVector.pitch, this.pitchRangeMin, this.pitchRangeMax),
                yaw = Mathf.Clamp(this.localAnglesToAimVector.yaw, this.yawRangeMin, this.yawRangeMax)
            };
        }

        public void UpdateAnimatorParameters(Animator animator, float pitchRangeMin, float pitchRangeMax, float yawRangeMin, float yawRangeMax)
        {
            animator.SetFloat("leftArmPitchCycle", Remap(this.currentLocalAngles.pitch, pitchRangeMin, pitchRangeMax, this.pitchClipCycleEnd, 0f));
            animator.SetFloat("leftArmYawCycle", Remap(this.currentLocalAngles.yaw, yawRangeMin, yawRangeMax, 0f, this.yawClipCycleEnd));
        }

        public void OnDeathStart()
        {
            base.enabled = false;
            this.currentLocalAngles = new AimAnimator.AimAngles
            {
                pitch = 0f,
                yaw = 0f
            };
            this.UpdateAnimatorParameters(this.animatorComponent, this.pitchRangeMin, this.pitchRangeMax, this.yawRangeMin, this.yawRangeMax);
        }



        [Tooltip("If the pitch is this many degrees beyond the range the aiming animations support, the character will return to neutral pose after waiting the giveup duration.")]
        public float pitchGiveupRange = 30;

        // Token: 0x040020E0 RID: 8416
        [Tooltip("If the yaw is this many degrees beyond the range the aiming animations support, the character will return to neutral pose after waiting the giveup duration.")]
        public float yawGiveupRange = 30;

        // Token: 0x040020E1 RID: 8417
        [Tooltip("If the pitch or yaw exceed the range supported by the aiming animations, the character will return to neutral pose after waiting this long.")]
        public float giveupDuration = 5;

        // Token: 0x040020E2 RID: 8418
        [Tooltip("The speed in degrees/second to approach the desired pitch/yaw by while the weapon should be raised.")]
        public float raisedApproachSpeed = 720f;

        // Token: 0x040020E3 RID: 8419
        [Tooltip("The speed in degrees/second to approach the desired pitch/yaw by while the weapon should be lowered.")]
        public float loweredApproachSpeed = 360f;

        // Token: 0x040020E4 RID: 8420
        [Tooltip("The smoothing time for the motion.")]
        public float smoothTime = 0.1f;

        // Token: 0x040020E5 RID: 8421
        [Tooltip("Whether or not the character can do full 360 yaw turns.")]
        public bool fullYaw = false;
        private float giveupTimer;
        public bool isOutsideOfRange { get; private set; }
        private AimAnimator.AimAngles overshootAngles;

        private void ApproachDesiredAngles()
        {
            AimAnimator.AimAngles aimAngles;
            float maxSpeed;
            if (this.shouldGiveup)
            {
                aimAngles = new AimAnimator.AimAngles
                {
                    pitch = 0f,
                    yaw = 0f
                };
                maxSpeed = this.loweredApproachSpeed;
            }
            else
            {
                aimAngles = this.clampedLocalAnglesToAimVector;
                maxSpeed = this.raisedApproachSpeed;
            }
            float yaw;
            if (this.fullYaw)
            {
                yaw = NormalizeAngle(Mathf.SmoothDampAngle(this.currentLocalAngles.yaw, aimAngles.yaw, ref this.smoothingVelocity.yaw, this.smoothTime, maxSpeed, Time.deltaTime));
            }
            else
            {
                yaw = Mathf.SmoothDamp(this.currentLocalAngles.yaw, aimAngles.yaw, ref this.smoothingVelocity.yaw, this.smoothTime, maxSpeed, Time.deltaTime);
            }
            this.currentLocalAngles = new AimAnimator.AimAngles
            {
                pitch = Mathf.SmoothDampAngle(this.currentLocalAngles.pitch, aimAngles.pitch, ref this.smoothingVelocity.pitch, this.smoothTime, maxSpeed, Time.deltaTime),
                yaw = yaw
            };
        }

        // Token: 0x06001B08 RID: 6920 RVA: 0x00073888 File Offset: 0x00071A88
        private void ResetGiveup()
        {
            this.giveupTimer = this.giveupDuration;
        }

        // Token: 0x06001B09 RID: 6921 RVA: 0x00073898 File Offset: 0x00071A98
        private void UpdateGiveup()
        {
            if (this.overshootAngles.pitch > this.pitchGiveupRange || (!this.fullYaw && this.overshootAngles.yaw > this.yawGiveupRange))
            {
                this.giveupTimer -= Time.deltaTime;
                this.isOutsideOfRange = true;
                return;
            }
            this.isOutsideOfRange = false;
            this.ResetGiveup();
        }

        // Token: 0x170001D4 RID: 468
        // (get) Token: 0x06001B0A RID: 6922 RVA: 0x000738FA File Offset: 0x00071AFA
        private bool shouldGiveup
        {
            get
            {
                return this.giveupTimer <= 0f;
            }
        }
    }
}
