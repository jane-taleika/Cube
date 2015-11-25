using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LaserShoot : MonoBehaviour {

    LineRenderer laserLine;
    public float shootRange = 15f;
    public GameObject star;
    public GameObject Player;
   
    
 
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start () {
        
      Instantiate(star, new Vector3(transform.position.x + 20f, transform.position.y, transform.position.z), Quaternion.identity);
    //  Player = GameObject.Find("MouthShoot");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Start shooting");
            ShootZ();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Start shooting");
            ShootX();
        }
    }

    private void ShootZ()    //IEnumerator
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, Vector3.left);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, shootRange))
        {
            laserLine.SetPosition(1, hit.point);

           
            Destroy(hit.collider.gameObject);
            Player.GetComponent<ScoreManager>().score += 10;
            Debug.Log("You've destroyed Death Star");
            Instantiate(star, new Vector3(transform.position.x + 15f, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else
        {
            laserLine.SetPosition(1, ray.origin + ray.direction * shootRange);
        }
        StartCoroutine(reset());
    }

    private void ShootX()    //IEnumerator
    {
        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, Vector3.right);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, shootRange))
        {
            laserLine.SetPosition(1, hit.point);
            Destroy(hit.collider.gameObject);
            Player.GetComponent<ScoreManager>().score += 10;
            Debug.Log("You've destroyed Death Star");
            Instantiate(star, new Vector3(transform.position.x + 15f, transform.position.y, transform.position.z), Quaternion.identity);
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
