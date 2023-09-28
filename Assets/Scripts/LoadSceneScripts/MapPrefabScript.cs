using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MapPrefabScript : MonoBehaviour
{
    [SerializeField] TMP_Text mapName;
    [SerializeField] Image mapImage;
    [SerializeField] string fileLoc;
    [SerializeField] Texture2D texTmp;

    public void InitializeMap(string fileLoc)
    {
        this.fileLoc = fileLoc;
        Debug.Log("Creating a map tile");
        
        mapName.text = fileLoc.Replace(Application.persistentDataPath, "").Replace("/MapSaves\\","").Replace(".save","");

        WWW www = new WWW(fileLoc);
        texTmp = new Texture2D(128, 128, TextureFormat.RGBAFloat, false);
        www.LoadImageIntoTexture(texTmp);

        texTmp.filterMode = FilterMode.Point;

        Sprite textureSprite = Sprite.Create(texTmp, new Rect(0.0f, 0.0f, texTmp.width, texTmp.height), new Vector2(texTmp.width / 2.0f, texTmp.height / 2), (1.0f / 32.0f));

        mapImage.sprite = textureSprite;
    }

    public void LoadScene()
    {
        PlayerPrefs.SetString("File Location", fileLoc);
        PlayerPrefs.SetInt("MapWidth", texTmp.width);
        PlayerPrefs.SetInt("MapHeight", texTmp.height);
        SceneManager.LoadScene("MapEditor");
    }
}
