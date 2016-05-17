using UnityEngine;
using System.Collections;

public class PlayerTarget : MonoBehaviour {

    //Stock the player ID, for Multiplayer
    private int m_PlayerID;
    private bool m_OnBlock;

    void Start()
    {
        m_PlayerID = transform.parent.GetComponent<Player>().m_PlayerID;
    }

    void Rotate()
    {
        if (m_OnBlock == true && ((Input.GetAxis("R_XAxis_" + m_PlayerID.ToString()) != 0) || (Input.GetAxis("R_YAxis_" + m_PlayerID.ToString()) != 0)))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Vector3 rotatePos = new Vector3((Input.GetAxis("R_XAxis_" + m_PlayerID.ToString())), 0, (Input.GetAxis("R_YAxis_" + m_PlayerID.ToString())));
            rotatePos.y = 0;
            float angle = Mathf.Atan2(rotatePos.z, rotatePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -(angle + 90)));
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    void Update()
    {
        m_OnBlock = transform.parent.GetComponent<PlayerGravity>().m_OnBlock;
        Rotate();
    }
}