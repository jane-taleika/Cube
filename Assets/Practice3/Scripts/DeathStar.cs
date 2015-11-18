using UnityEngine;
using System.Collections;

public class DeathStar : MonoBehaviour {

    public GameObject Star;
    void OnTriggerEnter(Collider other)
    {
      Debug.Log("Capsule Entered");
      
        if (other.gameObject.name == "Capsule(Clone)")
          Destroy(Star);
        Debug.Log("Pacman Destroys The DeathStar!");
    }

  
   
}
