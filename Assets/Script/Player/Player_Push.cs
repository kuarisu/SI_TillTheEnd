using UnityEngine;
using System.Collections;

public class Player_Push : MonoBehaviour {

    public GameObject Physic;

    private int m_PlayerID;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("A_"+m_PlayerID.ToString()))
        {
            Debug.Log("PlayerOne_Push");
            StartCoroutine(Push());
        }
    }


    //Enable a Trigger to active movement script of the cubes
    IEnumerator Push()
    {
        
        Physic.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        Physic.GetComponent<BoxCollider>().enabled = false;
        yield return null;
    }

}
