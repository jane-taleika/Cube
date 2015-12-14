using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDetector : MonoBehaviour {
	
	GameObject star;
	public Toggle left;
	public Toggle right;
	float x;
	float pac;

	// Use this for initialization
	void Start () {
	}

	void Init(){
		star = GameObject.FindWithTag("Enemy");
		Debug.Log ("Init " + star);
	}
	// Update is called once per frame
	void Update () {
		if (star == null) {
			Init ();
		}
		x = star.transform.position.x;
		pac = transform.parent.transform.position.x;
		//xMin = star.transform.GetComponent<StarRay>().getMinX();
		//xMax = star.transform.GetComponent<StarRay>().getMaxX();
		//Debug.Log (x+ " "+ pac);
		if (x > pac) {
			//right.enabled = true;
			right.isOn = true;
			//left.enabled = false;
			left.isOn = false;
			//Congrats.set ("Look on the right");
			//Debug.Log("Look on the right");
		}
		if(x < pac){
			left.isOn = true;
			right.isOn = false;
			//Congrats.set ("Look on the left");
			//Debug.Log("Look on the left");
		}
	}
}
