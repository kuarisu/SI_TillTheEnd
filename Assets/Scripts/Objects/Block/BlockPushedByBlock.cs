using UnityEngine;
using System.Collections;

public class BlockPushedByBlock : MonoBehaviour {

    float m_Timer = 100;
    Vector3 m_StartPos;
    Vector3 m_Target;
    Vector3 m_Direction;
    Rigidbody m_Rb;

    void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "BlockMove" )//&& col.gameObject.GetComponent<BlockPushed>().m_IsMoving == true)
        {
            m_Target = col.gameObject.transform.position;
            StartCoroutine(PushedByBlock());
        }
    }

    private IEnumerator PushedByBlock()
    {
        m_Direction = (m_Target - transform.position).normalized;
        m_StartPos = transform.position;
        int _timePassed = 0;
        while (_timePassed < m_Timer)
        {
            m_Rb.isKinematic = false;
            //transform.position = new Vector2(transform.position.x + m_direction.x, transform.position.y + m_direction.y);
            m_Rb.velocity = m_Direction * 10;
            _timePassed++;
            Debug.Log(_timePassed);
            yield return new WaitForEndOfFrame();
        }
        m_Rb.velocity = new Vector3(0, 0, 0);
        m_Rb.isKinematic = true;
    }

}
