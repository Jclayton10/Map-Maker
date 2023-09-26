using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public struct ColorLink
{
    public Color color;
    public TileSO tileSO;
}

public class MapSaver : MonoBehaviour
{
    //Singleton
    public static MapSaver mapSaver;

    [SerializeField] List<ColorLink> links;
    [SerializeField] GameObject SaveObject;
    [SerializeField] Image textureShow;
    [SerializeField] Texture2D texture;
    [SerializeField] TMP_InputField fileName;

    private void Start()
    {
        mapSaver = this;
    }

    public void ShowSave()
    {
        SaveObject.SetActive(true);
        GenerateTexture2D();
    }

    public void DontShowSave()
    {
        SaveObject.SetActive(false);
    }

    public void GenerateTexture2D()
    {
        texture = new Texture2D(MapGenerator.mapGenerator.width, MapGenerator.mapGenerator.height);

        for(int i = 0; i<MapGenerator.mapGenerator.width; i++)
        {
            for(int f = 0; f < MapGenerator.mapGenerator.height; f++)
            {
                foreach(ColorLink colorLink in links)
                {
                    if(colorLink.tileSO == MapGenerator.mapGenerator.tiles[new Vector2(i, f)].tileRef)
                    {
                        texture.SetPixel(i, f, colorLink.color);
                        break;
                    }
                }
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.Apply();

        Sprite textureSprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(texture.width / 2.0f, texture.height / 2), (1.0f/32.0f));

        textureShow.sprite = textureSprite;
        Debug.Log($"Sprite Dimensions: {textureShow.sprite.texture.width} x {textureShow.sprite.texture.height}");
    }

    public void Save()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/MapSaves"))
            Directory.CreateDirectory(Application.persistentDataPath + "/MapSaves");

        if (fileName.text == "") return;

        string path = Application.persistentDataPath + "/MapSaves/" + fileName.text;

        File.WriteAllBytes(path, texture.EncodeToPNG());
        Debug.Log(path);
    }
}