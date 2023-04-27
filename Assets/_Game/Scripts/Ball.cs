using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 10f;

    private void Awake ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate ()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }
}
