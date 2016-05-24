using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScoring : MonoBehaviour {

    public int m_MaxScore = 500;
    public int m_BellPoints;
    public int m_DeathZonePoints;
    public int m_KillMultiplicator;
    [HideInInspector]
    public int m_ActualScore;
    private int m_ActualMultiplicator;
    private int m_PreviousScore = 0;
    private int m_PreviousMultiplicator = 1;

    private int m_PlayerID;

    private string m_UiScore;
    private string m_UiMultiplicator;

   

    void Start () {

        m_MaxScore = ManagerSpawn.instance.GetComponent<ManagerVictory>().m_ScoreMax;
        m_PlayerID = GetComponent<Player>().m_PlayerID;
        m_ActualMultiplicator = 1;
        m_ActualScore = 0;
    }
	
	void Update () {

        GetComponent<Player>().m_Score.text = "Player P" + m_PlayerID.ToString() + ": " + m_ActualScore.ToString();
        GetComponent<Player>().m_Multiplicator.text = "x" + m_ActualMultiplicator.ToString();
        Mathf.Clamp(m_ActualScore, 0, m_MaxScore);
        if (m_ActualScore == m_MaxScore)
        {
            if (m_PlayerID == 1)
                ManagerSpawn.instance.GetComponent<ManagerVictory>().m_ScoreP1 = m_ActualScore;

            if (m_PlayerID == 2)
                ManagerSpawn.instance.GetComponent<ManagerVictory>().m_ScoreP2 = m_ActualScore;
        }

        if (ManagerSpawn.instance.GetComponent<ManagerVictory>().m_Timer == 0)
        {
            if (m_PlayerID == 1)
                ManagerSpawn.instance.GetComponent<ManagerVictory>().m_ScoreP1 = m_ActualScore;

            if (m_PlayerID == 2)
                ManagerSpawn.instance.GetComponent<ManagerVictory>().m_ScoreP2 = m_ActualScore;
        }

        //if (m_PreviousScore != m_ActualScore)
        //{
        //    = m_UiScore;
        //}
        //if(m_PreviousMultiplicator != m_ActualMultiplicator)
        //{
        //     = m_UiMultiplicator;
        //}

        //m_PreviousScore = m_ActualScore;
	
	}

    public void Died()
    {
        if (m_ActualScore >= m_DeathZonePoints)
        {
            m_ActualScore -= m_DeathZonePoints;
        }

        if (m_ActualMultiplicator != 1)
        {
            m_ActualMultiplicator = 1;
        }


    }

    public void Killed ()
    {
        if (m_ActualMultiplicator >= 1)
        {
            m_ActualMultiplicator++;
        }
    }

    public void CatchedBell()
    {
        if(m_ActualScore >= 0)
        {
            m_ActualScore += m_BellPoints * m_ActualMultiplicator;
        }
    }

}
