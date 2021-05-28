using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private int powerupID;

    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.0) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if (player != null)
            {
                if (powerupID == 0)
                {
                    player.TripleShotActive();
                }
                else if (powerupID == 1)
                {
                    Debug.Log("Speed Powerup");
                }
                else if (powerupID == 2)
                {
                    Debug.Log("Shields Powerup");
                }
            }
            Destroy(this.gameObject);
        }
    }
}
