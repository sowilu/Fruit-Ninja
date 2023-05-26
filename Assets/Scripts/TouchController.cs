using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public Transform cursor;
    
    //detect if the player is touching the screen and only if player swipes activate cursor
    private bool isTouching;
    private Vector2 touchPosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouching = true;
            cursor.gameObject.SetActive(true);
        }
        if(Input.GetMouseButtonUp(0))
        {
            isTouching = false;
            cursor.gameObject.SetActive(false);
        }
            
        var mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        
        var position = Camera.main.ScreenToWorldPoint(mousePosition);

        cursor.position = position;
    }
}
