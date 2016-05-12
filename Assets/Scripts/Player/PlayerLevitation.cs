using UnityEngine;
using System.Collections;

public class PlayerLevitation : MonoBehaviour {
    private int m_PlayerID;
    private bool m_OnBlock;
    private RaycastHit hit;
    private PlayerJump m_PlayerJump;
    private bool m_Levitating;
    private float m_Movement = 0.30f;

    private bool m_IsReSpwaning = false;

    void Start () {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        m_PlayerJump = GetComponent<PlayerJump>();
    }
	
	// Update is called once per fram
	void Update () {
        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;
        m_OnBlock = GetComponent<PlayerGravity>().m_OnBlock;

        if (Input.GetButtonDown("X_" + m_PlayerID.ToString()) && m_OnBlock == true && m_IsReSpwaning == false)
        {
            StartCoroutine(Levitation());
        }
        if (Input.GetButtonUp("X_" + m_PlayerID.ToString()) && m_OnBlock == true && m_IsReSpwaning == false)
        {
            StartCoroutine(EndLevitation());
        }
    }

    IEnumerator Levitation()
    {
        m_Levitating = true;
        m_PlayerJump.enabled = false;
        hit = GetComponent<PlayerGravity>().hit;
        hit.transform.parent = this.transform;
        while(m_Levitating == true)
        {
            if (Input.GetAxisRaw("L_YAxis_" + m_PlayerID.ToString()) > 0.3)
            {
                transform.position = transform.position - (transform.up * m_Movement);
            }
            //Moving to the Left
            if (Input.GetAxisRaw("L_YAxis_" + m_PlayerID.ToString()) < -0.3)
            {
                transform.position = transform.position + (transform.up * m_Movement);
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    IEnumerator EndLevitation()
    {
        m_Levitating = false;
        m_PlayerJump.enabled = true;
        Debug.Log("hll");
        transform.GetChild(3).transform.parent = null;
        yield return null;
    }
}
