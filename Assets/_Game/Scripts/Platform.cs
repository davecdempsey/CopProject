using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    public new Transform transform {
        get {
            if (_transform == null) {
                _transform = GetComponent<Transform>();
            }
            return _transform;
        }
    }

    public Rigidbody2D rb;
    public float multiplier;
    public float maxBounceAngle = 75.0f;

    public Rigidbody2D ballRB;
    public bool isBallAttached = true;
    public float initialForce = 100.0f;

    public Transform startingSpot;

    void Awake()
    {
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

        if (Input.GetKeyUp(KeyCode.Space)) {
            if (isBallAttached) {
                isBallAttached = false;
                ballRB.AddForce(Vector2.up * initialForce);
            }
        }
    }

    private void Move(Vector2 direction)
    {
        if (isBallAttached) {
            ballRB.velocity = direction * multiplier;
        }
        rb.velocity = direction * multiplier;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null) {
            Vector2 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float maxOffset = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            float bounceAngle = (offset / maxOffset) * maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -maxBounceAngle, maxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.rigidbody.velocity = rotation * Vector2.up * ball.rigidbody.velocity.magnitude;
        }
    }

    public void Reset ()
    {
        isBallAttached = true;
        ballRB.transform.position = startingSpot.position;
        ballRB.gameObject.SetActive(true);
    }
}
