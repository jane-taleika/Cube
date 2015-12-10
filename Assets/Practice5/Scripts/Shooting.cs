using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	LineRenderer laserLine;
	public float shootRange = 15f;
	public GameObject star;
	public Collider platform;
	public GameObject shell;
	public float numberOfShells;
	float maxX;
	float minX;
	float maxY;
	float minY;
	int n;
	
	void Awake()
	{
		laserLine = GetComponent<LineRenderer>();
	}
	
	// Use this for initialization
	void Start () {
		n = platform.transform.childCount;
		Collider leftBoundary;
		Collider rightBoundarey;
		rightBoundarey = platform.transform.GetChild(0).GetComponent<Collider>();
		leftBoundary = platform.transform.GetChild(1).GetComponent<Collider>();
		minX = leftBoundary.bounds.min.x+1f;
		maxX = rightBoundarey.bounds.max.x - 1f;
		minY = leftBoundary.bounds.min.y + 1f;
		maxY = leftBoundary.bounds.max.y-2f;
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

            //float randomRangeX=Random.Range(-19.0F, 19.0F);
            //float randomRangeY = Random.Range(-3.0F, 10.0F);

			float randomRangeX=Random.Range(minX, maxX);
			float randomRangeY = Random.Range(minY, maxY);
        	
            if ((transform.position.x + randomRangeX > transform.parent.transform.position.x - 1f) && 
			    (transform.position.x + randomRangeX < transform.parent.transform.position.x + 1f))
            {
                Instantiate(star, new Vector3(transform.parent.transform.position.x + 10f, 
				                              transform.position.y, transform.position.z), Quaternion.identity);
                Debug.Log("not random");
            }
            else if ((transform.position.y + randomRangeY > transform.parent.transform.position.y - 1f) && 
			         (transform.position.y + randomRangeY < transform.parent.transform.position.y + 1f))
                {
                    Instantiate(star, new Vector3(transform.parent.transform.position.x, 
				                              transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
                    Debug.Log("not random");
                }
			else
			{
				int i;
				Transform child;
				Vector3 starPosition = new Vector3(randomRangeX, randomRangeY, transform.position.z);
				for(i = 0; i<n; i++){
					child = platform.transform.GetChild(i);
					if(child.position.Equals(starPosition)){
						if(child.position.x+2.5f<maxX){
							randomRangeX += 2.5f; 
						}
						else if(child.position.x-2.5f>minX){
							randomRangeX -= 2.5f;
						}
						else{
							randomRangeX = -20f;
							randomRangeY = 5;
						}
						starPosition.Set(randomRangeX,randomRangeY,transform.position.z);
						Debug.Log("not random");
					}					                                                           
				}

				Instantiate(star, starPosition, 
				            Quaternion.identity);
				//Debug.Log("random");
			}

			if(ScoreIncrease.Score%3 == 0){
				for(int i = 0; i < numberOfShells; i++){
					randomRangeX=Random.Range(transform.position.x-10f, transform.position.x+10f);
					Instantiate(shell, new Vector3(randomRangeX, maxY, transform.position.z), 
					            Quaternion.identity);
				}
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
