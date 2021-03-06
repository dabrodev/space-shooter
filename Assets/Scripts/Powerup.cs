using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private AudioClip _powerupSound;

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

            AudioSource.PlayClipAtPoint(_powerupSound, transform.position);

            switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        Debug.Log("Speed Powerup");
                        player.SpeedPowerupActive();
                        break;
                    case 2:
                        Debug.Log("Shields Powerup activated!");
                        player.ShieldPowerupActive();
                        break;
                    case 3:
                        Debug.Log("Ammo Powerup activated!");
                        player.AmmoPowerupActive();
                        break;
                    default:
                        Debug.Log("Default Behavior");
                        break;
                }

            Destroy(this.gameObject);
        }
    }
}
