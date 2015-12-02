using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	LineRenderer laserLine;
	public float shootRange = 15f;
	public GameObject star;
	//public GameObject Player;
	
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
			//ShootZ();
			Shoot('l');
		}
		
		if (Input.GetKeyDown(KeyCode.X))
		{
			Debug.Log("Start shooting");
			//ShootX();
			Shoot('r');
		}
	}
	
	private void Shoot(char direction)    //IEnumerator
	{
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
		if (Physics.Raycast(ray, out hit, shootRange))
		{
			laserLine.SetPosition(1, hit.point);
			Destroy(hit.collider.gameObject);
			Debug.Log("You've destroyed Death Star");
			ScoreIncrease.Score +=10;
			//Player.GetComponent<ScoreManager>().score += 10;          
			//Instantiate(star, new Vector3(transform.position.x + 15f, transform.position.y, transform.position.z), Quaternion.identity);
            float randomRange=Random.Range(-19.0F, 19.0F);
            if ((transform.position.x + randomRange > transform.parent.transform.position.x + 2f) || (transform.position.x + randomRange < transform.parent.transform.position.x - 2f))
            Instantiate(star, new Vector3(transform.position.x + randomRange, transform.position.y, transform.position.z), Quaternion.identity);
            else
                Instantiate(star, new Vector3(transform.position.x + 10f, transform.position.y, transform.position.z), Quaternion.identity);

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
