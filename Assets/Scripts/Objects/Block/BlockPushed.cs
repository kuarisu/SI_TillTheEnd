using UnityEngine;
using System.Collections;

public class BlockPushed : MonoBehaviour {


    Vector3 m_currentPosition;
    Rigidbody m_Rb;
    Vector3 m_direction;
    float _bounceSpeed = 0.4f;
    ParticleSystem.EmissionModule m_PsPushed;

    public GameObject m_PlayerTarget;
    public int m_Timer = 5;
    public bool m_IsMoving = false;
    public bool m_Levitation = false;
    public int IdBlock;

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
        
    }

    public void PushedCoroutine()
    {
        StartCoroutine(Pushed());
        Vector3 _positionTarget = m_PlayerTarget.transform.position;
        m_direction = (_positionTarget - transform.position).normalized * _bounceSpeed;
    }

    private IEnumerator Pushed()
    {
        SoundManagerEvent.emit(SoundManagerType.BlockPushed);
        m_PsPushed.enabled = true;
        int _timePassed = 0;
        while(_timePassed < m_Timer )
        {
            transform.position = new Vector2(transform.position.x + m_direction.x, transform.position.y + m_direction.y);
            _timePassed++;
            yield return new WaitForEndOfFrame();
        }
        m_PsPushed.enabled = false;

    }

    void OnCollisionEnter(Collision col)
    {

        //Penser à utiliser un layer à part pour le perso plutôt que quinze mille tag
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "BlockStill" || col.gameObject.tag == "BlockMove" || col.gameObject.tag == "DeathZone")
        {
            SoundManagerEvent.emit(SoundManagerType.BlockColision);
            Vector3 _colNormale = col.contacts[0].normal;
            float _AngleReflex = ((Vector3.Angle(m_direction, _colNormale)));
            m_direction = (Quaternion.Euler(0, 0, _AngleReflex) * m_direction);

        }


        //Récupérer le point de collision azvec le mur récupérer la normale de ce point de coll'
        //Trouver l'angle entre l'arriver du point et la normal, faire 1/sin(angle trouvé) et faire rotate la direction d'autant.
    }

}
