using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public int score;
    public Text ScoreText;

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
