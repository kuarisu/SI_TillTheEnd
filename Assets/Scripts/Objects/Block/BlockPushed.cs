using UnityEngine;
using System.Collections;

public class BlockPushed : MonoBehaviour {


    Vector3 m_currentPosition;
    Rigidbody m_Rb;
    Vector3 m_direction;
    ParticleSystem.EmissionModule m_PsPushed;
    Vector3 m_StartPos;
    Vector3 m_RespawnPos;
    [SerializeField]
    GameObject m_ColBlock;
    Vector3 m_BlockTarget;

    public Animator An;
    public float m_TimerRespawn;
    public float m_MoveBlockSpeed = 15;
    public GameObject m_PlayerTarget;
    public float m_Timer = 1.5f;
    private float m_TimerBlock = 30;
    public bool m_IsMoving = false;
    //public bool m_Levitation = false;
    public int IdBlock;
    public GameObject m_PlayerPushing;
    public GameObject m_FXDespawn;
    public GameObject m_FXRespawn;


    void Start()
    {
        m_RespawnPos = transform.position;
        m_StartPos = transform.position;
        m_Rb = GetComponent<Rigidbody>();
        m_currentPosition = transform.position;
        m_PsPushed = GetComponent<ParticleSystem>().emission;
        m_PsPushed.enabled = false;
        m_Rb.isKinematic = true;
    }

    void Update ()
    {
        //if (transform.position != m_currentPosition)
        //{
        //    m_IsMoving = true;
        //    m_Rb.isKinematic = false;
        //}
        //if (transform.position == m_currentPosition)
        //{
        //    m_IsMoving = false;
        //    m_Rb.isKinematic = true;
        //}
        //m_currentPosition = transform.position;

    }

    public void PushedCoroutine()
    {
        StopAllCoroutines();
        Vector3 _positionTarget = m_PlayerTarget.transform.position;
        m_direction = (_positionTarget - transform.position).normalized;
        StartCoroutine(Pushed());
    }


    private IEnumerator Pushed()
    {
        switch (IdBlock)
        {
            case 1:
                gameObject.layer = 10;

                break;

            case 2:
                gameObject.layer = 11;

                break;

            default:
                break;
        }
        SoundManagerEvent.emit(SoundManagerType.BlockPushed);
        m_PsPushed.enabled = true;
        float _timePassed = 0;
        float _currentSpeed = m_MoveBlockSpeed;
        while(_timePassed < m_Timer )
        {
            if (_timePassed > m_Timer / 4)
            {
                _currentSpeed -= (m_MoveBlockSpeed / m_Timer )* Time.deltaTime;
            }
            m_Rb.isKinematic = false;
            //transform.position = new Vector2(transform.position.x + m_direction.x, transform.position.y + m_direction.y);
            m_Rb.velocity = m_direction * _currentSpeed;
            _timePassed += Time.deltaTime;



            yield return new WaitForEndOfFrame();
        }
        gameObject.layer = 0;
        m_Rb.velocity = new Vector3 (0, 0,0);
        m_Rb.isKinematic = true;
        m_PlayerPushing = null;
        m_PsPushed.enabled = false;

        m_FXDespawn.SetActive(true);
        yield return new WaitForSeconds(m_TimerRespawn);
        m_FXDespawn.SetActive(false);
        transform.position = m_RespawnPos;
        m_FXRespawn.SetActive(true);
        m_StartPos = transform.position;
        yield return new WaitForSeconds(0.75f);
        m_FXRespawn.SetActive(false);

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Player" && (IdBlock != col.collider.transform.parent.GetComponent<Player>().m_PlayerID) && m_Rb.isKinematic == false)
        {
  
            col.gameObject.GetComponent<PlayerDeath>().Death();
            m_PlayerPushing.GetComponent<PlayerScoring>().Killed();
        }

        //Penser à utiliser un layer à part pour le perso plutôt que quinze mille tag
        if (col.gameObject.tag == "Floor" || col.gameObject.tag == "BlockStill" || col.gameObject.tag == "BlockMove" || col.gameObject.tag == "DeathZone")
        {
            An.SetTrigger("Collision");
            if (m_ColBlock == null)
            {
                CameraShake.instance.ScreenShakeStart();
                m_ColBlock = col.gameObject;
                SoundManagerEvent.emit(SoundManagerType.BlockColision);

                Vector3 _colNormale = col.contacts[0].normal;
                m_direction = Vector3.Reflect(col.contacts[0].point - m_StartPos, _colNormale).normalized;
                m_StartPos = transform.position;
                StartCoroutine(Clearlist());

            }
        }

        if (col.gameObject.tag == "BlockMove" && col.gameObject.GetComponent<BlockPushed>().m_Rb.isKinematic == true)
        {
            
            col.gameObject.GetComponent<BlockPushed>().m_BlockTarget = transform.position;
            col.gameObject.GetComponent<BlockPushed>().StartPushedByBlock();
            col.gameObject.GetComponent<BlockPushed>().m_PlayerPushing = m_PlayerPushing;

        }
    }

    public void StartPushedByBlock()
    {
        m_direction = (m_BlockTarget - transform.position).normalized;
        StartCoroutine(PushedByBlock());
    }

    IEnumerator PushedByBlock()
    {
        m_Rb.isKinematic = false;
        m_StartPos = transform.position;
        SoundManagerEvent.emit(SoundManagerType.BlockPushed);
        m_PsPushed.enabled = true;
        int _timePassed = 0;
        while (_timePassed < m_TimerBlock)
        {
            m_Rb.isKinematic = false;
            m_Rb.velocity = - m_direction * m_MoveBlockSpeed;
            _timePassed++;
            yield return new WaitForEndOfFrame();
        }
        m_Rb.velocity = new Vector3(0, 0, 0);
        m_Rb.isKinematic = true;
        m_PsPushed.enabled = false;
        yield return null;
    }

    IEnumerator Clearlist ()
    {
        yield return new WaitForEndOfFrame();
        m_ColBlock = null;
        yield return null;
    }

}
