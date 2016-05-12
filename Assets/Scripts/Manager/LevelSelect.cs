using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSelect : MonoBehaviour {

	public List<GameObject> m_Level1v1 = new List<GameObject>();
	public List<GameObject> m_Level1v1v1 = new List<GameObject>();
	public List<GameObject> m_Level1v1v1v1 = new List<GameObject>();
    public GameObject _CurrentLevel;



    void Start()
    {
        SpawnLevel();
    }



        void SpawnLevel()
    { 

		if (ManagerSpawn.instance.m_NbPlayers == 2) {

			_CurrentLevel = m_Level1v1 [Random.Range (0, m_Level1v1.Count)];
			Instantiate (_CurrentLevel, new Vector3(0 , 0, 0), Quaternion.identity);
			_CurrentLevel.transform.position = new Vector3 (0, 0, 0);

		}

		else if (ManagerSpawn.instance.m_NbPlayers == 3) {

			_CurrentLevel = m_Level1v1v1 [Random.Range (0, m_Level1v1.Count)];
			Instantiate (_CurrentLevel, new Vector3(0 , 0, 0), Quaternion.identity);

		}

		else if (ManagerSpawn.instance.m_NbPlayers == 4) {

			_CurrentLevel = m_Level1v1v1v1 [Random.Range (0, m_Level1v1.Count)];
			Instantiate (_CurrentLevel, new Vector3(0 , 0, 0), Quaternion.identity);

		}

        ManagerSpawn.instance.m_CurrentLevel = _CurrentLevel;
        ManagerSpawn.instance.SpawnChara();

    }


	//void Start () {
	
	

	//}
	
	// Update is called once per frame
	void Update () {
	
	

	}
}
