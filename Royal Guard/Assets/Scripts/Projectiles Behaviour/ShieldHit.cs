using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHit : MonoBehaviour {
    private void OnCollisionExit2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();

            projectile.DisableColliderShieldHit();
        }
    }
}
