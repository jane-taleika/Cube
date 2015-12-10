using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PacmanMoveStarCreate : MonoBehaviour {

    public float speed;
	int lifeCount;
	public GameObject canvas;
	Animator anim;
	MeshRenderer mesh;
	public AnimationClip a;
	//public AnimationClip b;
    // Use this for initialization
    void Start()
    {
		anim = transform.GetComponent<Animator> ();
		anim.enabled = false;
		mesh = transform.GetComponent<MeshRenderer> ();
		lifeCount = 3;
        Debug.Log("Let's go pacman");
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = speed * Input.GetAxis("Horizontal");
		float yAxis = speed * Input.GetAxis("Vertical");
        if (xAxis  != 0)
        {
			xAxis+= transform.position.x;
			if(mesh.enabled == false){
				mesh.enabled = true;
			}
			anim.enabled = false;
            transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        } 
        if (yAxis != 0)
        {
			yAxis += transform.position.y;
			if(mesh.enabled == false){
				mesh.enabled = true;
			}
			anim.enabled = false;
            transform.position = new Vector3(transform.position.x, yAxis, transform.position.z);
        }
    }

	public void useLife(){
		if(lifeCount > 1){
			int n = canvas.transform.childCount;
			Transform life = canvas.transform.GetChild(n-1);
			Debug.Log("New life");
			lifeCount--;
			Debug.Log(lifeCount);
			Destroy(life.gameObject);
			transform.position = new Vector3(0f, 5f, 0f);
			Camera.main.transform.position = new Vector3(0f, 11.1f, -32.06f);
		}
		else{
			Destroy(gameObject);
			Debug.Log("Game Over");
		}
		flashing ();
	}

	public void flashing(){
		anim.enabled = true;
		anim.Play(a.name);
	}
}
