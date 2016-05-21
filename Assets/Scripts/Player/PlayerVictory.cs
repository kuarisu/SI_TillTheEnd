using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerVictory : MonoBehaviour {

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
            StartCoroutine(Victory());
            Time.timeScale = 0.5f;
        }
    }

    IEnumerator Victory()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene ("GameScene");

    }
}
