using UnityEngine;
using System.Collections;

public class Block_Pushed : MonoBehaviour {
    public float ExplosionStrengh = 100f; 

    void OnTriggerEnter(Collider col)
    {
      
        if (col.tag == "Player")
        {
            Debug.Log("Hallo");
            Vector3 _positionTarget = col.transform.position;
            Vector3 _direction = (transform.position - _positionTarget).normalized * ExplosionStrengh;
            GetComponent<Rigidbody>().AddForce(_direction);

            //Rigidbody _Rb = col.transform.parent.GetComponent<Rigidbody>();
            //Vector3 forceVec = -_Rb.velocity.normalized * ExplosionStrengh;
            //Debug.Log(_Rb.velocity);
            //GetComponent<Rigidbody>().AddForce(forceVec, ForceMode.Acceleration);

        }
    }
}
