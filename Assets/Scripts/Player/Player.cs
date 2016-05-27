using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public int m_PlayerID;
    public Vector3 m_SpawnPoint;

    private GameObject m_FxInst;
    public GameObject m_PlayerVisual;
    public GameObject m_TargetMesh;
    public Text m_Score;
    public Text m_Multiplicator;

    [SerializeField]
    List<Material> m_PlayerMatList = new List<Material>();
    [SerializeField]
    List<GameObject> m_PlayerFxs= new List<GameObject>();
    [SerializeField]
    List<Material> m_TargetMaterial = new List<Material>();
    //[SerializeField]
    //List<Text> m_PlayerScoreList = new List<Text>();
    //[SerializeField]
    //List<Text> m_PlayerMultiplicatorList = new List<Text>();



    void Start()
    {
        m_SpawnPoint = transform.position;

        #region switch Material and FXs
        switch (m_PlayerID)
        {
            case 1:
                m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[0];
                m_TargetMesh.GetComponent<Renderer>().material = m_TargetMaterial[0];
                m_Score = GameObject.Find("ScoreP1").GetComponent<Text>();
                m_Multiplicator = GameObject.Find("MultiP1").GetComponent<Text>();
                transform.GetChild(1).gameObject.layer = 8;

                m_FxInst = (GameObject)Instantiate(m_PlayerFxs[0], transform.position, Quaternion.identity);
                m_FxInst.transform.parent = this.transform;

                m_FxInst.name = "PlayerID_1";

                break;
            case 2:
                m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[1];
                m_TargetMesh.GetComponent<Renderer>().material = m_TargetMaterial[1];
                m_Score = GameObject.Find("ScoreP2").GetComponent<Text>();
                m_Multiplicator = GameObject.Find("MultiP2").GetComponent<Text>();
                transform.GetChild(1).gameObject.layer = 9;

                m_FxInst = (GameObject)Instantiate(m_PlayerFxs[1], transform.position, Quaternion.identity);
                m_FxInst.transform.parent = this.transform;


                m_FxInst.name = "PlayerID_2";
                break;


            //case 3:
            //    m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[2];
            //    m_FxInst = (GameObject)Instantiate(m_PlayerFxs[2], transform.position, Quaternion.identity);
            //    m_TargetMesh.GetComponent<Renderer>().material = m_TargetMaterial[2];
            //    m_FxInst.transform.parent = this.transform;
            //    m_FxInst.name = "PlayerID_3";
            //    break;
            //case 4:
            //    m_PlayerVisual.GetComponent<Renderer>().material = m_PlayerMatList[3];
            //    m_FxInst = (GameObject)Instantiate(m_PlayerFxs[3], transform.position, Quaternion.identity);
            //    m_TargetMesh.GetComponent<Renderer>().material = m_TargetMaterial[3];
            //    m_FxInst.transform.parent = this.transform;
            //    m_FxInst.name = "PlayerID_4";
            //    break;
            default:
                break;
        }
        #endregion
    }

    void Update()
    {
        if (transform.position.z != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, 0 );
    }

}

