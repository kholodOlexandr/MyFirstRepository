using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		// Make a background box
		int posX = Screen.width / 2 - 50;
		int posY = Screen.height / 2 - 40;
		GUI.Box(new Rect(posX + 0,posY + 0,100,90), "Menu");

		if(GUI.Button(new Rect(posX + 10,posY + 30,80,20), "Start Game")) {
			print ("sdsd");
			Application.LoadLevel(1);
		}
		if(GUI.Button(new Rect(posX + 10,posY + 60,80,20), "Exit Game")) {
			Application.Quit();
		}

	}
}
