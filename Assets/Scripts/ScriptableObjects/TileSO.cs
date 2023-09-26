using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/TileType")]
public class TileSO : ScriptableObject
{
    public string tileName;
    public Sprite texture;
}
