using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

    public bool m_IsGrounded = true;
    public int m_GravityStrength;
    public float m_GroundingHeight;

	void Start () {
        StartCoroutine(IsGrounded());
	}

    void Update()
    {
        RaycastHit hit;
        Ray groundingRay = new Ray(transform.position, Vector3.down);
            
        if(Physics.Raycast(groundingRay, out hit, m_GroundingHeight))
        {
            if(hit.collider.tag == "Floor" || hit.collider.tag == "Block")
            {
                m_IsGrounded = true;
            }
        }
        else
        {
            m_IsGrounded = false;
        }
        
    }


    IEnumerator IsGrounded()
    {
        Debug.Log(m_IsGrounded);
        while (true)
        {
            if (m_IsGrounded == true)
            {
                yield return new WaitForEndOfFrame();
            }
            if (m_IsGrounded == false)
            {
                Debug.Log("coucouw");
                transform.Translate((-Vector3.up * m_GravityStrength) * Time.smoothDeltaTime);
            }
            yield return new WaitForEndOfFrame();
        }

        
    }
	
}
