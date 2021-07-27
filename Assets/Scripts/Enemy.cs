using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private Player _player;
    private Animator _onEnemyDestroy;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject _laserPrefab;
    private Vector3 _laserOffset = new Vector3(0, -1.05f, 0);
    private float _fireRate = 3.0f;
    private float _canFire = -1;

    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        if (_player == null)
        {
            Debug.Log("The player is NULL");
        }

        _onEnemyDestroy = gameObject.GetComponent<Animator>();

        if (_onEnemyDestroy == null)
        {
            Debug.LogError("The animator is NULL");
        }

        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        CalculateMovement();

        if (Time.deltaTime > _canFire)
        {
            _fireRate = Random.Range(3.0f, 7.0f);
            _canFire += _fireRate;

            GameObject enemyLaser =  Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();

            for(int i=0; i<lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
    }


    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -6.0f)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            transform.position = new Vector3(randomX, 11, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }
            _onEnemyDestroy.SetTrigger("EnemyExplosion");
            _speed = 0;
            _audioSource.Play();
            Destroy(this.gameObject, 2.8f);
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if (_player != null)
            {
                _player.CalculateScore(10);
            }
            _onEnemyDestroy.SetTrigger("EnemyExplosion");
            _speed = 0;
            _audioSource.Play();
            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
        }
    }
}