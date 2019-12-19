using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{

    public static int hp;      // The player's score.


    Text text;

    // Start is called before the first frame update
    void Awake()
    {
        // Set up the reference.
        text = GetComponent<Text>();

        // Reset the score.
        hp = 100;

    }

    // Update is called once per frame
    void Update()
    {
        text.text = hp + " / 100";
    }
}
