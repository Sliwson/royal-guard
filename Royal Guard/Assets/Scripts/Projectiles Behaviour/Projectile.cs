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
    [SerializeField]
    private GameObject alertPrefab;

    private Collider2D collider2D;
    private Vector2 pushVelocity = Vector2.zero;
    private Transform alertParent;
    private Alert alertScript = null;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();

        alertParent = GameObject.FindGameObjectWithTag("Alerts").transform;

        SpawnAlert();
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

        if (alertScript != null)
            alertScript.DestroyAlert();
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

        if (alertScript != null)
            alertScript.UpdateAlert(transform);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Physics2D.IgnoreCollision(collision.collider, collider2D);
        }
    }

    private void SpawnAlert()
    {
        GameObject prefab = Instantiate(alertPrefab, transform.position, Quaternion.identity, alertParent) as GameObject;

        alertScript = prefab.GetComponent<Alert>();

        alertScript.SpawnAlert(transform);
    }
}
