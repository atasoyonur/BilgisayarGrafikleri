using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "HighScore", order = 1)]//yeni bir obje oluþturuldu.
public class HighScore : ScriptableObject//veriyi saklamamýzý saðlar.
{
    public int highScore;//int deðiþken tanýmladýk ve gamemanager.cs'e gittik.
}
