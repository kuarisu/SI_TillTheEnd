using UnityEngine;
using System.Collections;

public class PlayerTarget : MonoBehaviour {

    //Stock the player ID, for Multiplayer
    private int m_PlayerId;

    void Start()
    {
        m_PlayerId = transform.parent.GetComponent<Player>().m_PlayerID;
    }

    void Rotate()
    {

        if ((Input.GetAxis("R_XAxis_1") != 0) || (Input.GetAxis("R_YAxis_1") != 0))
        {
            Vector3 rotatePos = new Vector3((Input.GetAxis("R_XAxis_1")), 0, (Input.GetAxis("R_YAxis_1")));
            rotatePos.y = 0;
            float angle = Mathf.Atan2(rotatePos.z, rotatePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -(angle + 90)));
        }

    }

    void Update()
    {
        Rotate();
    }
}