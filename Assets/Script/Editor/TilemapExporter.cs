using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapExporter : EditorWindow
{
    public Tilemap gameMap;
    public string mapName = "NewMap";

    private Dictionary<TileBase, string> terrainLookup = new Dictionary<TileBase, string>();

    [MenuItem("Tools/Tilemap Exporter")]
    public static void ShowWindow()
    {
        GetWindow<TilemapExporter>("Tilemap Exporter");
    }

    private void OnGUI()
    {
        GUILayout.Label("Tilemap Exporter", EditorStyles.boldLabel);

        gameMap = (Tilemap)EditorGUILayout.ObjectField("Tilemap", gameMap, typeof(Tilemap), true);
        mapName = EditorGUILayout.TextField("Map Name", mapName);

        if (GUILayout.Button("Export to JSON"))
        {
            if (gameMap == null)
            {
                Debug.LogWarning("Tilemap not assigned!");
                return;
            }

            Export();
        }
    }

    private void Export()
    {
        MapData mapData = new MapData();
        mapData.mapName = mapName;

        // Calculate bounds
        BoundsInt bounds = gameMap.cellBounds;
        mapData.width = bounds.size.x;
        mapData.height = bounds.size.y;

        // Build tile list
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            TileBase tile = gameMap.GetTile(pos);
            if (tile == null) continue;

            string terrainType = tile.name; // Use tile name for now

            TileData tileData = new TileData
            {
                x = pos.x,
                y = pos.y,
                terrainType = terrainType,
                movementCost = GetMovementCost(terrainType)
            };

            mapData.tiles.Add(tileData);
        }
    }

    private int GetMovementCost(string terrain)
    {
        // Basic example — customize this later
        return terrain switch
        {
            "grass" => 1,
            "forest" => 2,
            "mountain" => 3,
            "water" => -1,
            _ => 1,
        };
    }
}
