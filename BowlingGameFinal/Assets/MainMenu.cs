using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public HighScore highScore;
    public Text highScoreValue;
    public GameObject highScoreMenu;//highscore men�s�n�n referans�n� olu�turuyoruz.

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //sahnelerin isimleri ve indeksleri vard�r. burada bir sonraki sahneyi y�klemek istedik. Aktif sahnenin indexine 1 ekledik.
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenHighScore()
    {
        highScoreMenu.SetActive(true);
        highScoreValue.text=highScore.highScore.ToString();
    }
    public void CloseHighScore()
    {
        highScoreMenu.SetActive(false);
    }
    public void ResetHighScore()
    {
        highScore.highScore = 0;
        highScoreValue.text = highScore.highScore.ToString();
    }
}
