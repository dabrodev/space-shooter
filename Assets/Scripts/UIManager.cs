using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameOver;
    [SerializeField]
    private Text _restartGame;
    [SerializeField]
    private Sprite[] _liveSprites;
    private bool _gamePlay = true;
    private bool _switcher;
    [SerializeField]
    private Scrollbar _shieldBar;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOver.gameObject.SetActive(false);
        _restartGame.gameObject.SetActive(false);
        _shieldBar.gameObject.SetActive(false);
        _shieldBar.size = 1;
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateShieldBar()
    {
        _shieldBar.size -= 0.33f; 
    }

    public void SetShieldBar()
    {
        _shieldBar.size = 1;
    }
    
    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _liveSprites[currentLives];
    }

    public void DisplayGameOver()
    {
        _gamePlay = false;
        StartCoroutine(GameOverFlicker());
        _restartGame.gameObject.SetActive(true);
    }

    IEnumerator GameOverFlicker()
    {
        Debug.Log("Started.");
        while(_gamePlay == false)
        {
            _switcher = !_switcher;
            _gameOver.gameObject.SetActive(_switcher);
            yield return new WaitForSeconds(0.2f);
        }    
    }
}
