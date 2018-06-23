using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField]
    private float zDestroy = 0f;

    public void Push(Vector2 velocity)
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.velocity = velocity;
    }
	
	void Update () {
        if (transform.position.y < zDestroy)
            Destroy(gameObject);
	}
}
