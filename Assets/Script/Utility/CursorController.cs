using UnityEngine;

public class CursorController : MonoBehaviour
{
    public float moveDelay = 0.15f; // delay between movements
    public float tileSize = 1f;     // matches your grid's tile size

    private float moveTimer = 0f;
    private Vector2Int cursorPosition = Vector2Int.zero;

    void Update()
    {
        moveTimer += Time.deltaTime;

        if (moveTimer >= moveDelay)
        {
            Vector2Int input = GetInput();
            if (input != Vector2Int.zero)
            {
                cursorPosition += input;
                MoveCursor();
                moveTimer = 0f;
            }
        }
    }

    Vector2Int GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) return Vector2Int.up;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) return Vector2Int.down;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) return Vector2Int.left;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) return Vector2Int.right;
        return Vector2Int.zero;
    }

    void MoveCursor()
    {
        transform.position = new Vector3(cursorPosition.x * tileSize, cursorPosition.y * tileSize, 0);
    }
}
