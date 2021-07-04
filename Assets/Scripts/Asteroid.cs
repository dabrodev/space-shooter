using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private float _speed = 3.0f;
    private float _smooth = 20.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, 10 * _smooth * Time.deltaTime, Space.World);
       
    }
}