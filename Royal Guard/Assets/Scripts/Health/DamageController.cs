using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    private Health health;
    private AnimationController animationController;
    private ProjectileManager projectileManager;

    private void Start()
    {
        health = GetComponent<Health>();
        animationController = GetComponent<AnimationController>();
        projectileManager = GameObject.FindGameObjectWithTag("ProjectileManager").GetComponent<ProjectileManager>();
    }

    private void DealDamage(int damage)
    {
        health.Reduce(damage);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();

            DealDamage(projectile.GetProjectileDamage());

            animationController.TriggerAnimation(CharacterAnimations.Hit);

            projectileManager.KnockbackProjectile(projectile);

            projectile.DisableCollider();
        }
    }
}
