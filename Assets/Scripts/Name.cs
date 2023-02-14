using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public string input;
    public string highScoreString;
    public int highScore;
    public Text myText;
    public Text myText2;

    void Update()
    {
        input = MainManager1.Instance.getName();
        myText.text = input;
        highScore = MainManager1.Instance.gethighScore();
        highScoreString = highScore.ToString();
        myText2.text = highScoreString;
    }

}