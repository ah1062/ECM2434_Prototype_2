using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private Camera _mainCamera;
    private bool accusing = false;
    public TMP_Text characterText;
    private GameObject lineup;
    private GameObject clueParent;

    GameLogic gl;


    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        gl = GameObject.Find("LogicObject").GetComponent<GameLogic>();
        lineup = GameObject.Find("AccuseToggleBackground");
        
        clueParent = GameObject.Find("CluesParentBackground");
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
                if (hit.collider.gameObject.name == "AccuseToggle") {
                    GameObject g = hit.collider.gameObject;
                    SpriteRenderer sr = g.GetComponent<SpriteRenderer>();

                    if (!accusing) {
                        accusing = true;
                        sr.sprite = Resources.Load<Sprite>("accuse_sprite_engaged");
                    }
                    else {
                        accusing = false;
                        sr.sprite = Resources.Load<Sprite>("accuse_sprite");
                    } 
                        
                }


                if (gl.GetCorrectSuspect() != null) {
                    if (accusing & hit.collider.gameObject.name.Contains(gl.GetCorrectSuspect()))
                    {
                        Debug.Log("CORRECT");
                        Destroy(hit.collider.gameObject);
                    }
                    else if (hit.collider.gameObject.name.Contains("Suspect Slot")) {
                        if (gl.suspectDescriptions != null) {
                            characterText.text = gl.suspectDescriptions[hit.collider.gameObject.name];
                        }
                    }
                }

                if (hit.collider.gameObject.name.Contains("ClueButton")) {
                    if (gl.GetClues() != null) {
                        string name = hit.collider.gameObject.name;
                        string code = string.Format("{0}", name[name.Length-1]);
                        characterText.text = gl.GetClues()[Convert.ToInt32(code)];
                    }
                }
            }
        }
    }
}
