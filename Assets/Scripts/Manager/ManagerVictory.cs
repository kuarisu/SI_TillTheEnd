using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ManagerVictory : MonoBehaviour {

    public static ManagerVictory instance = null;

    public float m_Timer; //en seconde 
    public int m_ScoreP1;
    public int m_ScoreP2;
    public int m_ScoreMax;
    private Coroutine VictoryChecking;
    private bool CanRestart;

    public GameObject VictoryMonk1;
    public GameObject VictoryMonk2;
    public GameObject VictoryDraw;
    public GameObject TimerManager;

    public GameObject VictoryFX;

    // Update is called once per frame

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

    }

    void Start()
    {
        CanRestart = false;
        VictoryChecking = StartCoroutine(VictoryCheck());
	}

    void Update()
    {
        if (CanRestart == true)
        {
            if(Input.GetButtonDown("B_1") || Input.GetButtonDown("B_2"))
            {
                SceneManager.LoadScene("SelectionScene");
                TimerManager.SetActive(false);
                VictoryMonk1.SetActive(false);
                VictoryMonk2.SetActive(false);
                VictoryDraw.SetActive(false);
                VictoryFX.SetActive(false);
            }
        }
    }

    IEnumerator VictoryCheck()
    {
        while (true)
        {
            if (m_Timer <= 0)
            {
                VictoryByTime();
                StopCoroutine(VictoryChecking);
                yield return null;
            }

            if (m_ScoreP1 >= m_ScoreMax)
            {
                StartCoroutine(VictoryPlayerOne());
                StopCoroutine(VictoryChecking);
                yield return null;
            }

            if (m_ScoreP2 >= m_ScoreMax)
            {

                StartCoroutine(VictoryPlayerTwo());
                StopCoroutine(VictoryChecking);
                yield return null;
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void VictoryByTime()
    {
        //On compare les deux score et cleui qui a le plus haut gagne.
        //comment je vais comparer...
        if (m_ScoreP1 > m_ScoreP2)
        {
            StartCoroutine(VictoryPlayerOne()); 
        }
        if (m_ScoreP2 > m_ScoreP1)
        {
            StartCoroutine(VictoryPlayerTwo());
        }

        if(m_ScoreP2 == m_ScoreP1)
        {
            StartCoroutine(Draw()); 
        }

    }

    IEnumerator VictoryPlayerOne()
    {
        VictoryFX.SetActive(true);
        CameraShakeEnd.instance.ScreenShakeStart();
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1.5f);
        CanRestart = true;
        VictoryMonk1.SetActive(true);
        //Reload scene de selection des perso
        yield return null;
    }

    IEnumerator VictoryPlayerTwo()
    {

        VictoryFX.SetActive(true);
        CameraShakeEnd.instance.ScreenShakeStart();
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1.5f);
        CanRestart = true;
        VictoryMonk2.SetActive(true);
        //Reload scene de selection des perso
        yield return null;
    }

    IEnumerator Draw()
    {
        VictoryFX.SetActive(true);
        CameraShakeEnd.instance.ScreenShakeStart();
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(1.5f);
        CanRestart = true;
        VictoryDraw.SetActive(true);
        //Reload scene de selection des perso
        yield return null;
    }
}
