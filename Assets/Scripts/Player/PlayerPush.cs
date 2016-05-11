using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour {

    public GameObject Physic;

    private int m_PlayerID;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("RB_"+m_PlayerID.ToString()))
        {

        }
    }

}
