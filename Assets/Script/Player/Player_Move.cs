using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour
{
    private int m_PlayerID;

    private bool IsMoving = false;      //Définit si le Player est en mouvement ou non
    private float Movement = 0.15f;      //Vitesse de déplacement du 

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
    }

    void Update()
    { 
        //Moving to the Right
        if (Input.GetAxisRaw("L_XAxis_"+m_PlayerID.ToString()) > 0.3)
        {
            StartCoroutine(RightMovement());
        }
        //Moving to the Left
        if (Input.GetAxisRaw("L_XAxis_" + m_PlayerID.ToString()) < -0.3)
        {
            StartCoroutine(LeftMovement());
        }
        //Jumping
        if (Input.GetButtonDown("A_" + m_PlayerID.ToString()))
        {
            StartCoroutine(Jumping());
        }


    }

    //A remplacer par un saut
    IEnumerator Jumping()
    {
        //Mettre un IsGrounded et réfléchir à comment le mettre avec les bloc pour que ça ne rentre pas en conflit lors des chocs. 
        //Si le joueur touche un bloc pas par le dessus il meurt ou est poussé si il est en mouvement
        //Si le joueur arrive sur un bloc par le dessus même en mouvement il ne meurt pas
        yield return null;
    }

    IEnumerator RightMovement()
    {
        IsMoving = true;
        transform.position = transform.position + (transform.right * Movement);
        yield return null;
        IsMoving = false;
    }

    IEnumerator LeftMovement()
    {
        IsMoving = true;
        transform.position = transform.position - (transform.right * Movement);
        yield return null;
        IsMoving = false;
    }
}