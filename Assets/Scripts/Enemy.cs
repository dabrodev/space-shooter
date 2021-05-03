using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed = 4.0f;
   
    //private Vector3 _enemyPosition = new Vector3(Random.Range(-9.5f,9.5f), 11, 0);

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        //move down at 4 meters per second
        
        //if bottom of screen
        //respawn at top with a new random x position

        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime); 

        if (transform.position.y < -6.0f) 
        {
            transform.position = new Vector3(Random.Range(-9.5f,9.5f), 11, 0);
        }

        
    }
}
