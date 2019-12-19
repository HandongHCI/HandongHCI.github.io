using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyImageChange : MonoBehaviour
{
    public GameObject KeyDark1;
    public GameObject KeyDark2;
    public GameObject KeyDark3;
    public GameObject KeyDark4;

    public GameObject KeyBright1;
    public GameObject KeyBright2;
    public GameObject KeyBright3;
    public GameObject KeyBright4;

    public static int keyCount;
    int startCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        keyCount = startCount;
    }

    // Update is called once per frame
    void Update()
    {

        if(keyCount == 1){
            KeyDark1.gameObject.SetActive(false);
            KeyBright1.gameObject.SetActive(true);
        }
        else if(keyCount == 2){
            KeyDark2.gameObject.SetActive(false);
            KeyBright2.gameObject.SetActive(true);
        }
        else if(keyCount == 3){
            KeyDark3.gameObject.SetActive(false);
            KeyBright3.gameObject.SetActive(true);
        }
        else if(keyCount == 4){
            KeyDark4.gameObject.SetActive(false);
            KeyBright4.gameObject.SetActive(true);
        }
    }
}
