using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    private Health health;
    private AnimationController animationController;

    private void Start()
    {
        health = GetComponent<Health>();
        animationController = GetComponent<AnimationController>();
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

            projectile.Push(new Vector2(10f,0f));

            projectile.DisableCollider();
        }
    }
}
