using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectStar : MonoBehaviour
{
    public static int objects = 0;
    public AudioSource collectSound;

    // Use this for initialization
    void Awake()
    {
        objects++;
    }

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
            objects--;
        gameObject.SetActive(false);
        collectSound.Play();
    }
}
