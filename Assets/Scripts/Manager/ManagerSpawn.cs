using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ManagerSpawn : MonoBehaviour {

    public static ManagerSpawn instance = null;

    public List<GameObject> m_Characters = new List<GameObject>();
    public GameObject m_CurrentLevel;

    
    public int m_NbPlayers; //En fonction nb dans list quand start alors m_Nbplayer change ce qui change list scène

    public Vector3 m_SpawnPl1;
    public Vector3 m_SpawnPl2;
    public Vector3 m_SpawnPl3;
    public Vector3 m_SpawnPl4;
    //SELECTIONMANAGER SUR LA SCENE DE SELECTION QUI AJOUTE LES PREFAB DE PLAYER SU RLE GAMEMANAGER ET LUI IL LES GARDENT SU RLA SCENE DE JEU LAWL

    
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }


    void Update()
    {
        if (m_Characters[1] != null)
        {
            m_NbPlayers = 2;
        }
        if (m_Characters[2] != null)
        {
            m_NbPlayers = 3;
        }
        if (m_Characters[3] != null)
        {
            m_NbPlayers = 4;
        }
    }


    public void SpawnChara()
    {
        #region TwoPlayers
        if (m_NbPlayers == 2)
        {
            Instantiate((GameObject)m_Characters[0]);
            m_SpawnPl1 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[0].transform.localPosition;
            m_Characters[0].transform.position = m_SpawnPl1;

            Instantiate((GameObject)m_Characters[1]);
            m_SpawnPl2 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[1].transform.localPosition;
            m_Characters[1].transform.position = m_SpawnPl2;
        }
        #endregion

        #region ThreePlayers
        if (m_NbPlayers == 3)
        {
            Instantiate((GameObject)m_Characters[0]);
            m_SpawnPl1 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[0].transform.localPosition;
            m_Characters[0].transform.position = m_SpawnPl1;

            Instantiate((GameObject)m_Characters[1]);
            m_SpawnPl2 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[1].transform.localPosition;
            m_Characters[1].transform.position = m_SpawnPl2;

            Instantiate((GameObject)m_Characters[2]);
            m_SpawnPl3 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[2].transform.localPosition;
            m_Characters[2].transform.position = m_SpawnPl3;
        }
        #endregion

        #region FourPlayers
        if (m_NbPlayers == 4)
        {
            Instantiate((GameObject)m_Characters[0]);
            m_SpawnPl1 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[0].transform.localPosition;
            m_Characters[0].transform.position = m_SpawnPl1;

            Instantiate((GameObject)m_Characters[1]);
            m_SpawnPl2 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[1].transform.localPosition;
            m_Characters[1].transform.position = m_SpawnPl2;

            Instantiate((GameObject)m_Characters[2]);
            m_SpawnPl3 = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[2].transform.localPosition;
            m_Characters[2].transform.position = m_SpawnPl3;

            Instantiate((GameObject)m_Characters[3]);
            m_SpawnPl4 =  m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[3].transform.localPosition;
            m_Characters[3].transform.position = m_SpawnPl4;
        }
        #endregion
    }
}
