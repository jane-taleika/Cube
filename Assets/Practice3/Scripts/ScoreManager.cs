using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int score;
    Text ScoreText;

    void Awake()
    {
        ScoreText = GetComponent<Text>();
        score = 0;
    }

    void Update()
    {
        ScoreText.text = "Score:" + score;
    }
	
}
