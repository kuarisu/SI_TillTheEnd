using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

    bool m_IsMoving;
    Vector3 m_Spawn;
    private int m_PlayerID;
    private Vector3 m_currentSpawn;
    public bool m_IsRespawning;
    public GameObject Visual;
    public GameObject Physics;

    void Start()
    {
        m_PlayerID = GetComponent<Player>().m_PlayerID;

        if (m_PlayerID == 1)
            m_currentSpawn = ManagerSpawn.instance.m_SpawnPl1;

        if (m_PlayerID == 2)
            m_currentSpawn = ManagerSpawn.instance.m_SpawnPl2;

        if (m_PlayerID == 3)
            m_currentSpawn = ManagerSpawn.instance.m_SpawnPl3;

        if (m_PlayerID == 4)
            m_currentSpawn = ManagerSpawn.instance.m_SpawnPl4;
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
