using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData
{
    public string mapName;
    public int width;
    public int height;
    public List<TileData> tiles = new List<TileData>();
}
