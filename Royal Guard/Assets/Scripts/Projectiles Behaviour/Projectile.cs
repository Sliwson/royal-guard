using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float zDestroy = 0f;
    [SerializeField]
    private int damage = 1;

    public void Push(Vector2 velocity)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = velocity;
    }       

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public int GetProjectileDamage()
    {
        return damage;
    }

    void Update () {
        if (transform.position.y < zDestroy)
            DestroyProjectile();
	}
}
