using UnityEngine;
using System.Collections;

public class PlayerTriangle : MonoBehaviour {
	
	public int int_subFrame = 1;
	public static int int_frameCount = 0;
	public static float fl_scrollSpeed = 0.5f;
	
	private int int_upCount = 4;
	private int int_downCount = 4;
	private int int_leftCount = 4;
	private int int_rightCount = 4;

	private int int_dashDelay = 2;

	private float fl_mouseSensitivity = 2.5f; //adjustible - sets mouse sensitivity for movement

	private float fl_mousePosx;
	private float fl_mousePosy;

	private float fl_newMousePosx;
	private float fl_newMousePosy;

	private float fl_mouseSpeedx;
	private float fl_mouseSpeedy;

	private float fl_counter = 1f;
	private float fl_inToBoundInterval = 0.1f;

	public static Vector3 v3_playerPosition;
	public static Quaternion qt_playerRotation;

	private Transform player;

	void Start () {
	
		player = transform;

		player.position = new Vector3 (0, -26, 0);

		//sets initial mouse position
		fl_newMousePosx += Input.GetAxis ("Mouse X") * fl_mouseSensitivity;
		fl_newMousePosy += Input.GetAxis ("Mouse Y") * fl_mouseSensitivity;
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetKeyDown("w")) //w key is pressed (on current frame)
			{
			int_upCount = 0; //initiates "up" dash animation
			int_dashDelay = 0;
			}


		if (Input.GetKeyDown("s")) //s key is pressed (on current frame)
		{
			int_downCount = 0; //initiates "down" dash animation
			int_dashDelay = 0;
		}

		if (Input.GetKeyDown("a")) //a key is pressed (on current frame)
		{
			int_leftCount = 0; //initiates "left" dash animation
			int_dashDelay = 0;
		}


		if (Input.GetKeyDown("d")) //d key is pressed (on current frame)
		{
			int_rightCount = 0; //initiates "right" dash animation
			int_dashDelay = 0;
		}


		if (int_dashDelay > 1)
		{
			//up animation will stop after 4 frames
			if (int_upCount < 4)
			{
				player.Translate(Vector3.up * 3);
				int_upCount++;
			}
	
			//down animation will stop after 4 frames
			if (int_downCount < 4)
			{
				player.Translate(Vector3.down * 3);
				int_downCount++;
			}
	
			//left animation will stop after 4 frames
			if (int_leftCount < 4)
			{
				player.Translate(Vector3.left * 3);
				int_leftCount++;
			}
		
			//right animation will stop after 4 frames
			if (int_rightCount < 4)
			{
				player.Translate(Vector3.right * 3);
				int_rightCount++;
			}
		}



		//moves to next frame of any dash direction





		//keeps track of frames past (for screen boundary adjustments and dash manouvers)
		int_frameCount++;
		int_dashDelay++;

		//moves the player along with the camera
		player.Translate(Vector3.up * fl_scrollSpeed);



		////////Reserved space for mouse movement script attempt


			fl_mousePosx = fl_newMousePosx;
			fl_mousePosy = fl_newMousePosy;

			fl_newMousePosx += Input.GetAxis ("Mouse X") * fl_mouseSensitivity;
			fl_newMousePosy += Input.GetAxis ("Mouse Y") * fl_mouseSensitivity;

		if (int_downCount >= 4 && int_upCount >= 4 && int_leftCount >= 4 && int_rightCount >= 4)
			{
			player.Translate (Vector3.up * (fl_newMousePosy - fl_mousePosy));
			player.Translate (Vector3.right * (fl_newMousePosx - fl_mousePosx));
			}


		for (fl_counter = transform.position.x; fl_counter < -50.2f; fl_counter += fl_inToBoundInterval)
			{
			player.Translate(Vector3.right * fl_inToBoundInterval);
			}

		for (fl_counter = transform.position.x; fl_counter > 49.1f; fl_counter -= fl_inToBoundInterval)
		{
			player.Translate(Vector3.left * fl_inToBoundInterval);
		}

		for (fl_counter = transform.position.y; fl_counter < -28f + (fl_scrollSpeed * int_frameCount); fl_counter += fl_inToBoundInterval)
		{
			player.Translate(Vector3.up * fl_inToBoundInterval);
		}

		for (fl_counter = transform.position.y; fl_counter > 26.3f + (fl_scrollSpeed * int_frameCount); fl_counter -= fl_inToBoundInterval)
		{
			player.Translate(Vector3.down * fl_inToBoundInterval);
		}

		v3_playerPosition = new Vector3 (player.position.x, player.position.y, 0);
		qt_playerRotation = new Quaternion (player.rotation.x, player.rotation.y, player.rotation.z, 0);
	}

	void Awake () {

		Application.targetFrameRate = 60;

	}
}
