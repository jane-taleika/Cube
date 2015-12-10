using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CongratsManager : MonoBehaviour {

	Text congrats;

	// Use this for initialization
	void Start () {
		congrats = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		congrats.text = Congrats.get ();
	}
}
