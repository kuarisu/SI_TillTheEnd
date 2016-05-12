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
        if (col.collider.gameObject.tag == "BlockMove")
        {
           m_IsMoving =  col.collider.gameObject.GetComponent<BlockPushed>().m_IsMoving;
            //Debug.Log(col.collider.gameObject.GetComponent<BlockPushed>().m_NbBounce);
            if (m_IsMoving == true) 
            {
                if (col.collider.gameObject.GetComponent<BlockPushed>().m_NbBounce == 0)
                {
                    DeathBlock();
                }
                //A RETRAVAILLER PARCE QUE CA MARCHE PAS (pas deux collision en même temps)
                if (col.collider.gameObject.tag == "Floor")
                {
                    DeathCrush();
                }
            }

        }

    }

    void DeathZone()
    {
        Debug.Log("Died by deathzone");
        ReSpawn();
    }

    void DeathBlock ()
    {
        Debug.Log("Died by deathBlock");
        ReSpawn();
    }

    void DeathCrush()
    {
        Debug.Log("Died by crushed");
        ReSpawn();

    }

    IEnumerator ReSpawn()
    {
        m_IsRespawning = true;

        yield return null;
    }
}
