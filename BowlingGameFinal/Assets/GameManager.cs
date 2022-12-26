using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball; //bowling topunun referansýný oluþturduk.
    int Score = 0;
    int turnCounter = 0;//her round sonunda oyunu baþa döndürmek için.
    GameObject[] labutlar;//labutlarý tutmasý için gameobject tipinde bir referans noktasý oluþturduk.
    public Text ScoreUI;//oyunun köþesinde yazan skor için text bir deðer oluþturduk.

    Vector3[] positions;//konumlarý tutmasý için bir referans noktasý.
    public HighScore highScore;

    public GameObject menu;//10 round sonunda menu açýlmasý için
    // Start is called before the first frame update
    void Start()
    {
        labutlar = GameObject.FindGameObjectsWithTag("pin");//labutlarý tagdan yakalayýp atýyoruz dizimize.
        positions = new Vector3[labutlar.Length];//labutlarýn uzunluðu kadar pozisyon oluþturduk.
        for (int i=0;i<labutlar.Length;i++)
        {
            positions[i] = labutlar[i].transform.position;//her labutun baþlangýç pozisyonunu atadýk.
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        if (Input.GetKeyDown(KeyCode.Space) || ball.transform.position.y < -120)
        {
            CountPinsDown();
            turnCounter++;
            ResetLabutlar();

            if (turnCounter == 10)
            {
                menu.SetActive(true);
            }
        }
    }
    void MoveBall()
    {
        Vector3 position = ball.transform.position;//topun pozisyonu
        position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime*6;
        //topun saða ve sola hareketini horizontal ile saðladýk ve positiona ekledik. +1 -1 deðer alýr. Time.deltaTime 1sn belirtir.
        position.x = Mathf.Clamp(position.x, -6f, 6f);//kelepçe. bu alanýn dýþýna x ekseninde çýkamaz topumuz.
        ball.transform.position = position;
    }
    void CountPinsDown()
    {//labutlar z ekseninde 5-355 derece arasýnda dönerse ve labut aktifse bu labutlarý tek tek dolaþarak pasif hale getiriyoruz. bunlarý düþmüþ varsayýyoruz.
        for (int i = 0; i < labutlar.Length; i++)
        {
            if (labutlar[i].transform.eulerAngles.z > 5 && labutlar[i].transform.eulerAngles.z < 355 && labutlar[i].activeSelf)
            {
                Score++;
                labutlar[i].SetActive(false);

            }
        }
        ScoreUI.text=Score.ToString();
        if (Score > highScore.highScore)
        {
            highScore.highScore= Score;//yeni en yüksek skoru menüye aktarmýþ olduk.
        }
    }
    void ResetLabutlar()
    {
        //yukarýda pozisyonlarý almýþtý. burada o pozisyonlara geri getiriyoruz. pasif haldeki labutlar aktif hale geliyor. ve velocity yani anlýk hareketi de sýfýrlýyoruz.
        for(int i = 0; i < labutlar.Length; i++)
        {
            labutlar[i].SetActive(true);
            labutlar[i].transform.position = positions[i];
            labutlar[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            labutlar[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            labutlar[i].transform.rotation = Quaternion.identity;


        }
        //burada da topu sýfýrladýk.
        ball.transform.position = new Vector3(0, 2.778f, 0);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}
