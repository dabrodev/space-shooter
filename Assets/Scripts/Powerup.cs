using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3 (adjust in the inspector)
        //when we leave the screen, destroy the object
    }

    //OnTriggerCollision
    //Only be collectable by the Player
    //on collected, destroy
}
