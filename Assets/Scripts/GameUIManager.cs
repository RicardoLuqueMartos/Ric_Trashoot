using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUIManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    GameObject pressKeyTextObj;

    public Text scoreText;

    public int score = 0;

    bool Locked = false;
    #endregion Variables

    private void Update()
    {
        if (Locked == false && Input.anyKeyDown && player.activeInHierarchy == false)
            StartGame();

        if (player.activeInHierarchy == true)
            scoreText.text = score.ToString();

    }

    void UnlockMenu()
    {
        Locked = false;
        pressKeyTextObj.SetActive(true);
    }
    
    void StartGame()
    {
        ResetScore();
        mainMenu.SetActive(false);
        pressKeyTextObj.SetActive(false);
        player.SetActive(true);
    }

    public void EndGame()
    {  
        Locked = true;
        mainMenu.SetActive(true);
        Invoke("UnlockMenu", 2);
    }

    private void ResetScore()
    {
        score = 0;
    }

    public void AddToScore()
    {
        score++;
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
