using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private Vector3 _laserOffset = new Vector3(0,0.8f,0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerTeleport();
        PlayerLaser();

    }

    void PlayerMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // new Vector(1, 0, 0) * -1 * 3.5f * real time 
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * _speed * Time.deltaTime);
    }
    void PlayerTeleport() 
    {
        // teleport
        // if player horizontal position x is 9 or greater
        // the position.x = 9.26f
        //the same for x=-9.26f
        // if player vertical position y is 6 or -4
        // set the position.y accordinlgly to y=6 or y=-4
        
        if (transform.position.x >= 10.0f ) {
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
    void RestrictMovement() {   
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -9.26f,9.26f), Mathf.Clamp(transform.position.y, -4.0f,6.0f), 0);
    }

    void PlayerLaser() {       
        
        // If I hit space key
        // spawn an object

        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(_laserPrefab, transform.position + _laserOffset, Quaternion.identity);
        }
    }    
}
