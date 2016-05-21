using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArenaSpawner : MonoBehaviour {

	public List<GameObject> m_ListSpawner = new List<GameObject>();
    public GameObject m_SpawnerBell;
    public GameObject m_CenterLevel;
    public GameObject m_Bell;
    public float m_SpawnTimer = 3;


    void Start()
    {
        StartCoroutine(SpawnBell());
    }

    IEnumerator SpawnBell()
    {
        yield return new WaitForSeconds(m_SpawnTimer);
        GameObject _instBell = (GameObject)Instantiate(m_Bell, m_SpawnerBell.transform.position, Quaternion.identity);
        SoundManagerEvent.emit(SoundManagerType.Bell);
        yield return null;

    }
}
