using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public int m_PlayerID;
    public Vector3 m_SpawnPoint;


    void Start()
    {
        m_SpawnPoint = transform.position;
    }

    void Update()
    {
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0 );
    }


}

