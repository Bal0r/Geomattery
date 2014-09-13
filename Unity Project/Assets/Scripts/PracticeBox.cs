using UnityEngine;
using System.Collections;

public class PracticeBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {
		
		//make a background for the button
		
		GUI.Box (new Rect(200, 10, 200, 350), "Geomattery");

		//make a button which can be clicked to return level select screen

		if (GUI.Button(new Rect(225, 40, 150, 50), "Start")) {
			Debug.Log ("Yay, it worked!");
			//Application.LoadLevel(LevelSelect01);

		}

	}
	

}
