using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour 
{
	public RectTransform WallPrefab;
	public RectTransform BoundaryPrefab;
	public Image BrickPrefab;
	public RectTransform Board;
	public RectTransform Background;
	public RectTransform Floor;
	public Button[] Robot;
	public Text step;
	// Use this for initialization
	private RectTransform[] HorizontalWall;
	private RectTransform[] VerticalWall;
	private Image[] Tiles;
	private int[] RobotState;
	float screenSize;
	float wallWidth;
	float gridLength;
	float boardSize;

	void Start ()
	{
		RectTransform rect;

		screenSize = Screen.height;
		//screenSize *= 0.95f;
		wallWidth = screenSize / 70;
		boardSize = screenSize- wallWidth*2;
		gridLength = boardSize / 16;

		Board.sizeDelta = new Vector2(boardSize,boardSize);
		Background.sizeDelta = new Vector2 (1.5f*Screen.width,1.5f*Screen.height);


		Floor.sizeDelta = new Vector2(boardSize,boardSize);
		Floor.GetComponent<GridLayoutGroup> ().cellSize = new Vector2 (gridLength,gridLength);
		Tiles = new Image[16*16];
		for (int i = 0; i < 16 * 16; i++)
			Tiles[i] = (Image)Instantiate (BrickPrefab, Vector3.zero, Quaternion.identity, Floor);


		rect = (RectTransform)Instantiate (BoundaryPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (-wallWidth, wallWidth, 0);
		rect.sizeDelta = new Vector2 (wallWidth,screenSize);

		rect = (RectTransform)Instantiate (BoundaryPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (-wallWidth, wallWidth, 0);
		rect.sizeDelta = new Vector2 (screenSize,wallWidth);

		rect = (RectTransform)Instantiate (BoundaryPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (boardSize, wallWidth, 0);
		rect.sizeDelta = new Vector2 (wallWidth,screenSize);

		rect = (RectTransform)Instantiate (BoundaryPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (-wallWidth, -boardSize, 0);
		rect.sizeDelta = new Vector2 (screenSize,wallWidth);
			

		HorizontalWall = new RectTransform[21];
		VerticalWall = new RectTransform[21];
		for (int i = 0; i < 21; i++) 
		{
			HorizontalWall[i] = (RectTransform)Instantiate (WallPrefab, Vector3.zero, Quaternion.AngleAxis(90,Vector3.forward), Board);
			HorizontalWall[i].sizeDelta = new Vector2 (wallWidth,gridLength);
			HorizontalWall[i].anchoredPosition = Vector3.zero; ////
			VerticalWall[i] = (RectTransform)Instantiate (WallPrefab, Vector3.zero, Quaternion.identity, Board);
			VerticalWall[i].sizeDelta = new Vector2 (wallWidth,gridLength);
			VerticalWall[i].anchoredPosition = Vector3.zero; ////
		}

		RobotState = new int[4];
		for (int i = 0; i < 4; i++)
		{
			Robot [i].GetComponent<RectTransform> ().sizeDelta = new Vector2 (gridLength, gridLength);
			Robot [i].GetComponent<RobotScript> ().SetControllerReference (this);
			RobotState[i] = 0;
		}
		Robot[0].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (5.5f*gridLength,-6.5f*gridLength);////
		Robot[1].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (12.5f*gridLength,-2.5f*gridLength);////
		Robot[2].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (8.5f*gridLength,-11.5f*gridLength);////
		Robot[3].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (3.5f*gridLength,-9.5f*gridLength);////

		step.fontSize = (int)((Screen.width-Screen.height)/8);
		step.GetComponent<RectTransform> ().sizeDelta = new Vector2 (step.fontSize*3,step.fontSize*3);
		step.GetComponent<RectTransform> ().anchoredPosition = new Vector2 ((Screen.width-Screen.height)/4,-screenSize*0.3819f);
		//step.text = Screen.width.ToString () + " " + Screen.height.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
