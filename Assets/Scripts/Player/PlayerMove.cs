using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{

    public Animator m_An;

    private int m_PlayerID;
    public GameObject Visual;

    private bool m_IsMoving = false;      //Définit si le Player est en mouvement ou non
    private float m_MoveSpeed;             //Vitesse de déplacement du mouvement
    //private float m_LevitationSpeed = 1f;
    [SerializeField]
    private int m_MaxMoveSpeed = 8;
    [SerializeField]
    private float m_Acceleration = 1;
    private bool m_IsReSpwaning = false;
    public bool m_InLevitation = false;
    private Rigidbody rb;



    private Vector3 m_Direction;


    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        rb = GetComponent<Rigidbody>();
        m_MoveSpeed = 0;
    }

    void Update()
    {
        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;
        //m_InLevitation = GetComponent<PlayerLevitation>().m_Levitating;

        if (Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) > 0.5f || Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) < -0.5f)
        {
            m_An.SetBool("m_IsMovingChara", true);
        }
        else
        {
            m_An.SetBool("m_IsMovingChara", false);
            m_IsMoving = false;
            m_MoveSpeed = 0;
        }
        if (m_IsReSpwaning == true)
        {
            m_MoveSpeed = 0;
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

        m_Direction = Vector3.right * Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString());
        m_Direction.Normalize();

        rb.velocity = m_Direction * m_MoveSpeed;

        //dtransform.position += Vector3.right * Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) * m_MaxMove * Time.deltaTime;


    }

    IEnumerator RightMovement()
    {
        if( m_MoveSpeed < m_MaxMoveSpeed)
            m_MoveSpeed += m_Acceleration;

        //rb.MovePosition(transform.position + transform.right * m_Movement * Time.deltaTime);

        yield return null;
    }

    IEnumerator LeftMovement()
    {

        if (m_MoveSpeed < m_MaxMoveSpeed)
            m_MoveSpeed += m_Acceleration;

        //rb.MovePosition(transform.position - transform.right * m_Movement * Time.deltaTime);

        yield return null;

    }
}