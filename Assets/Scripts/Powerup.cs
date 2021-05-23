using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3 (adjust in the inspector)
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //when we leave the screen, destroy the object
        if (transform.position.y < -6.0) {
            Destroy(this.gameObject);
        }
    }

    //OnTriggerCollision
    //Only be collectable by the Player
    //on collected, destroy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player");
        {
            
            Destroy(this.gameObject);
        }
    }
}
