using UnityEngine; 
using System.Collections; 

public class newcam : MonoBehaviour { 
public float dampTime = 0.5f; 
private Vector3 velocity = Vector3.zero; 
public Transform target;
Camera camera;

void Start()
{
    camera = GetComponent<Camera>();
}
// Update is called once per frame 
void Update () 
{ 
if (target) 
{ 
Vector3 point = camera.WorldToViewportPoint(new Vector3(target.position.x, transform.position.y ,target.position.z)); //target.position.y+0.5f
Vector3 delta = new Vector3(target.position.x, transform.position.y ,target.position.z) - camera.ViewportToWorldPoint(new Vector3(0.5f, point.y, point.z)); //(new Vector3(0.5, 0.5, point.z)); 
Vector3 destination = transform.position + delta; 


transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime); 
} 

} 
}