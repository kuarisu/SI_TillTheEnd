using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    public Animator m_An;

    private int m_PlayerID;
    private bool m_PlayerIsGrounded;
    private bool m_IsReSpwaning = false;
    private float m_JumpSpeed = 35f;
    private Rigidbody rb;


    public bool m_IsJumpingAnim = false;
    public GameObject m_PSJump;


    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        rb = GetComponent<Rigidbody>();
        m_PSJump.SetActive(false);


    }

    void Update () {

        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;

        //Jumping
        if (Input.GetButtonDown("A_" + m_PlayerID.ToString()) && m_IsReSpwaning == false)
        {
            m_IsJumpingAnim = true;
            m_An.SetBool(" m_IsJumpingAnim", true);
            StartCoroutine(Jumping());
            StartCoroutine(StopAnim());
            m_IsJumpingAnim = false;
        }
        
        m_PlayerIsGrounded = GetComponent<PlayerGravity>().m_IsGrounded;
    }

    IEnumerator Jumping()
    {
        SoundManagerEvent.emit(SoundManagerType.PlayerJump);
        //Sauter tout le temps, mais y a un compteur et si il tombe à 0 on ne peut plus sauter (donc pas de limitation de saut SEULEMENT quand isGrounded. A voir)
        m_PSJump.SetActive(false);
        m_PSJump.SetActive(true);
        int _time = 20;
        for (int i = 0; i < _time; i++)
        {
            m_PlayerIsGrounded = true;
            transform.Translate((Vector3.up * m_JumpSpeed) * Time.deltaTime) ;
            //rb.MovePosition((transform.position + (transform.up * m_JumpSpeed)) * Time.sm);
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.5f);
        m_An.SetBool(" m_IsJumpingAnim", false);
        m_PSJump.SetActive(false);
    }
}

