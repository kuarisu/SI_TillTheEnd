using UnityEngine;
using System.Collections;

public class PlayerLevitation : MonoBehaviour {

    public Animator m_An;

    private int m_PlayerID;
    private bool m_OnBlock;
    private RaycastHit hit;
    private PlayerJump m_PlayerJump;
    private float m_Movement = 0.05f;
    private Rigidbody rb;
    private bool m_IsReSpwaning = false;

    public bool m_Levitating;
    public GameObject m_PSLevitation;

    void Start () {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        m_PlayerJump = GetComponent<PlayerJump>();
        rb = GetComponent<Rigidbody>();
        m_PSLevitation.SetActive(false);


    }
	
	// Update is called once per fram
	void Update () {
        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;
        m_OnBlock = GetComponent<PlayerGravity>().m_OnBlock;

        if (Input.GetButtonDown("X_" + m_PlayerID.ToString()) && m_OnBlock == true && m_IsReSpwaning == false)
        {
            StartCoroutine(Levitation());
            m_PSLevitation.SetActive(true);

        }
        if (Input.GetButtonDown("Y_" + m_PlayerID.ToString()) && m_OnBlock == true && m_IsReSpwaning == false )
        {
            StartCoroutine(EndLevitation());
            m_PSLevitation.SetActive(false);
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
        SoundManagerEvent.emit(SoundManagerType.PlayerMeditation);
        m_Levitating = true;
        m_PlayerJump.enabled = false;
        hit = GetComponent<PlayerGravity>().hit;
        hit.collider.gameObject.GetComponent<BlockPushed>().m_Levitation = true;
        hit.transform.parent = this.transform;
        while(m_Levitating == true)
        {
            m_An.SetBool("Levitation", true);
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
        m_An.SetBool("Levitation", false);
        m_Levitating = false;
        m_PlayerJump.enabled = true;
        transform.GetChild(5).GetComponent<BlockPushed>().m_Levitation = false;
        transform.GetChild(5).transform.parent = null;
        yield return null;
    }
}
