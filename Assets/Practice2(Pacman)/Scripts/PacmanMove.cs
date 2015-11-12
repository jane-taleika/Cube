using UnityEngine;
using System.Collections;

public class PacmanMove : MonoBehaviour {

    public float speed;
    public GameObject shell;

	// Use this for initialization
	void Start () {
        Debug.Log("Let's go pacman");
	}

    // Update is called once per frame
    void Update()
    {
        float xAxis = speed * Input.GetAxis("Horizontal") + transform.position.x;
        if (xAxis != 0){
            transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        }
        //transform.Translate(new Vector3(xAxis, 0.0f, 0.0f));
        if (Input.GetKeyDown("space")) { 
            Shot();
        }
	}

    void Shot() {
        GameObject shootShell;
        shootShell = Instantiate(shell, transform.position, Quaternion.identity) as GameObject;
    }
}
