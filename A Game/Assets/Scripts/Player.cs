using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Settings")] 
    public float health = 5;
    
    //Movement Variables
    [Header("Movement")]
    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 5.5f;
    public float minX = -8.4f;
    public float maxX = 80;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if (!doMovement) return;

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        

        // float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        
        transform.position = pos;

    }
}
