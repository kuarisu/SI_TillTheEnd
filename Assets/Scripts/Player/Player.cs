using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int m_PlayerID;

    void Update()
    {
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0 );
    }


}

