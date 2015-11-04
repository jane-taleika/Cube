using UnityEngine;
using System.Collections;

public class CubeMovement : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Debug.Log("Let's get the party started");
       
        
        /*
         * 
          Rigidbody rb = GetComponent<Rigidbody>();

        // Add a force to the Rigidbody.
        rb.AddForce(Vector3.up * 10f);
          
         
         */
      
    }
	
	// Update is called once per frame
	void Update () {

        float distance = Time.deltaTime * Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * distance);
        float height = Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * height);
        
        
	
	}
}
