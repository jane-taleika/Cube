using UnityEngine;
using System.Collections;

public class CapsuleColor : MonoBehaviour {

    void Awake()
    {
        Debug.Log("Capsule and Cube movements");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (Input.GetMouseButtonDown(1))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
