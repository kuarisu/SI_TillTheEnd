using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour {

    public GameObject Physic;

    private int m_PlayerID;
    private PlayerGravity m_playerGravity;
    public bool m_IsPunching = false;
    private bool m_IsReSpwaning = false;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        m_playerGravity = GetComponent<PlayerGravity>();
    }

	// Update is called once per frame
	void Update () {

        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;

        if (Input.GetButtonDown("RB_"+m_PlayerID.ToString()) && m_playerGravity.m_OnBlock == true && m_IsReSpwaning == false && ((Input.GetAxis("R_XAxis_1") != 0) || (Input.GetAxis("R_YAxis_1") != 0)))
        {
            m_IsPunching = true;
            m_playerGravity.m_BlockTouched.GetComponent<BlockPushed>().PushedCoroutine();
            m_IsPunching = false;
        }
    }

}
