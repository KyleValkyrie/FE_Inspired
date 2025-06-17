using UnityEngine;

public enum TileTerrain
{
    Plain,
    Forest,
    Mountain,
    Water,
    Road
}

public class Tile : MonoBehaviour
{
    public Vector3Int gridPosition;  // Position in the Tilemap grid
    public TileTerrain tileTerrain;

    [Header("Terrain Effects")]
    public int movementCost = 1;
    public int defenseBonus = 0;
    public bool isWalkable = true;

    [Header("Unit")]
    //public Unit occupyingUnit;

    [Header("Visuals")]
    [SerializeField] private GameObject highlightVisual;

    public void Initialize(Vector3Int gridPos, TileTerrain terrain)
    {
        gridPosition = gridPos;
        tileTerrain = terrain;

        // Optional: Set stats based on terrain
        switch (terrain)
        {
            case TileTerrain.Forest:
                movementCost = 2;
                defenseBonus = 1;
                break;
            case TileTerrain.Mountain:
                movementCost = 3;
                defenseBonus = 2;
                isWalkable = false;
                break;
            case TileTerrain.Water:
                isWalkable = false;
                break;
                // Add more if needed
        }
    }

    public void OnFocus()
    {
        if (highlightVisual != null)
            highlightVisual.SetActive(true);
    }

    public void OnDefocus()
    {
        if (highlightVisual != null)
            highlightVisual.SetActive(false);
    }

    //public bool HasUnit()
    //{
    //    return occupyingUnit != null;
    //}

    //public void SetUnit(Unit unit)
    //{
    //    occupyingUnit = unit;
    //}

    //public void ClearUnit()
    //{
    //    occupyingUnit = null;
    //}
}
