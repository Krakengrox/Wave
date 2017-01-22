using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class menuScript : MonoBehaviour {

	public GameObject startMenu;
	public GameObject credits;
	public GameObject gameOver;
	public GameObject confirmQuit;
	public GameObject level1;
	public GameObject squirrel;
	public GameObject GGJ;
	private float counterStart;
	private float GGJLenght = 100f;
	private bool boolStartingGGJ;
	private bool boolStartingSquirrel;


	// Use this for initialization
	void Start () {

		GGJ.SetActive (true);
		squirrel.SetActive (false);
		startMenu.SetActive (true);
		credits.SetActive (false);
		gameOver.SetActive (false);
		confirmQuit.SetActive (false);
		level1.SetActive (false);

		boolStartingGGJ = true;
		boolStartingSquirrel = false;


	}

	public void StartGame () {
		startMenu.SetActive (false);
		level1.SetActive (true);
		Time.timeScale = 0;
	}

	public void Credits () {
		credits.SetActive (true);
		startMenu.SetActive (false);
	}

	public void GameOver () {
		gameOver.SetActive (true);
	}

	public void ConfirmQuit () {
		confirmQuit.SetActive (true);
	}

	public void yesExit () {
		Application.Quit();
	}

	public void noExit () {
		confirmQuit.SetActive (false);
	}

	public void backToStart(){
		startMenu.SetActive (true);
		credits.SetActive (false);
		gameOver.SetActive (false);
		confirmQuit.SetActive (false);
		level1.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
        //fade();
	}

    void fade()
    {
		counterStart = counterStart + Time.time;
		if (counterStart >= GGJLenght && boolStartingGGJ) {
			GGJ.SetActive (false);
			squirrel.SetActive (true);
			boolStartingGGJ = false;
			boolStartingSquirrel = true;
		}
		if (counterStart >= GGJLenght*2 && boolStartingSquirrel) {
			squirrel.SetActive (false);
			boolStartingSquirrel = false;
		}
    }
}
