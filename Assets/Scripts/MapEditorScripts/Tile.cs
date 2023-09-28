using UnityEngine;

public class Tile : MonoBehaviour
{

    [SerializeField] GameObject highlight;

    public Vector2 loc;

    public TileSO tileRef;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = tileRef.texture;
    }

    public void UpdateTile(TileSO newTile)
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
        MapGenerator.mapGenerator.mouseDown = true;
        MapGenerator.mapGenerator.startTile = loc;
    }

    private void OnMouseUp()
    {
        MapGenerator.mapGenerator.mouseDown = false;
        MapGenerator.mapGenerator.MassUpdateTiles();
    }
    private void OnMouseEnter()
    {
        MapGenerator.mapGenerator.endTile = loc;
    }
}
