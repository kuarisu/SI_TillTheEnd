using UnityEngine;
using System.Collections;

public class PlayerLevitation : MonoBehaviour {
    private int m_PlayerID;
    private bool m_OnBlock;
    private RaycastHit hit;
    private PlayerJump m_PlayerJump;
    public bool m_Levitating;
    private float m_Movement = 0.05f;
    private Rigidbody rb;

    private bool m_IsReSpwaning = false;

    void Start () {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        m_PlayerJump = GetComponent<PlayerJump>();
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per fram
	void Update () {
        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;
        m_OnBlock = GetComponent<PlayerGravity>().m_OnBlock;

        if (Input.GetButtonDown("X_" + m_PlayerID.ToString()) && m_OnBlock == true && m_IsReSpwaning == false)
        {
            StartCoroutine(Levitation());
          
        }
        if (Input.GetButtonDown("Y_" + m_PlayerID.ToString()) && m_OnBlock == true && m_IsReSpwaning == false)
        {
            StartCoroutine(EndLevitation());
        }
        if (m_Levitating == true && m_OnBlock == false)
        {
            StartCoroutine(EndLevitation());
        }

        if (m_Levitating == true && m_IsReSpwaning == true)
        {
            StartCoroutine(EndLevitation());
        }

    }

    IEnumerator Levitation()
    {
        m_Levitating = true;
        m_PlayerJump.enabled = false;
        hit = GetComponent<PlayerGravity>().hit;
        hit.collider.gameObject.GetComponent<BlockPushed>().m_Levitation = true;
        hit.transform.parent = this.transform;
        while(m_Levitating == true)
        {
            if (Input.GetAxisRaw("L_YAxis_" + m_PlayerID.ToString()) > 0.3)
            {
                //transform.position = transform.position - (transform.up * m_Movement);
                rb.MovePosition(transform.position - (transform.up * m_Movement));
            }
            //Moving to the Left
            if (Input.GetAxisRaw("L_YAxis_" + m_PlayerID.ToString()) < -0.3)
            {
                //transform.position = transform.position + (transform.up * m_Movement);
                rb.MovePosition(transform.position + (transform.up * m_Movement));
            }
            yield return new WaitForEndOfFrame();
        }
        yield return null;
    }

    IEnumerator EndLevitation()
    { 
        m_Levitating = false;
        m_PlayerJump.enabled = true;
        transform.GetChild(3).GetComponent<BlockPushed>().m_Levitation = false;
        transform.GetChild(3).transform.parent = null;
        yield return null;
    }
}
