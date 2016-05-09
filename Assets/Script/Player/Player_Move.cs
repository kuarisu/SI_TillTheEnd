using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour
{

    private bool IsMoving = false;      //Définit si le Player est en mouvement ou non
    private float Movement = 0.15f;      //Vitesse de déplacement du 

    void Update()
    {
        if (Input.GetAxisRaw("L_YAxis_0") < -0.3) //&& IsMoving == false
        {
            StartCoroutine(UpMovement());
        }
        if (Input.GetAxisRaw("L_YAxis_0") > 0.3)
        {
            StartCoroutine(BackMovement());
        }
        if (Input.GetAxisRaw("L_XAxis_0") > 0.3)
        {
            StartCoroutine(RightMovement());
        }
        if (Input.GetAxisRaw("L_XAxis_0") < -0.3)
        {
            StartCoroutine(LeftMovement());
        }

    }

    //A remplacer par un saut
    IEnumerator UpMovement()
    {
        IsMoving = true;
        transform.position = (transform.position + (transform.up * Movement));
        yield return null;
        IsMoving = false;
    }
    //A remplacer par la gravité
    IEnumerator BackMovement()
    {
        IsMoving = true;
        transform.position = transform.position - (transform.up * Movement);
        yield return null;
        IsMoving = false;
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