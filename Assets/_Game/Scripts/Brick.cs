using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
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

    [SerializeField]
    private Rigidbody2D _rigidbody2D;
    public new Rigidbody2D rigidbody2D {
        get {
            if (_rigidbody2D == null) {
                _rigidbody2D = GetComponent<Rigidbody2D>();
            }
            return _rigidbody2D;
        }
    }

    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public SpriteRenderer spriteRenderer {
        get {
            if (_spriteRenderer == null) {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
            return _spriteRenderer;
        }
    }

    public Vector2 size => spriteRenderer.size * transform.localScale;

    void Awake ()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
