using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class CreateMap : MonoBehaviour
{
    [SerializeField] TMP_InputField width, height;
    public void SetPlayerPrefs()
    {
        PlayerPrefs.SetInt("MapWidth", Convert.ToInt32(width.text));
        PlayerPrefs.SetInt("MapHeight", Convert.ToInt32(height.text));

        //Should load the map editor
        SceneManager.LoadScene(1);
    }
}
