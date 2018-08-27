using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShieldHit : MonoBehaviour {
    [SerializeField]
    private CameraShakeCreator cameraShakeParameters;

    private ShieldAnimationController shieldAnimationController;

    private void Start()
    {
        shieldAnimationController = GetComponent<ShieldAnimationController>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();

            projectile.DisableColliderShieldHit();

            shieldAnimationController.TriggerAnimation(ShieldAnimations.Hit);

            CameraShakeTrigger.ShakeCamera(cameraShakeParameters);
        }
    }
}
