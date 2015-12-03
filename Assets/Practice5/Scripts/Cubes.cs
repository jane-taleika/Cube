using UnityEngine;
using System.Collections;

public class Cubes : MonoBehaviour {
    float lifeTime = 10;
    public GameObject Cub;
	// Use this for initialization
	void Start () {
        
            Destroy(Cub, lifeTime);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
