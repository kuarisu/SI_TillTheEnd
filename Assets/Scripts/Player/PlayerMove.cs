using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    private int m_PlayerID;

    private bool m_IsMoving = false;      //Définit si le Player est en mouvement ou non
    private float m_Movement = 0.23f;     //Vitesse de déplacement du mouvement
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
        m_InLevitation = GetComponent<PlayerLevitation>().m_Levitating;

        if (m_InLevitation == true)
        {
            m_Movement = 0.05f;
        }
        else if (m_InLevitation == false)
        {
            m_Movement = 0.23f;
        }

        //Moving to the Right
        if (Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) > 0.3 && m_IsReSpwaning == false)
        {
            StartCoroutine(RightMovement());
        }
        //Moving to the Left
        if (Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) < -0.3 && m_IsReSpwaning == false)
        {
            StartCoroutine(LeftMovement());
        }
    }

    IEnumerator RightMovement()
    { 
        m_IsMoving = true;
        transform.position = transform.position + (transform.right * m_Movement);
        //rb.MovePosition(transform.position + (transform.right * m_Movement));
        yield return null;
        m_IsMoving = false;
    }

    IEnumerator LeftMovement()
    {
        m_IsMoving = true;
        transform.position = transform.position - (transform.right * m_Movement);
        //rb.MovePosition(transform.position - (transform.right * m_Movement));
        yield return null;
        m_IsMoving = false;
    }
}