using UnityEngine;
using System.Collections;

public class Block_Pushed : MonoBehaviour {
    public float ExplosionStrengh = 100f; 

    void OnTriggerEnter(Collider col)
    {
      
        if (col.tag == "Player")
        {
            //Use two points to make a vector and push the block in the opposite direction
            Debug.Log("Hallo");
            Vector3 _positionTarget = col.transform.position;
            Vector3 _direction = (transform.position - _positionTarget).normalized * ExplosionStrengh;
            GetComponent<Rigidbody>().AddForce(_direction);

        }
    }
}
