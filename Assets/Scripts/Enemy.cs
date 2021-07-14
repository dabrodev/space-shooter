using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;
    private Player _player;
    private Animator _onEnemyDestroy;

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
    }

    void Update()
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
            Destroy(this.gameObject, 2.8f);
        }
    }
}