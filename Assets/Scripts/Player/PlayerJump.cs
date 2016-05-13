using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    public Animator m_An;

    private int m_PlayerID;
    private bool m_PlayerIsGrounded;
    private int m_NbJumps = 1;
    private float m_JumpSpeed = 35f;
    public bool m_IsJumpingAnim = false;
    private Rigidbody rb;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        rb = GetComponent<Rigidbody>();
       
    }

    void Update () {


        //Jumping
        if (Input.GetButtonDown("A_" + m_PlayerID.ToString()))
        {
            m_IsJumpingAnim = true;
            m_An.SetBool(" m_IsJumpingAnim", true);
           StartCoroutine(Jumping());
            StartCoroutine(StopAnim());
            JumpsCount();
            m_IsJumpingAnim = false;
        }
        
        m_PlayerIsGrounded = GetComponent<PlayerGravity>().m_IsGrounded;

        if (m_PlayerIsGrounded == true && m_NbJumps != 1)
        {
            m_NbJumps = 1;
        }
    }

    void JumpsCount()
    {
        if(m_NbJumps > 0)
        {
            m_NbJumps--;
        }
    }

    IEnumerator Jumping()
    {
       //Sauter tout le temps, mais y a un compteur et si il tombe à 0 on ne peut plus sauter (donc pas de limitation de saut SEULEMENT quand isGrounded. A voir)
        if (m_NbJumps > 0)
        {

            int _time = 20;
            for (int i = 0; i < _time; i++)
            {
                m_PlayerIsGrounded = true;
                transform.Translate((Vector3.up * m_JumpSpeed) * Time.smoothDeltaTime) ;
                //rb.MovePosition((transform.position + (transform.up * m_JumpSpeed)) * Time.sm);
                yield return new WaitForEndOfFrame();
            }

        }

        yield return null;
    }

    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.5f);
        m_An.SetBool(" m_IsJumpingAnim", false);
    }
}

