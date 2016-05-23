using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour {

    public Animator m_An;

    private int m_PlayerID;
    private bool m_PlayerIsGrounded;
    private bool m_IsReSpwaning = false;
    //private int m_MaxJump = 50;
    private Rigidbody rb;
    private int m_NbJumps = 2;

    [SerializeField]
    private float m_JumpSpeedMax = 10;
    [SerializeField]
    private float m_TimerJump;

    public bool m_IsJumping;
    public GameObject m_PSJump;


    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        rb = GetComponent<Rigidbody>();
        m_PSJump.SetActive(false);
        m_IsJumping = false;


    }

    void Update() {
        m_IsReSpwaning = GetComponent<PlayerDeath>().m_IsRespawning;
        m_PlayerIsGrounded = GetComponent<PlayerGravity>().m_IsGrounded;

        if (m_PlayerIsGrounded == true)
        {
            m_NbJumps = 2;
        }

        //Jumping
        if (Input.GetButtonDown("A_" + m_PlayerID.ToString()) && m_IsReSpwaning == false)
        {
            if (m_NbJumps > 0)
            {
                StopAllCoroutines();
                StartCoroutine(Jumping());
                StartCoroutine(JumpTimer());
                StartCoroutine(StopAnim());
                JumpsCount();
            }
        }
    }

    void JumpsCount()
    {
        if (m_NbJumps > 0)
        {
            m_NbJumps--;
        }
    }

    IEnumerator Jumping()
    {
      
            m_An.SetBool(" m_IsJumpingAnim", true);
            SoundManagerEvent.emit(SoundManagerType.PlayerJump);
            m_IsJumping = true;

            m_PSJump.SetActive(false);
            m_PSJump.SetActive(true);

            #region AVEC VELOCITY
            float _time = 0;
            float _currentJumpSpeed = m_JumpSpeedMax;

            while (m_IsJumping == true && _time < m_TimerJump)
            {
                _time += Time.deltaTime;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.velocity += Vector3.up * _currentJumpSpeed;
                //rb.AddForce(Vector3.up * (_currentJumpSpeed + 500));
                _currentJumpSpeed -= (m_JumpSpeedMax / m_TimerJump) * Time.deltaTime;

                //rb.MovePosition(transform.position + transform.up * m_JumpSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            #endregion

            #region AVEC TRANSFORM.POSITION
            //float _const;
            //float _y;
            //float atime = 0;
            //Vector3 _startPos = transform.position;
            //float _heightJump = 5;

            //while (atime < m_TimerJump)
            //{
            //    _const = Mathf.Lerp(-1, 0, atime / m_TimerJump);
            //    _y = Mathf.Lerp(_heightJump, 0, Mathf.Pow(_const, 2));
            //    atime += Time.deltaTime;
            //    transform.position = new Vector3(transform.position.x,
            //                                    _startPos.y + _y,
            //                                    transform.position.z);
            //    yield return new WaitForEndOfFrame();
            //}
            #endregion

            //int _time = 30;
            //for (int i = 0; i < _time; i++)
            //{
            //    m_PlayerIsGrounded = true;
            //    transform.Translate((Vector3.up * m_JumpSpeed) * Time.deltaTime);
            //    //rb.MovePosition((transform.position + (transform.up * m_JumpSpeed)) * Time.sm);
            //    yield return new WaitForEndOfFrame();
            //}
       
        yield return null;
    }

    IEnumerator JumpTimer()
    {
        yield return new WaitForSeconds(m_TimerJump);
        m_IsJumping= false;
    }

    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.5f);
        m_An.SetBool(" m_IsJumpingAnim", false);
        m_PSJump.SetActive(false);
    }



    // while (m_IsMoving == true)
    //{
    //    if (m_Movement<m_MaxMove)
    //        m_Movement = m_Movement + 1.5f;

    //    rb.MovePosition(transform.position - transform.right* m_Movement * Time.deltaTime);
    //    yield return new WaitForEndOfFrame();
//}
}

