using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera _mainCamera;
    private char correctSuspect = '2';

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Button 0");
            
            Vector2 rayOrigin = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero);

            if (hit.collider != null)
            {
                // Handle the click here
                Debug.Log($"Clicked on {hit.collider.gameObject.name}");

                if (hit.collider.gameObject.name.Contains(correctSuspect))
                {
                    Debug.Log("CORRECT");
                }
            }
        }
    }
}
