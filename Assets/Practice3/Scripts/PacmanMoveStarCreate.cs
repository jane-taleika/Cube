using UnityEngine;
using System.Collections;

public class PacmanMoveStarCreate : MonoBehaviour {

    private float dist = 20f;
    public float speed;
    public GameObject star;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Let's go pacman");
        Instantiate(star, new Vector3(transform.position.x+10f, transform.position.y, transform.position.z),Quaternion.identity);
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
        Ray ray = new Ray(transform.position, transform.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dist))
        {
            Vector3 pos = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
            Vector3 dir = transform.TransformDirection(Vector3.right) * 5;
            Debug.DrawRay(pos, dir, Color.green, 2);
            Destroy(hit.collider.gameObject);
            Debug.Log("You've destroyed Death Star");
            Instantiate(star, new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }
}
