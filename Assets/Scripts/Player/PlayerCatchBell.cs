using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerCatchBell : MonoBehaviour {

    public GameObject gameManager;
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
            StartCoroutine(Catched());
        }
    }

    IEnumerator Catched()
    {
        GetComponent<PlayerScoring>().CatchedBell();
        //FAIRE RESPAWN LA CLOCHE (sur la cloche ?)
        yield return null;
    }
}
