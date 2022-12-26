using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;//oyun içindeki menüye referans ekledik.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//esc tuluna basýnca tetiklenir.
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
        SceneManager.LoadScene(0);//ana menüye dönmemizi saðlar.
    }
    public void Quit()
    {
        Application.Quit();//oyundan çýkmamýzý saðlar.
    }
}
