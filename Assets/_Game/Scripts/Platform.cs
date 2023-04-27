using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public new Transform transform;
    public Rigidbody2D rb;
    public float multiplier;

    void Awake()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) {
            Move(Vector2.left);
        } else if (Input.GetKey(KeyCode.D)) {
            Move(Vector2.right);
        } else {
            Move(Vector2.zero);
        }
    }

    private void Move(Vector2 direction)
    {
        rb.velocity = direction * multiplier;
    }
}
