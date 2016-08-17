using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameControl : MonoBehaviour 
{
	public RectTransform WallPrefab;
	public RectTransform GridPrefab;
	public RectTransform BoarderPrefab;
	public RectTransform Board;
	// Use this for initialization
	private RectTransform[] HorizontalWall;
	private RectTransform[] VerticalWall;

	float screenSize;
	float wallWidth;
	float gridLength;
	float boardSize;
	float gridWidth = 1;
	void Start ()
	{
		RectTransform rect;

		screenSize = Screen.height;
		wallWidth = screenSize * 8 / 640;
		boardSize = screenSize - wallWidth*2;
		gridLength = boardSize / 16;
		Board.sizeDelta = new Vector2(boardSize,boardSize);

		rect = (RectTransform)Instantiate (BoarderPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (-wallWidth, wallWidth, 0);
		rect.sizeDelta = new Vector2 (wallWidth,screenSize);

		rect = (RectTransform)Instantiate (BoarderPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (-wallWidth, wallWidth, 0);
		rect.sizeDelta = new Vector2 (screenSize,wallWidth);

		rect = (RectTransform)Instantiate (BoarderPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (boardSize, wallWidth, 0);
		rect.sizeDelta = new Vector2 (wallWidth,screenSize);

		rect = (RectTransform)Instantiate (BoarderPrefab, Vector3.zero, Quaternion.identity, Board);
		rect.anchoredPosition = new Vector3 (-wallWidth, -boardSize, 0);
		rect.sizeDelta = new Vector2 (screenSize,wallWidth);


		for(int i=0;i<17;i++)
		{
			rect = (RectTransform)Instantiate (GridPrefab, new Vector3 (0, 0, 0), Quaternion.AngleAxis(90,Vector3.forward), Board);
			rect.anchoredPosition = new Vector3 (boardSize/2, -gridLength*i, 0);
			rect.sizeDelta = new Vector2 (gridWidth,boardSize);
			rect = (RectTransform)Instantiate (GridPrefab, new Vector3 (0, 0, 0), Quaternion.AngleAxis(90,Vector3.forward), Board);
			rect.anchoredPosition = new Vector3 (gridLength*i,-boardSize/2, 0);
			rect.sizeDelta = new Vector2 (boardSize,gridWidth);
		}
			

		HorizontalWall = new RectTransform[21];
		VerticalWall = new RectTransform[21];
		for (int i = 0; i < 21; i++) 
		{
			HorizontalWall[i] = (RectTransform)Instantiate (WallPrefab, Vector3.zero, Quaternion.AngleAxis(90,Vector3.forward), Board);
			HorizontalWall[i].sizeDelta = new Vector2 (wallWidth,gridLength);
			HorizontalWall[i].anchoredPosition = new Vector3 (0, 0, 0);
			VerticalWall[i] = (RectTransform)Instantiate (WallPrefab, Vector3.zero, Quaternion.identity, Board);
			VerticalWall[i].sizeDelta = new Vector2 (wallWidth,gridLength);
			VerticalWall[i].anchoredPosition = new Vector3 (0, 0, 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
