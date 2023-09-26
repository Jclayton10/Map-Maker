using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;


    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
        */

        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(dragSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.A))
            transform.position += new Vector3(-dragSpeed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.S))
            transform.position += new Vector3(0, -dragSpeed * Time.deltaTime, 0);
        if (Input.GetKey(KeyCode.W))
            transform.position += new Vector3(0, dragSpeed * Time.deltaTime, 0);
    }
}
