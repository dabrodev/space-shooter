using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private float _speedUp = 2f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldCloud;
    [SerializeField]
    private GameObject _damageREngine;
    [SerializeField]
    private GameObject _damageLEngine;
    [SerializeField]
    private Vector3 _laserOffset = new Vector3(0,3,0);
    [SerializeField]
    private float _fireRate = 0.15f;
    private float _nextFire = -1.0f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    private bool _isTripleShotActive = false;
    private bool _isSpeedPowerupActive = false;
    private bool _isShieldPowerupActive = false;
    private int _score;
    private UIManager _uiManager;
    private GameManager _gameManager;
    private AudioSource _audioSource;
    [SerializeField]
    private GameObject _shieldBar;
    private int _shieldPower = 3;
    private int ammoCount = 15;


    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        _shieldCloud.SetActive(false);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_spawnManager == null)
        {
            Debug.Log("The Spawn Manager is NULL");
        }

        if (_uiManager == null)
        {
            Debug.Log("The Spawn Managr is NULL");
        }

        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
        {
            Debug.Log("The Game Manager is NULL");
        }

        _damageLEngine.SetActive(false);
        _damageREngine.SetActive(false);

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.Log("The AudioSource is NULL!");
        }
    }

    void Update()
    {
        PlayerMovement();
        RestrictMovement();
        PlayerLaser();
        Thrusters();
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
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.6f,7.6f), Mathf.Clamp(transform.position.y, -2.7f,4.5f), 0);
    }

    void PlayerLaser() 
    {       
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextFire)  
        {
            _nextFire = Time.time + _fireRate;

            if (_isTripleShotActive == true)
            {
                Instantiate(_tripleShotPrefab, transform.position, Quaternion.identity);
            }
            else if ( ammoCount > 0)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
                ammoCount--;
                _uiManager.UpdateAmmo(ammoCount);
            }       
        }
        _audioSource.Play();
    }
    

    public void Damage()
    {
        /* if (_isShieldPowerupActive == false)
         {
             _lives--;
         }} Limited Time Shield   */

        if (_isShieldPowerupActive == true)
        {
            _shieldPower -= 1;
            _uiManager.UpdateShieldBar();

            if (_shieldPower < 1)
            {
                _isShieldPowerupActive = false;
                _shieldCloud.SetActive(false);
                _shieldBar.SetActive(false);
            }
            return;
        }

        _lives--;

        _uiManager.UpdateLives(_lives);

        if (_lives == 2)
        {
            _damageREngine.SetActive(true);
        }

        else if (_lives == 1)
        {
            _damageLEngine.SetActive(true);
        }

        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
            _uiManager.DisplayGameOver();
            _gameManager.SetGameOver();
        }
    }

    public void TripleShotActive()
    {
        _isTripleShotActive = true;
        StartCoroutine(TripleShotPowerdownCoroutine());
    }

    public void SpeedPowerupActive()
    {
        _isSpeedPowerupActive = true;
        _speed *= _speedUp;

        if (_isSpeedPowerupActive == true)
        {
            StartCoroutine(SpeedPowerupCoroutine());
        }
    }

    public void ShieldPowerupActive()
    {
        _isShieldPowerupActive = true;
        _shieldCloud.SetActive(true);
        _shieldBar.gameObject.SetActive(true);
        _uiManager.SetShieldBar();
        _shieldPower = 3;
        
        // StartCoroutine(ShieldPowerupCoroutine());
        // Limited Time Shield
    }

    IEnumerator TripleShotPowerdownCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isTripleShotActive = false;
    }

    IEnumerator SpeedPowerupCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isSpeedPowerupActive = false;
        _speed /= _speedUp;
    }

    /*
    IEnumerator ShieldPowerupCoroutine()
    {
        yield return new WaitForSeconds(5.0f);
        _isShieldPowerupActive = false;
    } Limited Time Shield */

    public void CalculateScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }

    public void Thrusters()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed += (_speedUp); 
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 3.0f;
        }
    }    
}