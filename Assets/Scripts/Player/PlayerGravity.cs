using UnityEngine;
using System.Collections;

public class PlayerGravity : MonoBehaviour {

    //[HideInInspector]
    public bool m_IsGrounded = true;
    [HideInInspector]
    public bool m_OnBlock = false;
    [HideInInspector]
    public bool m_Gravity = true;
    [HideInInspector]
    public GameObject m_BlockTouched;

    public Animator m_An;

    public RaycastHit hit;
    [SerializeField]
    private int m_GravityStrengthForce = 400;
    private float m_GroundingHeight = 0.4f;

    private Rigidbody rb;


	void Start () {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(IsGrounded());
	}

    void Update()
    {
        Ray groundingRay = new Ray(transform.position, Vector3.down);
        Debug.DrawRay(transform.position, Vector3.down);

        if (Physics.Raycast(groundingRay, out hit, m_GroundingHeight))
        {
            
            if (hit.collider.tag == "BlockStill" || hit.collider.tag == "BlockMove")
            {
                m_IsGrounded = true;
                m_An.SetBool("m_IsGrounded", true);
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
            m_An.SetBool("m_IsGrounded", false);
        }

    }


    IEnumerator IsGrounded()
    {
        while (true)
        {
            if (m_IsGrounded == false && !GetComponent<PlayerJump>().m_IsJumping)
            {
                rb.AddForce(Vector3.down * m_GravityStrengthForce);
            }
            yield return new WaitForEndOfFrame();
        }

    }
        void OnCollisionEnter (Collision col)
        {
            if((col.collider.tag == "Floor" || col.collider.tag == "BlockStill" || col.collider.tag == "BlockMove"))
            {
            SoundManagerEvent.emit(SoundManagerType.PlayerColision);
            }
        }
        	
}
