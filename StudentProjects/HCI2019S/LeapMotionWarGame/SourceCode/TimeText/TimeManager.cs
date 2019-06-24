using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int time;
    public int seconds;
    Text text;
    public PlayerHealth playerHealth;

    void Start()
    {
        text = GetComponent<Text>();
        time = (int)(playerHealth.currentHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        time = (int)(playerHealth.currentHealth);
        print("time: "+time+", player currentHealth: "+playerHealth.currentHealth);
        text.text = "Time: " + time; 
    }
}

