using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneController : MonoBehaviour
{
    [SerializeField] Transform contentHolder;
    [SerializeField] GameObject mapPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading Maps");
        if (!Directory.Exists(Application.persistentDataPath + "/MapSaves"))
            return;

        Debug.Log("Directory Exists");

        string[] files = Directory.GetFiles(Application.persistentDataPath + "/MapSaves", "*.save");

        foreach (string file in files)
        {
            MapPrefabScript newMap = Instantiate(mapPrefab, contentHolder).GetComponent<MapPrefabScript>();
            newMap.InitializeMap(file);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
