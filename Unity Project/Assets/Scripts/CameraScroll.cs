using UnityEngine;
using System.Collections;

public class CameraScroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.up * PlayerTriangle.fl_scrollSpeed);

	}
}
