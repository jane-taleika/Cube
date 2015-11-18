using UnityEngine;
using System.Collections;

public class Pacman : MonoBehaviour
{

    public float speed;
    public GameObject Capsule;

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
        //transform.Translate(new Vector3(xAxis, 0.0f, 0.0f));
        if (Input.GetKeyDown("space"))
        {
            Shot();
        }
    }

    void Shot()
    {
        GameObject shootCapsule;
        shootCapsule = Instantiate(Capsule, transform.position, Quaternion.identity) as GameObject;
    }

    
}
