using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "HighScore", order = 1)]//yeni bir obje olu�turuldu.
public class HighScore : ScriptableObject//veriyi saklamam�z� sa�lar.
{
    public int highScore;//int de�i�ken tan�mlad�k ve gamemanager.cs'e gittik.
}
