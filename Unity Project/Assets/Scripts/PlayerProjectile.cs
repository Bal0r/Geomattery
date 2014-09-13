using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.up * (PlayerTriangle.fl_scrollSpeed + 1));

		if (Input.GetMouseButtonDown(0))
		{
			Object.Instantiate(this, PlayerTriangle.v3_playerPosition, PlayerTriangle.qt_playerRotation);
		}

		if (transform.position.y > 24.3f + (PlayerTriangle.fl_scrollSpeed * PlayerTriangle.int_frameCount))
		{
			Object.DestroyObject(this);
		}
						

	}
}
