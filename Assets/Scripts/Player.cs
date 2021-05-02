﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private Vector3 _laserOffset = new Vector3(0,0.8f,0);
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _nextFire = -1.0f;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        PlayerMovement();
        PlayerTeleport();
        PlayerLaser();
    }

    void PlayerMovement() 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);
    }
    void PlayerTeleport() 
    {
        if (transform.position.x >= 10.0f )
        {
            transform.position = new Vector3(-10.0f, transform.position.y, 0);
        } 
        else if (transform.position.x <=-10.0f) {
            transform.position = new Vector3(10.0f, transform.position.y , 0);
        } 
        else if (transform.position.y >= 6.5f) {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
        else if (transform.position.y <= -4.5f) {
            transform.position = new Vector3(transform.position.x, 6.5f, 0);
        }
    }
    void RestrictMovement() 
    {   
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.26f,9.26f), Mathf.Clamp(transform.position.y, -4.0f,6.0f), 0);
    }

    void PlayerLaser() 
    {       
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextFire)  
        {
            
            _nextFire = Time.time + _fireRate;
            
            Instantiate(_laserPrefab, transform.position + _laserOffset, Quaternion.identity);
        }
    }    
}
