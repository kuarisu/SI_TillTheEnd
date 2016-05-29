using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerSelection : MonoBehaviour {
    
    public Image Pl_One;
    public Image Pl_Two;
    public Image B_P1;
    public Image B_P2;
    //public Image Pl_Three;
    //public Image Pl_Four;
    public Sprite Ready;
    public Sprite PressA;

    public bool m_Slectionning = true;
    bool m_CanAdd_1 = true;
    bool m_CanAdd_2 = true;
    bool m_CanAdd_3 = true;
    bool m_CanAdd_4 = true;

    void Update()
    {

        //Select and deselect player 1
        if (m_Slectionning == true && m_CanAdd_1 == true && Input.GetButtonDown("A_1") )
        {
            ManagerSpawn.instance.m_NbPlayers++;
            m_CanAdd_1 = false;
            Pl_One.enabled = false;
            B_P1.sprite = Ready;
        }
        else if (m_Slectionning == true && m_CanAdd_1 == false && Input.GetButtonDown("A_1"))
        {
            ManagerSpawn.instance.m_NbPlayers--;
            m_CanAdd_1 = true;
            Pl_One.enabled = true;
            B_P1.sprite = PressA;
        }

        //Select and deselect player 2
        if (m_Slectionning == true && Input.GetButtonDown("A_2") && m_CanAdd_2 == true)
        {
            ManagerSpawn.instance.m_NbPlayers++; ;
            m_CanAdd_2 = false;
            Pl_Two.enabled = false;
            B_P2.sprite = Ready;
        }
        else if (m_Slectionning == true && Input.GetButtonDown("A_2") && m_CanAdd_2 == false)
        {
            ManagerSpawn.instance.m_NbPlayers--;
            m_CanAdd_2 = true;
            Pl_Two.enabled = true;
            B_P2.sprite = PressA;
        }

        if (m_Slectionning == true && (Input.GetButtonDown("B_1") || Input.GetButtonDown("B_2")))
        {
            SceneManager.LoadScene("SelectionScene");
        }

        if (Input.GetButtonDown("Start_1") || Input.GetButtonDown("Start_2") && ManagerSpawn.instance.m_NbPlayers > 1)
        {
            SceneManager.LoadScene("GameScene");
        }
    }


    //public Image Pl_One;
    //public Image Pl_Two;
    //public Image Pl_Three;
    //public Image Pl_Four;

    //public bool m_Slectionning = true;
    //bool m_CanAdd_1 = true;
    //bool m_CanAdd_2 = true;
    //bool m_CanAdd_3 = true;
    //bool m_CanAdd_4 = true;

    //void Update()
    //{
    //    //Select and deselect player 1
    //    if (m_Slectionning == true && Input.GetButtonDown("A_1") && m_CanAdd_1 == true)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers++;
    //        m_CanAdd_1 = false;
    //        Pl_One.enabled = true;
    //    }
    //    if (m_Slectionning == true && Input.GetButtonDown("B_1") && m_CanAdd_1 == false)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers--;
    //        m_CanAdd_1 = true;
    //        Pl_One.enabled = false;
    //    }

    //    //Select and deselect player 2
    //    if (m_Slectionning == true && Input.GetButtonDown("A_2") && m_CanAdd_2 == true)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers++; ;
    //        m_CanAdd_2 = false;
    //        Pl_Two.enabled = true;
    //    }
    //    if (m_Slectionning == true && Input.GetButtonDown("B_2") && m_CanAdd_2 == false)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers--;
    //        m_CanAdd_2 = true;
    //        Pl_Two.enabled = false;
    //    }

    //    //Select and deselect player 3
    //    if (m_Slectionning == true && Input.GetButtonDown("A_3") && m_CanAdd_3 == true)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers++;
    //        m_CanAdd_3 = false;
    //        Pl_Three.enabled = true;
    //    }
    //    if (m_Slectionning == true && Input.GetButtonDown("B_3") && m_CanAdd_3 == false)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers--;
    //        m_CanAdd_3 = true;
    //        Pl_Three.enabled = false;


    //    }

    //    //Select and deselect player 3
    //    if (m_Slectionning == true && Input.GetButtonDown("A_4") && m_CanAdd_4 == true)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers++;
    //        m_CanAdd_4 = false;
    //        Pl_Four.enabled = true;

    //    }
    //    if (m_Slectionning == true && Input.GetButtonDown("B_4") && m_CanAdd_4 == false)
    //    {
    //        ManagerSpawn.instance.m_NbPlayers--;
    //        m_CanAdd_4 = true;
    //        Pl_Four.enabled = false;

    //    }

    //    if (Input.GetButtonDown("Start_1") && ManagerSpawn.instance.m_NbPlayers > 1)
    //    {
    //        SceneManager.LoadScene("GameScene");
    //    }
    //}

}
