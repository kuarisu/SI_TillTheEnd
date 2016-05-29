using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerTimer : MonoBehaviour {


    [HideInInspector]
    public float m_TimeMax;
    public float m_passedTime;

    public Text message;

    /*** pour le formatage ****/
    private float minutes;
    private float seconds;
    private bool CanStart = false;

    void Start()
    {
        m_TimeMax = transform.parent.GetComponent<ManagerVictory>().m_Timer;
        CanStart = true;
    }

    void Update()
    {
        if (CanStart)
        {
            if (m_passedTime >= 0)
            {
                //le temps écoulé = TimerMax - temps actuel
                m_passedTime = m_TimeMax - Time.timeSinceLevelLoad;

                //formatage
                minutes = m_passedTime / 60;
                seconds = m_passedTime % 60;

                message.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else if (m_passedTime < 0)
            {
                transform.parent.GetComponent<ManagerVictory>().m_Timer = 0;
            }
        }
    }
}
