using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCatchBell : MonoBehaviour {

    public GameObject m_PSBellCaught;

    void Start()
    {
        m_PSBellCaught.GetComponent<BellStockSP>().m_SPCaughtBell.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Bell")
        {
            //m_PSBellCaught.GetComponent<BellStockSP>().m_SPCaughtBell.gameObject.SetActive(true);
            SoundManagerEvent.emit(SoundManagerType.BellCaught);
            //Debug.Log(col.transform.parent.transform.parent.GetChild(0).name);
            col.gameObject.transform.parent.transform.parent.GetChild(1).GetComponent<PathCloche>().StartRespawn();
            StartCoroutine(Catched());
        }
    }

    IEnumerator Catched()
    {
        GetComponent<PlayerScoring>().CatchedBell();
        yield return null;
    }
}
