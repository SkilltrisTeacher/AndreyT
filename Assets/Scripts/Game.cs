using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental;

public class Game : MonoBehaviour
{
    [SerializeField] private int startLives = 3;
    [SerializeField] private string mainMenuName;
    [SerializeField] private TMP_Text finalCoinsCount;
    [SerializeField] private GameObject restartMenu;
    private int coinCount;
    private int LivesCount;
    private void Awake()
    {
        Game[] anotherGame = FindObjectsOfType<Game>();
        if (anotherGame.Length > 1) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        LivesCount = startLives;

    }

    public void RestartGame()
    {
        coinCount = 0;
        LivesCount = startLives;
        Time.timeScale = 1f;
        restartMenu.SetActive(false);
        SceneManager.LoadScene(mainMenuName);
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        restartMenu.SetActive(true);
        finalCoinsCount.text = coinCount.ToString();
    }
    public void LoseLife()
    {
        LivesCount--;
        PlayerUI.ui.SetLives(LivesCount);
        if (LivesCount <= 0) GameOver();


    }
    public void AddCoins(int amount)
    {
        coinCount += amount;
        PlayerUI.ui.ShowCoinCount(coinCount);
    }
    

}
