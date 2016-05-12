﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour {

	public GameObject Selection;
	public GameObject CreditImage;
	public bool Startable = false;
	private int Level;

	public void SelectionScreen() {

		Selection.SetActive (true);
		Startable = true;
	}

	public void ShowImage() {

		CreditImage.SetActive (true);
	}

	public void Update() {

		if(Input.GetButton("B_1")) {
			CreditImage.SetActive (false);
		}

		if(Startable == true){
			if (Input.GetButton ("Start_1")) {
				Debug.Log ("Chat marche vraiment");
				SceneManager.LoadScene (Level);
			}
		}
	}

	public void Sortir (){

		if (Input.GetButton ("A_1")) {
			Debug.Log ("Chat marche");
			Application.Quit ();
		}
	}

	public void Demarrage (int Level){
		
		this.Level = Level;

	}
}