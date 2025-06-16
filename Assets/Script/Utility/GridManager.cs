using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject tilePrefab;
    public float tileSize = 1f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int y = height - 1; y >= 0; y--) // top to bottom
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 pos = new Vector3(x * tileSize, y * tileSize, 0);
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity, transform);
                tile.name = $"Tile {x},{y}";           
            }
        }
        // Offset the parent(this GameObject) to center the grid
        float offsetX = (width - 1) * tileSize / 2f;
        float offsetY = (height - 1) * tileSize / 2f;

        transform.position = new Vector3(-offsetX, -offsetY, 0);
    }
}
