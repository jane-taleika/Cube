using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDetector : MonoBehaviour {
	
	public GameObject star;
	public Toggle left;
	public Toggle right;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (star.transform.position.x > transform.parent.transform.position.x) {
			//right.enabled = true;
			right.isOn = true;
			//left.enabled = false;
			left.isOn = false;
			Congrats.set ("Look on the right");
			//Debug.Log("Look on the right");
		}

		if(star.transform.position.x < transform.parent.transform.position.x){
			left.isOn = true;
			right.isOn = false;
			Congrats.set ("Look on the left");
			//Debug.Log("Look on the left");
		}
	}
}
