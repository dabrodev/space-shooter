using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Text _gameOver;
    [SerializeField]
    private Sprite[] _liveSprites;
    private bool _gamePlay = true;
    private bool _switcher;

    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOver.gameObject.SetActive(false);
    }


    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _liveSprites[currentLives];
    }

    public void DisplayGameOver()
    {
        _gamePlay = false;
        StartCoroutine(GameOverFlicker());
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
