using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    private int m_PlayerID;
    private bool m_PlayerIsGrounded;
    private int m_NbJumps = 1;
    private float m_JumpSpeed = 35f;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
       
    }

    void Update () {


        //Jumping
        if (Input.GetButtonDown("A_" + m_PlayerID.ToString()))
        {

            StartCoroutine(Jumping());
            JumpsCount();
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

            int _time = 15;
            for (int i = 0; i < _time; i++)
            {
                m_PlayerIsGrounded = true;
                transform.Translate((Vector3.up * m_JumpSpeed) * Time.smoothDeltaTime) ;
                yield return new WaitForEndOfFrame();
            }

        }

        yield return null;
    }


    // ANCIENNE VERSION DU SAUT AU CAS OU LA NOUVELLE NE MARCHE PAS
    ////Saut Simple, Penser à ménager pour un saut double et aussi au wall jump
    //IEnumerator Jumping()
    //{
    //    //Sauter tout le temps, mais y a un compteur et si il tombe à 0 on ne peut plus sauter (donc pas de limitation de saut SEULEMENT quand isGrounded. A voir)
    //    if (m_PlayerIsGrounded == false)
    //    {
    //        Debug.Log("hello false");

    //        yield return null;
    //    }
    //    if (m_PlayerIsGrounded == true)
    //    {
    //        Debug.Log("hello true");
    //        m_IsJumping = true;
    //        #region Jump + changing gravity

    //        int _time = 15;
    //        for (int i = 0; i < _time; i++)
    //        {
    //            Debug.Log("Hello int");

    //            m_PlayerIsGrounded = true;
    //            transform.Translate((Vector3.up * m_JumpSpeed) * Time.smoothDeltaTime);
    //            yield return new WaitForEndOfFrame();
    //        }

    //        Debug.Log("hello end");
    //        m_PlayerIsGrounded = true;
    //        #endregion
    //        m_IsJumping = false;

    //    }

    //    yield return null;
    //}
}

