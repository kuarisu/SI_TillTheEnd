using UnityEngine;
using System.Collections;

public class BlockPushed : MonoBehaviour {

    //Beaucoup de chose à changer, notamment avec le viseur de Baptiste. 
    //Attention à comment enlever la gravité (trouver comment savoir si le bloc bouge ou pas, genre sa vitesse)
    public float ExplosionStrengh = 100f;
    private Rigidbody rb;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update ()
    {
        if (rb.velocity == new Vector3 (0,0,0))
        {
            StopMove();
        }
    }

    void OnTriggerEnter(Collider col)
    {
      
        if (col.tag == "Player")
        {
            GetComponent<Rigidbody>().useGravity = true;
            //Use two points to make a vector and push the block in the opposite direction
            //Chnager le vector 3 en vector 2 x et y
            Vector3 _positionTarget = col.transform.position;
            Vector3 _direction = (transform.position - _positionTarget).normalized * ExplosionStrengh;
            GetComponent<Rigidbody>().AddForce(_direction);

        }
    }

    void StopMove()
    {
        rb.useGravity = false;
    }

}
