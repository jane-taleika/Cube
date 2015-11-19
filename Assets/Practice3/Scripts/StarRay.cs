using UnityEngine;
using System.Collections;

public class StarRay : MonoBehaviour {

    public GameObject star;

    // Use this for initialization
    void Start () {
        Debug.Log("DeathStar on the way!");
        //Instantiate(star, new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(transform.position, -transform.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 01f) && hit.collider.gameObject.name == "Pacman") {
            Debug.DrawRay(transform.position, -transform.right, Color.red, 2);
            Camera.main.gameObject.transform.parent = null;
            Destroy(hit.collider.gameObject);
            Debug.Log("Death Star ray destroy you");
        }
	
	}
}
