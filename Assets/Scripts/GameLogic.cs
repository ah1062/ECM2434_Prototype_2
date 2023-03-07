using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public Dictionary<int, GameObject> suspectObjects;
    public static string correctSuspect;

    private void Awake() {
        GameObject g;
        suspectObjects = new Dictionary<int, GameObject>();

        for (int i = 1; i <= 5; i++) {
            g = GameObject.Find(string.Format("Suspect Slot {0}", i.ToString()));
            Debug.Log(g.name);
            suspectObjects.Add(i, g);
        }

        SetSuspectSprites("12345");
        SetCorrectSuspect("4");
    }
    public string GetCorrectSuspect() {
        return correctSuspect;
    }

    public void SetSuspectSprites(string sprite_codes) {
        GameObject g;
        SpriteRenderer sr;
        Sprite s;
        
        for (int i = 1; i <= 5; i++) {
            g = suspectObjects[i];
            sr = g.GetComponent<SpriteRenderer>();

            s = Resources.Load<Sprite>(string.Format("character_sprite_{0}", sprite_codes[i-1]));

            if (s != null) {
                sr.sprite = s;
            } else {
                Debug.Log(string.Format("SPRITE CODE {0} NOT FOUND", i.ToString()));
            }
        }
    }

    public void SetCorrectSuspect(string number) {
        if (suspectObjects != null) {
            correctSuspect = number;
        }
    }
}
