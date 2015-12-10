using UnityEngine;
using System.Collections;

public class StarRay : MonoBehaviour {

	GameObject pacman;
	Collider platform;
	float xMin = -Mathf.Infinity;
	float xMax = Mathf.Infinity;
	int flag;

    // Use this for initialization
    void Start () {
		pacman = GameObject.Find("Pacman");
		platform = GameObject.Find ("Platform").GetComponent<Collider> ();
		int n = platform.transform.childCount;
		float x = transform.position.x;
		Transform child;
		for (int i = 0; i<n; i++) {
			child = platform.transform.GetChild(i);
			if(x < child.position.x && xMax > child.position.x){
				xMax = child.position.x-2.5f;
			}
			else if(x > child.position.x && xMin < child.position.x){
				xMin = child.position.x+2.5f;
			}
		}
        Debug.Log("DeathStar on the way!");
		Debug.Log ("min x =" + xMin + " max x = " + xMax);
        //Instantiate(star, new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
		Ray ray;
		if (pacman != null) {
			if (pacman.transform.position.x > transform.position.x) {
				ray = new Ray (transform.position, Vector3.right);
			} else {
				ray = new Ray (transform.position, Vector3.left);
			}
		
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 2f) && hit.collider.gameObject.name == "Pacman") {
				Camera.main.gameObject.transform.parent = null;
				Destroy (hit.collider.gameObject);
				Debug.Log ("Death Star ray destroy you");
			}
		}
		float xAxis = transform.position.x;
		if (flag == 0) {
			if (xAxis + 0.1f <= xMax) {
				xAxis += 0.1f;
				transform.position = new Vector3 (xAxis, transform.position.y, transform.position.z);
				Debug.Log ("right");
			} else {
				flag = 1;
			}
		} else if (flag == 1) {
			if (xAxis - 0.1f >= xMin) {
				xAxis -= 0.1f;
				transform.position = new Vector3 (xAxis, transform.position.y, transform.position.z);
				Debug.Log ("left");
			}
			else{
				flag = 0;
			}
		}

	}
}
