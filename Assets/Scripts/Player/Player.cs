using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public int m_PlayerID;
    public Vector3 m_SpawnPoint;

    private GameObject m_FxInst;
    public GameObject m_PlayerVisual;

    [SerializeField]
    List<Material> m_PlayerMatList = new List<Material>();
    [SerializeField]
    List<GameObject> m_PlayerFxs= new List<GameObject>();


    void Start()
    {
        m_SpawnPoint = transform.position;

        #region switch Material and FXs
        switch (m_PlayerID)
        {
            case 1:
                m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[0];
                m_FxInst = (GameObject)Instantiate(m_PlayerFxs[0], transform.position, Quaternion.identity);
                m_FxInst.transform.parent = this.transform;
                m_FxInst.name = "PlayerID_1";
                break;
            case 2:
                m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[1];
                m_FxInst = (GameObject)Instantiate(m_PlayerFxs[1], transform.position, Quaternion.identity);
                m_FxInst.transform.parent = this.transform;
                m_FxInst.name = "PlayerID_2";
                break;
            case 3:
                m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[2];
                m_FxInst = (GameObject)Instantiate(m_PlayerFxs[2], transform.position, Quaternion.identity);
                m_FxInst.transform.parent = this.transform;
                m_FxInst.name = "PlayerID_3";
                break;
            case 4:
                m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[3];
                m_FxInst = (GameObject)Instantiate(m_PlayerFxs[3], transform.position, Quaternion.identity);
                m_FxInst.transform.parent = this.transform;
                m_FxInst.name = "PlayerID_4";
                break;
            default:
                break;
        }
        #endregion
    }

    void Update()
    {
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0 );

        Debug.Log(m_PlayerID);
    }


}

