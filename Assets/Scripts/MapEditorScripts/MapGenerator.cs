using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct KeyCodeTilePairs
{
    public KeyCode key;
    public TileSO tileSO;
}

public class MapGenerator : MonoBehaviour
{
    //Singleton
    public static MapGenerator mapGenerator;

    public int width, height;
    [SerializeField] Tile tilePrefab;
    [SerializeField] Texture2D texTmp;

    public TileSO selectedTileType;

    public Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();
    public List<KeyCodeTilePairs> keyCodeTilePairs = new List<KeyCodeTilePairs>();

    public Vector2 startTile;
    public Vector2 endTile;

    public bool mouseDown = false;

    private void Start()
    {
        mapGenerator = this;

        width = PlayerPrefs.GetInt("MapWidth");
        height = PlayerPrefs.GetInt("MapHeight");

        GenerateMap();
        if(PlayerPrefs.GetInt("IsLoading") == 0)
        {
            PopulateMap();
        }
    }

    public void Update()
    {
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.point);
            }
        }
        if (Input.anyKeyDown)
        {
            foreach(KeyCodeTilePairs pair in keyCodeTilePairs)
            {
                if (Input.GetKeyDown(pair.key))
                    selectedTileType = pair.tileSO;
            }
        }
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
                spawnedTile.loc = new Vector2(i, f);

                tiles[new Vector2(i, f)] = spawnedTile;
            }
        }
        Camera.main.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    private void PopulateMap()
    {
        Debug.Log("Populating Map");
        WWW www = new WWW(PlayerPrefs.GetString("File Location"));
        texTmp = new Texture2D(128, 128, TextureFormat.RGBAFloat, false);
        texTmp.filterMode = FilterMode.Point;
        www.LoadImageIntoTexture(texTmp);

        for(int i = 0; i < texTmp.width; i++)
        {
            for(int f = 0; f < texTmp.height; f++)
            {
                foreach(ColorLink colorLink in MapSaver.mapSaver.links)
                {
                    Debug.Log($"Tile ({i}, {f}), Color on Tile: {texTmp.GetPixel(i,f).r}, ColorLink: {colorLink.color.r}");
                    if ((int) (colorLink.color.r * 1000) == (int) (texTmp.GetPixel(i,f).r * 1000))
                    {
                        tiles[new Vector2(i, f)].UpdateTile(colorLink.tileSO);
                    }
                }
            }
        }
    }

    public void MassUpdateTiles()
    {
        for (int i = (int)((startTile.x < endTile.x) ? startTile. x: endTile.x); i <= (int)((startTile.x > endTile.x) ? startTile.x : endTile.x); i++)
        {
            for (int f = (int)((startTile.y < endTile.y) ? startTile.y : endTile.y); f <= (int)((startTile.y > endTile.y) ? startTile.y : endTile.y); f++)
            {
                tiles[new Vector2(i, f)].UpdateTile(selectedTileType);
            }
        }
    }
}
