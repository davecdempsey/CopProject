using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
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

    public BoxCollider2D boxCollider2D;
    private Vector2 brickAreaSize => boxCollider2D.size * transform.localScale;

    private Vector2 topLeft => new Vector2(transform.position.x - brickAreaSize.x / 2.0f + halfBrickSize.x,
                                           transform.position.y + brickAreaSize.y / 2.0f - halfBrickSize.y);

    public int columnCount = 10;
    public int rowCount = 5;

    // Prefab Brick
    public GameObject brickPrefab;
    public Brick brick;

    private Vector2 brickSize => brick.size;
    private Vector2 halfBrickSize => brickSize / new Vector2(2.0f, 2.0f);

    // Generated Bricks
    public List<Brick> bricks = new List<Brick>();

    public Vector2 startingPosition;

    public float horizontalSpacing;

    public float verticalSpacing;


    void Awake ()
    {
    }

    // Start is called before the first frame update
    void Start () => GenerateBricks();

    private void GenerateBricks()
    {
        DestroyAllBricks();
        FindSpacing();
        FindStartingSpot();

        Vector2 position = startingPosition;

        for (int i = 0; i < rowCount; i += 1) {
            for (int j = 0; j < columnCount; j += 1) {
                float x = position.x + j * brickSize.x;
                float y = position.y - i * brickSize.y;
                position = new Vector2(x, y);
                CreateBrick(position);
            }
        }
    }

    private void CreateBrick(Vector2 position)
    {
        Brick newBrick = Instantiate(brickPrefab, position, Quaternion.identity, null).GetComponent<Brick>();
        bricks.Add(newBrick);
    }

    private void FindSpacing()
    {
        horizontalSpacing = brickAreaSize.x / columnCount;
        verticalSpacing = brickAreaSize.y / rowCount;
    }

    private void FindStartingSpot ()
    {
        startingPosition = topLeft;
    }

    private void DestroyAllBricks()
    {
        for (int i = 0; i < bricks.Count; i += 1) {
#if UNITY_EDITOR
            Destroy(bricks[i]);
#else
            DestoryImmediate(bricks[i]);
#endif
        }
        bricks.Clear();
    }
}
