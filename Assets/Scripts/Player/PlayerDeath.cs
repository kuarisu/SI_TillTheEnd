using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    bool m_IsMoving;
    private int m_PlayerID;
    private Vector3 m_currentSpawn;
    public bool m_IsRespawning;
    public GameObject Visual;
    public GameObject Physics;

    /*
    [SerializeField]
    int m_Test;
    public int GetTest()
    {
        return m_Test;
    }

    public void SetTest(string _function, int a)
    {
        if (a > 0)
        {
            if (a + 150 < 250)
            {
                m_Test = a;
            }
        }
    }

    void Method()
    {
        SetTest("Method", 10);
    }
    */

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        m_currentSpawn = GetComponent<Player>().m_SpawnPoint;

    }

    void OnCollisionEnter (Collision col)
    {
        if(col.collider.gameObject.tag == "DeathZone")
        {
            DeathZone();
        }
        if (col.collider.gameObject.tag == "BlockMove" && (col.collider.gameObject.GetComponent<BlockPushed>().IdBlock != m_PlayerID))
        {
           m_IsMoving =  col.collider.gameObject.GetComponent<BlockPushed>().m_IsMoving;
            if (m_IsMoving == true) 
            {
                DeathBlock();

                //A RETRAVAILLER PARCE QUE CA MARCHE PAS (pas deux collision en même temps)
                //if (col.collider.gameObject.tag == "Floor")
                //{
                //    DeathCrush();
                //}
            }

        }

    }

    void DeathZone()
    {
        StartCoroutine(ReSpawn());
    }

    void DeathBlock ()
    {
        StartCoroutine(ReSpawn());
    }

    void DeathCrush()
    {
        Debug.Log("Died by crushed");
        StartCoroutine(ReSpawn());

    }

    IEnumerator ReSpawn()
    {
        m_IsRespawning = true;
        Visual.SetActive(false);
        Physics.SetActive(false);
        yield return new WaitForSeconds(1);
        Visual.SetActive(true);
        Physics.SetActive(true);
        transform.position = m_currentSpawn;
        yield return new WaitForSeconds(1);
        m_IsRespawning = false;
        yield return null;
    }
}
