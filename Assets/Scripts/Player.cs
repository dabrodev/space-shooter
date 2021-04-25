using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 3.5f;

    Vector3 myPosition;
 

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // new Vector(1, 0, 0) * -1 * 3.5f * real time 
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);

        // if player horizontal position x is 9 or greater
        // the position.x = 9.26f
        //the same for x=-9.26f
        // if player vertical position y is 6 or -4
        // set the position.y accordinlgly to y=6 or y=-4

        if (transform.position.x >= 9.26f ) {
            transform.position = new Vector3(9.26f, transform.position.y, 0);
        } 
        else if (transform.position.x <=-9.26f) {
            transform.position = new Vector3(-9.26f, transform.position.y, 0);
        } 
        else if (transform.position.y >= 6) {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
        else if (transform.position.y <= -4) {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

    }
}
