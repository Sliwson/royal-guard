using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float zDestroy = 0f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private float destroyWhenHitShieldFactor = 0.7f;

    private Collider2D collider2D;
    private Vector2 pushVelocity = Vector2.zero;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    public void Push(Vector2 velocity)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        pushVelocity = velocity;

        rigidbody2D.velocity = velocity;
    }       

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public void DisableCollider()
    {
        collider2D.enabled = false;
    }

    public void DisableColliderShieldHit()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        if (Mathf.Abs(rigidbody2D.velocity.x) < Mathf.Abs(destroyWhenHitShieldFactor * pushVelocity.x))
        {
            DisableCollider();
        }
    }

    public int GetProjectileDamage()
    {
        return damage;
    }

    void Update () {
        if (transform.position.y < zDestroy)
            DestroyProjectile();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(collision.collider, collider2D);
        }
    }
}
