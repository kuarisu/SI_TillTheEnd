using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

    [HideInInspector]
    public bool m_IsGrounded = true;
    [HideInInspector]
    public bool m_OnBlock = false;


    private int m_GravityStrength = 10;
    private float m_GroundingHeight = 0.1f;


	void Start () {
        StartCoroutine(IsGrounded());
	}

    void Update()
    {

        Debug.Log("grounded" + m_IsGrounded);
        Debug.Log("onblock" + m_OnBlock);
        RaycastHit hit;
        Ray groundingRay = new Ray(transform.position, Vector3.down);
            
        if(Physics.Raycast(groundingRay, out hit, m_GroundingHeight))
        {
            if(hit.collider.tag == "Floor" || hit.collider.tag == "BlockStill" || hit.collider.tag == "BlockMove")
            {
                m_IsGrounded = true;
                if (hit.collider.tag == "BlockMove")
                {
                    m_OnBlock = true; //CE BOOL AUTORISE OU NON LE TARGETING DANS PLAYERTARGET ET LE PUSH AND PLAYERPUSH (Push, depuis le joueur ou sur le bloc ? ou Alors se lance sur le joueur et active le script du bloc ?)
                }
                else
                {
                    m_OnBlock = false;
                }
            }
        }
        else
        {
            m_OnBlock = false;
            m_IsGrounded = false;
        }
        
    }


    IEnumerator IsGrounded()
    {
        while (true)
        {
            if (m_IsGrounded == true)
            {
                yield return new WaitForEndOfFrame();
            }
            if (m_IsGrounded == false)
            {
                transform.Translate((-Vector3.up * m_GravityStrength) * Time.smoothDeltaTime);
            }
            yield return new WaitForEndOfFrame();
        }

        
    }
	
}
