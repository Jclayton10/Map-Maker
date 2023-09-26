using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //Singleton
    public static MapGenerator mapGenerator;

    public int width, height;
    [SerializeField] Tile tilePrefab;

    public TileSO selectedTileType;

    public Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();

    private void Start()
    {
        mapGenerator = this;

        width = PlayerPrefs.GetInt("MapWidth");
        height = PlayerPrefs.GetInt("MapHeight");

        GenerateMap();
    }

    private void GenerateMap()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for(int i = 0; i < width; i++)
        {
            for(int f = 0; f < height; f++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(i, f), Quaternion.identity);
                spawnedTile.name = $"Tile {i}, {f}";

                tiles[new Vector2(i, f)] = spawnedTile;
            }
        }
        Camera.main.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }
}
