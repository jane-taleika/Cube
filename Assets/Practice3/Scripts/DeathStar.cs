using UnityEngine;
using System.Collections;

public class DeathStar : MonoBehaviour {

    //public GameObject Star;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule(Clone)")
        {
            Debug.Log("Capsule Entered");
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("Pacman Destroys The DeathStar!");
        }
        if (other.gameObject.name == "Pacman") {
            Debug.Log("DeathStar pew!");
            Destroy(other.gameObject);
            Debug.Log("You've been destroyed by DeathStar");
        }
    }

  
   
}
