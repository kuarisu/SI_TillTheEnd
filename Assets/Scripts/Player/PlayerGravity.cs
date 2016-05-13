using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

    [HideInInspector]
    public bool m_IsGrounded = true;
    [HideInInspector]
    public bool m_OnBlock = false;
    [HideInInspector]
    public bool m_Gravity = true;
    [HideInInspector]
    public GameObject m_BlockTouched;

    public RaycastHit hit;
    private int m_GravityStrength = 20;
    private float m_GroundingHeight = 0.5f;


	void Start () {
        StartCoroutine(IsGrounded());
	}

    void Update()

    {
        Ray groundingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down);

        if (Physics.Raycast(groundingRay, out hit, m_GroundingHeight))
        {
            
            if (hit.collider.tag == "Floor" || hit.collider.tag == "BlockStill" || hit.collider.tag == "BlockMove")
            {
                m_IsGrounded = true;
                if (hit.collider.tag == "BlockMove")
                {
                    m_OnBlock = true; 
                    m_BlockTouched = hit.collider.gameObject;
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
