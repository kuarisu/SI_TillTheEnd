using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    private int m_PlayerID;

    private bool m_IsGrounded = true;     //Définit si le Player est sur le sol ou non (donc si il peut sauter ou non)
    private bool m_IsJumping = false;     //Définit si le Player est entrain de sauter ou non
    public float m_JumpCoolDown = 100f;
    private float m_JumpSpeed = 20f;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
    }

    // Update is called once per frame
    void Update () {

        //Jumping
        if (Input.GetButtonUp("A_" + m_PlayerID.ToString()))
        {
            StartCoroutine(Jumping());
        }

        //if (m_IsGrounded == false)
        //{
        //    GetComponent<Rigidbody>().useGravity = true;
        //}
        //if (m_IsGrounded == true)
        //{
        //    GetComponent<Rigidbody>().useGravity = false;
        //}
    }

    //Saut Simple, Penser à ménager pour un saut double et aussi au wall jump
    IEnumerator Jumping()
    {
        //Mettre un IsGrounded et réfléchir à comment le mettre avec les bloc pour que ça ne rentre pas en conflit lors des chocs. 
        //Si le joueur touche un bloc pas par le dessus il meurt ou est poussé si il est en mouvement
        //Si le joueur arrive sur un bloc par le dessus même en mouvement il ne meurt pas
        if (m_IsGrounded == false)
        {
            yield return null; //Mettre le double saut ici ?
        }
        if (m_IsGrounded)
        {
            m_IsJumping = true;
            #region Jump + changing gravity

            GetComponent<Rigidbody>().useGravity = false;
            int _time = 20;
            for (int i = 0; i < _time; i++)
            {
                transform.Translate((Vector3.up * m_JumpSpeed) * Time.smoothDeltaTime) ;
               yield return new WaitForEndOfFrame();
            }

            GetComponent<Rigidbody>().useGravity = true;
            #endregion


            m_IsJumping = false;

        }

        yield return null;
    }
}
