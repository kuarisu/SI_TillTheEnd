using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    public Animator m_An;

    private int m_PlayerID;
    private bool m_PlayerIsGrounded;
    private bool m_IsReSpwaning = false;
    private float m_JumpSpeed = 15;
    private int m_MaxJump = 50;
    private Rigidbody rb;
    private int m_NbJumps = 1;

    public float m_TimerJump;
    public bool m_IsJumping;
    public GameObject m_PSJump;


    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        rb = GetComponent<Rigidbody>();
        m_PSJump.SetActive(false);
        m_IsJumping = false;


    }

    void Update() {
        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;
        m_PlayerIsGrounded = GetComponent<PlayerGravity>().m_IsGrounded;
        Debug.Log(m_IsJumping);

        //Jumping
        if (Input.GetButtonDown("A_" + m_PlayerID.ToString()) && m_IsReSpwaning == false)
        {
            StartCoroutine(Jumping());
            StartCoroutine(JumpTimer());
            StartCoroutine(StopAnim());
            JumpsCount();
        }


        if(m_IsJumping == false)
        {
            m_JumpSpeed = 15;
        }

        if (m_PlayerIsGrounded == true && m_NbJumps != 1)
        {
            m_NbJumps = 1;
        }
    }

    void JumpsCount()
    {
        if (m_NbJumps > 0)
        {
            m_NbJumps--;
        }
    }

    IEnumerator Jumping()
    {
        m_An.SetBool(" m_IsJumpingAnim", true);

        if (m_NbJumps > 0)
        { 
            SoundManagerEvent.emit(SoundManagerType.PlayerJump);
            m_IsJumping = true;


            //Sauter tout le temps, mais y a un compteur et si il tombe à 0 on ne peut plus sauter (donc pas de limitation de saut SEULEMENT quand isGrounded. A voir)
            m_PSJump.SetActive(false);
            m_PSJump.SetActive(true);
            int _time = 0;

            while (m_IsJumping == true)
            {
                Debug.Log("hey");
                Debug.Log("Time " + _time);
                if (_time < m_TimerJump)
                {
                    if (m_JumpSpeed < m_MaxJump)
                        m_JumpSpeed = m_JumpSpeed + 4f;

                    rb.MovePosition(transform.position + transform.up * m_JumpSpeed * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                }
            }


        //int _time = 30;
        //for (int i = 0; i < _time; i++)
        //{
        //    m_PlayerIsGrounded = true;
        //    transform.Translate((Vector3.up * m_JumpSpeed) * Time.deltaTime);
        //    //rb.MovePosition((transform.position + (transform.up * m_JumpSpeed)) * Time.sm);
        //    yield return new WaitForEndOfFrame();
        //}
    }
        yield return null;
    }

    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(m_TimerJump);
        m_IsJumping= false;
    }

    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.5f);
        m_An.SetBool(" m_IsJumpingAnim", false);
        m_PSJump.SetActive(false);
    }



    // while (m_IsMoving == true)
    //{
    //    if (m_Movement<m_MaxMove)
    //        m_Movement = m_Movement + 1.5f;

    //    rb.MovePosition(transform.position - transform.right* m_Movement * Time.deltaTime);
    //    yield return new WaitForEndOfFrame();
//}
}

