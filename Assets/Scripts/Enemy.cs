using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _enemySpeed = 4.0f;

    void Start()
    {
         
    }

    void Update()
    {
        transform.Translate(Vector3.down * _enemySpeed * Time.deltaTime); 

        if (transform.position.y < -6.0f) 
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(randomX, 11, 0);
        }
    }
}