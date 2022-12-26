using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;//oyun i�indeki men�ye referans ekledik.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//esc tuluna bas�nca tetiklenir.
        {
            if (menu.activeSelf)
            {
                menu.SetActive(false);//menu aktifse pasif hale getirilir.
            }
            else
            {
                menu.SetActive(true);//menu pasifse aktif hale getirilir.
            }
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//aktif sahne
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);//ana men�ye d�nmemizi sa�lar.
    }
    public void Quit()
    {
        Application.Quit();//oyundan ��kmam�z� sa�lar.
    }
}
