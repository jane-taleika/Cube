using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextManager : MonoBehaviour {

	Text ScoreText;

	// Use this for initialization
	void Start () {
		ScoreText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		ScoreText.text = "Score:" + ScoreIncrease.Score;
	}
}
