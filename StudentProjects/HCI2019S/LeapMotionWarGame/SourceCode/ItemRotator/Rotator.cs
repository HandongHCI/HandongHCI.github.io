using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    // public AudioSource eatingSound;

    /*   void Start()
    {
        eatingSound = GetComponent<AudioSource>();
    }*/


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

    }

}
