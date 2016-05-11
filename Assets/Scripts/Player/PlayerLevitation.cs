using UnityEngine;
using System.Collections;

public class PlayerLevitation : MonoBehaviour {
    private int m_PlayerID;
    private bool m_isGrounded;
    private bool m_OnBlock;
    private RaycastHit hit;

    void Start () {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
    }
	
	// Update is called once per fram
	void Update () {

        m_isGrounded = GetComponent<PlayerGravity>().m_IsGrounded;
        m_OnBlock = GetComponent<PlayerGravity>().m_OnBlock;
        hit = GetComponent<PlayerGravity>().hit;

        if (Input.GetButtonDown("X_" + m_PlayerID.ToString()))
        {
            StartCoroutine(Levitation());
        }
    }

    IEnumerator Levitation()
    {
        while (Input.GetButton("X_" + m_PlayerID.ToString()) && m_isGrounded == true && m_OnBlock )
        {
            Vector3 m_blockPos =  hit.collider.gameObject.transform.position;
            Debug.Log(hit.collider.gameObject.transform.name);
            m_blockPos = new Vector3(0,0,0); //NOT WORKING
            yield return new WaitForEndOfFrame();
        }
    }
}
