using UnityEngine;
using System.Collections;

public class BlockPushed : MonoBehaviour {



    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
        {

            //Use two points to make a vector and push the block in the opposite direction
            //Chnager le vector 3 en vector 2 x et y
            Vector3 _positionTarget = col.transform.position;
            Vector3 _direction = (transform.position - _positionTarget).normalized;

        }
    }

}
