using UnityEngine;
using System.Collections;

public class PacmanMoveStarCreate : MonoBehaviour {

    
    public float speed;
    
    // Use this for initialization
    void Start()
    {
        Debug.Log("Let's go pacman");
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = speed * Input.GetAxis("Horizontal") + transform.position.x;
        if (xAxis != 0)
        {
            transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        }
    }

}
