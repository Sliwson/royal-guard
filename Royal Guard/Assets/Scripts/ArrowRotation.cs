using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour {
    private Rigidbody2D rigidbody2D;    

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 velocity = rigidbody2D.velocity;

        float angle = -Vector2.SignedAngle(velocity, Vector2.right);

        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
