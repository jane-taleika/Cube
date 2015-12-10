using UnityEngine;
using System.Collections;

public class RedShellScript : MonoBehaviour {

	//GameObject pacman;
	int layer;
	float lifetime = 1f;
	// Use this for initialization
	void Start () {
		layer = LayerMask.NameToLayer("Obstacles");
		//pacman = GameObject.Find("Pacman");
		Debug.Log("Red Shell on the way");
	}

	void OnCollisionEnter(Collision collision){
		string name = collision.gameObject.name;
		//Debug.Log (layer + " " + collision.gameObject.layer);
		if (name.Equals ("Pacman")) {
			Debug.Log ("Red Shell destroy you");
			collision.gameObject.GetComponent<PacmanMoveStarCreate>().useLife();
			//Destroy (collision.gameObject);
		} else if (layer == collision.gameObject.layer) {
			Destroy(gameObject, lifetime);
		}
	}
}
