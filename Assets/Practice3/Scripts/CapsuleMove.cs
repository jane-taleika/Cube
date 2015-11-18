using UnityEngine;
using System.Collections;

public class CapsuleMove : MonoBehaviour
{

    float lifeTime = 3;
    public float speed;
    

    // Use this for initialization
    void Start()
    {
        if (gameObject.name == "Capsule(Clone)")
        {
            Debug.Log("pew");
            Destroy(gameObject, lifeTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Capsule(Clone)")
        {
            transform.Translate(new Vector3(1.0f, 0.0f, 0.0f) * speed);
        }
    }


    
   
}