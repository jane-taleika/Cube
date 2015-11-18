using UnityEngine;
using System.Collections;

public class DeathStar : MonoBehaviour {
    

    void OnTriggerEnter(Collider other)
    {
      Debug.Log("Object Entered");
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("Object Is Inside");
    }

   
}
