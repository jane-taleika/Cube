using UnityEngine;
using System.Collections;

public class LaserShoot : MonoBehaviour {

    LineRenderer laserLine;
    public float shootRange = 25f;
    public GameObject star;

    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start () {
        Instantiate(star, new Vector3(transform.position.x + 20f, transform.position.y, transform.position.z), Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Start shooting");
            Shoot();
        }
    }

    private void Shoot()    //IEnumerator
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.parent.transform.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, shootRange))
        {
            laserLine.SetPosition(1, hit.point);
            Destroy(hit.collider.gameObject);
            Debug.Log("You've destroyed Death Star");
            Instantiate(star, new Vector3(transform.position.x + 20f, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else
        {
            laserLine.SetPosition(1, ray.origin + ray.direction * shootRange);
        }
        StartCoroutine(reset());
    }

    private IEnumerator reset() {
        yield return new WaitForSeconds(0.05f);
        laserLine.enabled = false;
    }
}
