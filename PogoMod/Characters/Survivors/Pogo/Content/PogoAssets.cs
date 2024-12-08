using RoR2;
using UnityEngine;
using PogoMod.Modules;
using System;
using RoR2.Projectile;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using R2API;
using Rewired.ComponentControls.Effects;

namespace PogoMod.Survivors.Pogo
{
    public static class PogoAssets
    {
        internal static AssetBundle mainAssetBundle;
        internal static Color pogoColor = new Color(255f / 255f, 171f / 255f, 241f / 255f);

        // particle effects
        public static GameObject swordSwingEffect;
        public static GameObject swordHitImpactEffect;

        public static GameObject bombExplosionEffect;

        // networked hit sounds
        public static NetworkSoundEventDef swordHitSoundEvent;

        //projectiles
        public static GameObject bombProjectilePrefab;



        public static GameObject leftFingergunIndicator;
        public static GameObject rightFingergunIndicator;

        public static void Init(AssetBundle assetBundle)
        {

            mainAssetBundle = assetBundle;

            swordHitSoundEvent = Content.CreateAndAddNetworkSoundEventDef("HenrySwordHit");

            CreateEffects();

            CreateProjectiles();
        }

        #region effects
        private static void CreateEffects()
        {
            CreateBombExplosionEffect();

            swordSwingEffect = mainAssetBundle.LoadEffect("HenrySwordSwingEffect", true);
            swordHitImpactEffect = mainAssetBundle.LoadEffect("ImpactHenrySlash");


            leftFingergunIndicator = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Engi/EngiMissileTrackingIndicator.prefab").WaitForCompletion().InstantiateClone("LeftFingergunTrackingIndicator");
            leftFingergunIndicator.AddComponent<NetworkIdentity>();
            leftFingergunIndicator.transform.Find("Base Container").GetComponent<RotateAroundAxis>().enabled = false;
            leftFingergunIndicator.transform.Find("Base Container/Base Core").GetComponent<SpriteRenderer>().sprite = mainAssetBundle.LoadAsset<Sprite>("texUIPogoLeftFingergunIndicator");
            leftFingergunIndicator.transform.Find("Base Container/Base Core").GetComponent<SpriteRenderer>().color = new Color(0.969f, 0.482f, 0.651f, 0.702f);


            rightFingergunIndicator = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Engi/EngiMissileTrackingIndicator.prefab").WaitForCompletion().InstantiateClone("RightFingergunTrackingIndicator");
            rightFingergunIndicator.AddComponent<NetworkIdentity>();
            rightFingergunIndicator.transform.Find("Base Container").GetComponent<RotateAroundAxis>().enabled = false;
            rightFingergunIndicator.transform.Find("Base Container/Base Core").GetComponent<SpriteRenderer>().sprite = mainAssetBundle.LoadAsset<Sprite>("texUIPogoRightFingergunIndicator");
            rightFingergunIndicator.transform.Find("Base Container/Base Core").GetComponent<SpriteRenderer>().color = new Color(0.573f, 0.482f, 0.969f, 0.702f);
        }

        private static void CreateBombExplosionEffect()
        {
            bombExplosionEffect = mainAssetBundle.LoadEffect("BombExplosionEffect", "HenryBombExplosion");

            if (!bombExplosionEffect)
                return;

            ShakeEmitter shakeEmitter = bombExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitter.amplitudeTimeDecay = true;
            shakeEmitter.duration = 0.5f;
            shakeEmitter.radius = 200f;
            shakeEmitter.scaleShakeRadiusWithLocalScale = false;

            shakeEmitter.wave = new Wave
            {
                amplitude = 1f,
                frequency = 40f,
                cycleOffset = 0f
            };

        }
        #endregion effects

        #region projectiles
        private static void CreateProjectiles()
        {
            CreateBombProjectile();
            Content.AddProjectilePrefab(bombProjectilePrefab);
        }

        private static void CreateBombProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            bombProjectilePrefab = Asset.CloneProjectilePrefab("CommandoGrenadeProjectile", "HenryBombProjectile");

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(bombProjectilePrefab.GetComponent<ProjectileImpactExplosion>());
            ProjectileImpactExplosion bombImpactExplosion = bombProjectilePrefab.AddComponent<ProjectileImpactExplosion>();
            
            bombImpactExplosion.blastRadius = 16f;
            bombImpactExplosion.blastDamageCoefficient = 1f;
            bombImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.lifetime = 12f;
            bombImpactExplosion.impactEffect = bombExplosionEffect;
            bombImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("HenryBombExplosion");
            bombImpactExplosion.timerAfterImpact = true;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = bombProjectilePrefab.GetComponent<ProjectileController>();

            if (mainAssetBundle.LoadAsset<GameObject>("HenryBombGhost") != null)
                bombController.ghostPrefab = mainAssetBundle.CreateProjectileGhostPrefab("HenryBombGhost");
            
            bombController.startSound = "";
        }
        #endregion projectiles
    }
}
