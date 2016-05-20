using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    public Animator m_An;

    private int m_PlayerID;
    public GameObject Visual;

    private bool m_IsMoving = false;      //Définit si le Player est en mouvement ou non
    private float m_Movement;             //Vitesse de déplacement du mouvement
    private float m_LevitationSpeed = 1f;
    private float m_MoveSpeed = 1f;
    private int m_MaxMove = 30;
    private bool m_IsReSpwaning = false;
    public bool m_InLevitation = false;
    private Rigidbody rb;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;
        m_Movement = 0;
        //m_InLevitation = GetComponent<PlayerLevitation>().m_Levitating;

        if (Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) > 0.5f || Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) < -0.5f)
        {
            m_An.SetBool("m_IsMovingChara", true);
        }
        else
        {
            m_An.SetBool("m_IsMovingChara", false);
            m_IsMoving = false;
            m_Movement = 0;
        }
        if (m_IsReSpwaning == true)
        {
            m_Movement = 0;
        }

        //if (m_InLevitation == true)
        //{
        //    m_Movement = m_LevitationSpeed;
        //}
        //else if (m_InLevitation == false)
        //{
        //    m_Movement = m_MoveSpeed;
        //}

        //Moving to the Right
        if (Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) > 0 && m_IsReSpwaning == false)
        {
            m_IsMoving = true;
            Visual.transform.eulerAngles = new Vector3(0, 0, 0); 
            StartCoroutine(RightMovement());

        }
        //Moving to the Left
        if (Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) < 0 && m_IsReSpwaning == false)
        {
            m_IsMoving = true;
            Visual.transform.eulerAngles = new Vector3(0, -180, 0);
            StartCoroutine(LeftMovement());
        }
    }

    IEnumerator RightMovement()
    { 
        m_IsMoving = true;

        while (m_IsMoving == true)
        {
            if( m_Movement < m_MaxMove)
                m_Movement = m_Movement + 0.5f;

            rb.MovePosition(transform.position + transform.right * m_Movement * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }

    IEnumerator LeftMovement()
    {
   
        while (m_IsMoving == true)
        {
            if (m_Movement < m_MaxMove)
                m_Movement = m_Movement + 0.5f;

            rb.MovePosition(transform.position - transform.right * m_Movement * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        yield return null;

    }
}