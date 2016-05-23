using UnityEngine;
using System.Collections;

public class BlockPushed : MonoBehaviour {


    Vector3 m_currentPosition;
    Rigidbody m_Rb;
    Vector3 m_direction;
    ParticleSystem.EmissionModule m_PsPushed;
    Vector3 m_StartPos;
    [SerializeField]
    GameObject m_ColBlock;

    public float m_MoveBlockSpeed = 15;
    public GameObject m_PlayerTarget;
    public float m_Timer = 1.5f;
    public bool m_IsMoving = false;
    public bool m_Levitation = false;
    public int IdBlock;
    public GameObject m_PlayerPushing;


    void Start()
    {
        m_Timer = m_Timer * 30;
        m_Rb = GetComponent<Rigidbody>();
        m_currentPosition = transform.position;
        m_PsPushed = GetComponent<ParticleSystem>().emission;
        m_PsPushed.enabled = false;
    }

    void Update ()
    {
        if (transform.position != m_currentPosition && m_Levitation == false)
        {
            m_IsMoving = true;
            m_Rb.isKinematic = false;
        }
        if (transform.position == m_currentPosition)
        {
            m_IsMoving = false;
            m_Rb.isKinematic = true;
        }
        m_currentPosition = transform.position;

        Debug.DrawLine(m_currentPosition, m_currentPosition + m_direction, Color.red, 1, false);
    }

    public void PushedCoroutine()
    {

        Vector3 _positionTarget = m_PlayerTarget.transform.position;
        m_direction = (_positionTarget - transform.position).normalized;
        StartCoroutine(Pushed());

    }

    private IEnumerator Pushed()
    {
        m_StartPos = transform.position;
        SoundManagerEvent.emit(SoundManagerType.BlockPushed);
        m_PsPushed.enabled = true;
        int _timePassed = 0;
        while(_timePassed < m_Timer )
        {
            m_Rb.isKinematic = false;
            //transform.position = new Vector2(transform.position.x + m_direction.x, transform.position.y + m_direction.y);
            m_Rb.velocity = m_direction * m_MoveBlockSpeed;
            _timePassed++;
            yield return new WaitForEndOfFrame();
        }
        m_Rb.velocity = new Vector3 (0, 0,0);
        m_PlayerPushing = null;
        m_PsPushed.enabled = false;

    }

    void OnCollisionEnter(Collision col)
    {

        if (col.collider.gameObject.tag == "Player" && (IdBlock != col.collider.transform.parent.GetComponent<Player>().m_PlayerID) && m_IsMoving == true)
        {
                col.gameObject.GetComponent<PlayerDeath>().Death();
                m_PlayerPushing.GetComponent<PlayerScoring>().Killed();
        }

        //Penser à utiliser un layer à part pour le perso plutôt que quinze mille tag
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "BlockStill" || col.gameObject.tag == "BlockMove" || col.gameObject.tag == "DeathZone")
        {
            if (m_ColBlock == null)
            {
                m_ColBlock = col.gameObject;
                Debug.DrawLine(col.contacts[0].point, col.contacts[0].point + col.contacts[0].normal * 5, Color.blue, 10, false);
                SoundManagerEvent.emit(SoundManagerType.BlockColision);

                Vector3 _colNormale = col.contacts[0].normal;
                m_direction = Vector3.Reflect(col.contacts[0].point - m_StartPos, _colNormale).normalized;
                m_StartPos = transform.position;
                StartCoroutine(Clearlist());

            }
        }
    }

    IEnumerator Clearlist ()
    {
        yield return new WaitForEndOfFrame();
        m_ColBlock = null;
        yield return null;
    }

}
