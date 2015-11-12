using UnityEngine;
using System.Collections;

public class ShellMove : MonoBehaviour {

    float lifeTime = 3;
    public float speed;

    // Use this for initialization
    void Start () {
        Debug.Log("pew");
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.name == "Shell(Clone)"){
            transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * speed);
            Destroy(gameObject, lifeTime);
        }
    }
}
