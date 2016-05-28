using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour {

	public GameObject CreditImage;
	public bool Startable = false;
	private int Level;

	public void SelectionScreen() {

        SceneManager.LoadScene("SelectionCharaScene");
        //Startable = true;
    }

	public void ShowImage() {

		CreditImage.SetActive (true);
	}

    public void Update() {

        if (Input.GetButton("B_1")) {
            CreditImage.SetActive(false);
        }
    }

	public void Sortir (){

		if (Input.GetButton ("A_1")) {
			Application.Quit ();
		}
	}

	public void Demarrage (int Level){
		
		this.Level = Level;

	}
}
