using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject highlight;

    public TileSO tileRef;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = tileRef.texture;
    }

    private void UpdateTile(TileSO newTile)
    {
        tileRef = newTile;
        Debug.Log(tileRef);
        GetComponent<SpriteRenderer>().sprite = tileRef.texture;
    }

    private void OnMouseOver()
    {
        highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

    private void OnMouseDown()
    {
        UpdateTile(MapGenerator.mapGenerator.selectedTileType);
    }
}
