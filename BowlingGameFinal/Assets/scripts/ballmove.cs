using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballmove : MonoBehaviour
{
    
    public Rigidbody r1;
    [SerializeField]
    float power;
    // Start is called before the first frame update
    void Start()
    {
        r1 = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {/*
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3(yatay, 0, dikey);
        r1.AddForce(kuvvet);
        */
        if (Input.GetKeyDown(KeyCode.Return))
        {
            r1.AddForce(Vector3.forward *power);
            AudioSource source = GetComponent<AudioSource>();
            source.Play();
        }




    }

}
