using UnityEngine;
using System.Collections;

public class PlayerPush : MonoBehaviour {

    public GameObject m_Target;
    public Animator m_An;

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
        Debug.Log("hello");
        if (Input.GetButtonDown("RB_"+m_PlayerID.ToString()) && m_playerGravity.m_OnBlock == true && m_IsReSpwaning == false && ((Input.GetAxis("R_XAxis_" + m_PlayerID.ToString()) != 0) || (Input.GetAxis("R_YAxis_" + m_PlayerID.ToString()) != 0)))
        {
            m_An.SetBool("m_IsPunching", true);
            m_playerGravity.m_BlockTouched.GetComponent<BlockPushed>().m_PlayerTarget = m_Target;
            m_IsPunching = true;
            m_playerGravity.m_BlockTouched.GetComponent<BlockPushed>().IdBlock = m_PlayerID;
            m_playerGravity.m_BlockTouched.GetComponent<BlockPushed>().PushedCoroutine();
            m_IsPunching = false;
            StartCoroutine(StopAnim());
        }
    }

    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.5f);
        m_An.SetBool("m_IsPunching", false);
    }

}
