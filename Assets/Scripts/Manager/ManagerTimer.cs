using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManagerTimer : MonoBehaviour {


    [HideInInspector]
    public float m_TimeMax;
    private float m_passedTime;

    public Text message;

    /*** pour le formatage ****/
    private float minutes;
    private float seconds;

    void Start()
    {
        m_TimeMax = ManagerSpawn.instance.GetComponent<ManagerVictory>().m_Timer;
    }

    void Update()
    {
        //le temps écoulé = TimerMax - temps actuel
        m_passedTime = m_TimeMax - Time.time;

        //formatage
        minutes = m_passedTime / 60;
        seconds = m_passedTime % 60;

        message.text = "Temps écoulé : " + string.Format("{0:00}:{1:00}", minutes, seconds);

        if (m_passedTime == 0)
        {
            ManagerSpawn.instance.GetComponent<ManagerVictory>().m_Timer = m_passedTime;
        }

    }
}
