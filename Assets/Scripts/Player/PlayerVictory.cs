using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerVictory : MonoBehaviour {

    public GameObject gameManager;

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Bell")
        {
            StartCoroutine(Victory());
        }
    }

    IEnumerator Victory()
    {

        yield return new WaitForSeconds(2);
        SceneManager.LoadScene ("GameScene");
        Time.timeScale = 0;

    }
}
