using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Projectile"))
        {
            Projectile projectile = collider.gameObject.GetComponent<Projectile>();

            projectile.DisableCollider();
        }
    }
}
