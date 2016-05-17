using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ManagerSpawn : MonoBehaviour {

    public static ManagerSpawn instance = null;

    public GameObject m_CurrentLevel;

    [SerializeField]
    List<GameObject> m_PlayersList = new List<GameObject>();


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

    public void SpawnChara()
    {
        if (m_NbPlayers > 1)
        {
            for (int i = 0; i < m_NbPlayers; i++)
            {
                Vector3 _spawnPos = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[i].transform.localPosition;
                GameObject _playerInst = (GameObject)Instantiate(m_PlayersList[i], _spawnPos, Quaternion.identity);
            }
        }
    }
}
