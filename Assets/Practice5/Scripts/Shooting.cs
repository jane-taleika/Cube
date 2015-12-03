using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	LineRenderer laserLine;
	public float shootRange = 15f;
	public GameObject star;
	
	
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
			Shoot('l');
		}
		
		if (Input.GetKeyDown(KeyCode.X))
		{
			Debug.Log("Start shooting");
			Shoot('r');
		}


        
	}
	
	private void Shoot(char direction)    
	{
       int layerMask = 1 << 8;
       layerMask = ~layerMask;
		Ray ray;
        Vector3 position;

		laserLine.enabled = true;
		if (direction == 'r'){
			position = new Vector3(transform.position.x + 2f, transform.position.y, transform.position.z);
			laserLine.SetPosition(0, position);
			ray = new Ray(transform.parent.transform.position, Vector3.right);
		}
		else {
			position= new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
			laserLine.SetPosition(0, position);
			ray = new Ray(transform.parent.transform.position, Vector3.left);
		}
		

        RaycastHit hit;
   

        if (Physics.Raycast(ray, out hit, shootRange, layerMask))
		{
			laserLine.SetPosition(1, hit.point);
			Destroy(hit.collider.gameObject);
			Debug.Log("You've destroyed Death Star");
			ScoreIncrease.Score +=10;
            
            float randomRangeX=Random.Range(-19.0F, 19.0F);
            float randomRangeY = Random.Range(-3.0F, 10.0F);
        
            if ((transform.position.x + randomRangeX > transform.parent.transform.position.x - 1f) && (transform.position.x + randomRangeX < transform.parent.transform.position.x + 1f))
            {
                Instantiate(star, new Vector3(transform.parent.transform.position.x + 10f, transform.position.y, transform.position.z), Quaternion.identity);
                Debug.Log("not random");
            }
            else
                if ((transform.position.y + randomRangeY > transform.parent.transform.position.y - 1f) && (transform.position.y + randomRangeY < transform.parent.transform.position.y + 1f))
                {
                    Instantiate(star, new Vector3(transform.parent.transform.position.x, transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
                    Debug.Log("not random");
                }
                else
                {
                    Instantiate(star, new Vector3(transform.position.x + randomRangeX, transform.position.y + randomRangeY, transform.position.z), Quaternion.identity);
                    Debug.Log("random");
                }
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
