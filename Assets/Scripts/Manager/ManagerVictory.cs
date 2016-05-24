using UnityEngine;
using System.Collections;

public class ManagerVictory : MonoBehaviour {

    public float m_Timer; //en seconde 
    public int m_ScoreP1;
    public int m_ScoreP2;
    public int m_ScoreMax;

	// Update is called once per frame
	void Update () {
	
        if(m_Timer == 0)
        {
            VictoryByTime();
        }

        if (m_ScoreP1 == m_ScoreMax)
        {
            VictoryPlayerOne();
        }

        if (m_ScoreP2 == m_ScoreMax)
        {
            VictoryPlayerTwo();
        }


	}

    void VictoryByTime()
    {
        //On compare les deux score et cleui qui a le plus haut gagne.
        //comment je vais comparer...
        if (m_ScoreP1 > m_ScoreP2)
        {
            VictoryPlayerOne();
        }
        if (m_ScoreP2 > m_ScoreP1)
        {
            VictoryPlayerTwo();
        }

    }

    void VictoryPlayerOne()
    {
        Debug.Log("Player One WINS");
    }

    void VictoryPlayerTwo()
    {
        Debug.Log("Player two WINS");
    }
}
