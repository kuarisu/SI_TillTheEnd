using UnityEngine;
using System.Collections;

public class ManagerSpawn : MonoBehaviour {

    public static ManagerSpawn instance = null;

    public GameObject m_CurrentLevel;

    public GameObject m_Player;


    public int m_NbPlayers; //En fonction nb dans list quand start alors m_Nbplayer change ce qui change list scène


    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);


    }

    void Start()
    {
        StartCoroutine("LaunchDelay");
    }

    IEnumerator LaunchDelay()
    {
        yield return new WaitForEndOfFrame();
        SoundManagerEvent.emit(SoundManagerType.MainMusic);
    }

    public void SpawnChara()
    {
        if (m_NbPlayers > 1)
        {
            for (int i = 0; i < m_NbPlayers; i++)
            {
                Vector3 _spawnPos = m_CurrentLevel.GetComponent<ArenaSpawner>().m_ListSpawner[i].transform.localPosition;
                GameObject _playerInst = (GameObject)Instantiate(m_Player, _spawnPos, Quaternion.identity);
                _playerInst.gameObject.name = "Player" + (i+1);
                _playerInst.GetComponent<Player>().m_PlayerID = i + 1;
            }

            m_NbPlayers = 0;
        }


    }
}
