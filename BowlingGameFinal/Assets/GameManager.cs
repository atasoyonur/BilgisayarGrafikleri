using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    int Score = 0;
    int turnCounter = 0;
    GameObject[] labutlar;
    public Text ScoreUI;

    Vector3[] positions;
    public HighScore highScore;

    public GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        labutlar = GameObject.FindGameObjectsWithTag("pin");
        positions = new Vector3[labutlar.Length];
        for (int i=0;i<labutlar.Length;i++)
        {
            positions[i] = labutlar[i].transform.position;
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
        Vector3 position = ball.transform.position;
        position += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime*6;
        position.x = Mathf.Clamp(position.x, -6f, 6f);
        ball.transform.position = position;
        //ball.transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime);
    }
    void CountPinsDown()
    {
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
            highScore.highScore= Score;
        }
    }
    void ResetLabutlar()
    {
        for(int i = 0; i < labutlar.Length; i++)
        {
            labutlar[i].SetActive(true);
            labutlar[i].transform.position = positions[i];
            labutlar[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            labutlar[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            labutlar[i].transform.rotation = Quaternion.identity;


        }
        ball.transform.position = new Vector3(0, 2.778f, 0);
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.rotation = Quaternion.identity;
    }
}
