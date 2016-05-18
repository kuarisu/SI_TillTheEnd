using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    bool m_IsMoving;
    private int m_PlayerID;
    private Vector3 m_currentSpawn;
    public bool m_IsRespawning;
    public GameObject Visual;
    public GameObject Physics;
    public GameObject m_PSDeath;

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
            Death();
        }
        if (col.collider.gameObject.tag == "BlockMove" && (col.collider.gameObject.GetComponent<BlockPushed>().IdBlock != m_PlayerID))
        {
           m_IsMoving =  col.collider.gameObject.GetComponent<BlockPushed>().m_IsMoving;
            if (m_IsMoving == true) 
            {
                Death();

                //A RETRAVAILLER PARCE QUE CA MARCHE PAS (pas deux collision en même temps)
                //if (col.collider.gameObject.tag == "Floor")
                //{
                //    DeathCrush();
                //}
            }

        }

    }

    void Death()
    {
        StartCoroutine(ReSpawn());
    }

    IEnumerator ReSpawn()
    {
        m_IsRespawning = true;
        m_PSDeath.SetActive(true);
        Visual.SetActive(false);
        Physics.SetActive(false);
        yield return new WaitForSeconds(1);
        m_PSDeath.SetActive(false);
        Visual.SetActive(true);
        Physics.SetActive(true);
        transform.position = m_currentSpawn;
        yield return new WaitForSeconds(1);
        m_IsRespawning = false;
        yield return null;
    }
}
