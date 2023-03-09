using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    Player playerScript;
    public Dictionary<string, GameObject> suspectObjects;
    public Dictionary<string, string> suspectDescriptions;
    private string[] clues;
    private static string correctSuspect;

    private void Awake() {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        
        GameObject g;
        suspectObjects = new Dictionary<string, GameObject>();
        suspectDescriptions = new Dictionary<string, string>();

        for (int i = 1; i <= 5; i++) {
            g = GameObject.Find(string.Format("Suspect Slot {0}", i.ToString()));
            suspectObjects.Add(string.Format("Suspect Slot {0}", i.ToString()), g);
        }

        SetSuspectSprites("42315");
        SetCorrectSuspect("1");
        
        string[] descriptions = new string[5]{"CHARACTER A", "CHARACTER B", "CHARACTER C", "CHARACTER D", "CHARACTER E"};
        SetSuspectDescriptions(descriptions);

        clues = new string[10] {"A","B","C","D","E","F","G","H","I","J"};
    }
    public string GetCorrectSuspect() {
        return correctSuspect;
    }

    public string[] GetClues() {
        return clues;
    }

    public void SetSuspectSprites(string sprite_codes) {
        GameObject g;
        SpriteRenderer sr;
        Sprite s;
        
        for (int i = 1; i <= 5; i++) {
            g = suspectObjects[string.Format("Suspect Slot {0}", i.ToString())];
            sr = g.GetComponent<SpriteRenderer>();

            s = Resources.Load<Sprite>(string.Format("character_sprite_{0}", sprite_codes[i-1]));

            if (s != null) {
                sr.sprite = s;
            } else {
                Debug.Log(string.Format("SPRITE CODE {0} NOT FOUND", i.ToString()));
            }
        }
    }

    public void SetClueDescriptions(string[] descriptions) {
        clues = descriptions;
    }

    public void SetSuspectDescriptions(string[] descriptions) {
        for (int i = 1; i <= 5; i++) {
            suspectDescriptions.Add(string.Format("Suspect Slot {0}", i.ToString()), descriptions[i-1]);
        }
    }

    public void SetCorrectSuspect(string number) {
        if (suspectObjects != null) {
            correctSuspect = number;
        }
    }
}
