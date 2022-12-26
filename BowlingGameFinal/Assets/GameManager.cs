using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball; //bowling topunun referans�n� olu�turduk.
    int Score = 0;
    int turnCounter = 0;//her round sonunda oyunu ba�a d�nd�rmek i�in.
    GameObject[] labutlar;//labutlar� tutmas� i�in gameobject tipinde bir referans noktas� olu�turduk.
    public Text ScoreUI;//oyunun k��esinde yazan skor i�in text bir de�er olu�turduk.

    Vector3[] positions;//konumlar� tutmas� i�in bir referans noktas�.
    public HighScore highScore;

    public GameObject menu;//10 round sonunda menu a��lmas� i�in
    // Start is called before the first frame update
    void Start()
    {
        labutlar = GameObject.FindGameObjectsWithTag("pin");//labutlar� tagdan yakalay�p at�yoruz dizimize.
        positions = new Vector3[labutlar.Length];//labutlar�n uzunlu�u kadar pozisyon olu�turduk.
        for (int i=0;i<labutlar.Length;i++)
        {
            positions[i] = labutlar[i].transform.position;//her labutun ba�lang�� pozisyonunu atad�k.
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
        //topun sa�a ve sola hareketini horizontal ile sa�lad�k ve positiona ekledik. +1 -1 de�er al�r. Time.deltaTime 1sn belirtir.
        position.x = Mathf.Clamp(position.x, -6f, 6f);//kelep�e. bu alan�n d���na x ekseninde ��kamaz topumuz.
        ball.transform.position = position;
    }
    void CountPinsDown()
    {//labutlar z ekseninde 5-355 derece aras�nda d�nerse ve labut aktifse bu labutlar� tek tek dola�arak pasif hale getiriyoruz. bunlar� d��m�� varsay�yoruz.
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
            highScore.highScore= Score;//yeni en y�ksek skoru men�ye aktarm�� olduk.
        }
    }
    void ResetLabutlar()
    {
        //yukar�da pozisyonlar� alm��t�. burada o pozisyonlara geri getiriyoruz. pasif haldeki labutlar aktif hale geliyor. ve velocity yani anl�k hareketi de s�f�rl�yoruz.
        for(int i = 0; i < labutlar.Length; i++)
        {
            labutlar[i].SetActive(true);
            labutlar[i].transform.position = positions[i];
            labutlar[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            labutlar[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            labutlar[i].transform.rotation = Quaternion.identity;


        }
        //burada da topu s�f�rlad�k.
        ball.transform.position = new Vector3(0, 2.778f, 0);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}
