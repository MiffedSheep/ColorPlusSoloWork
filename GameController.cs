using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int GridWidth = 8;
	public int GridHeight = 5;
	public int turnCount, colorCode, randomInt, randomInt2,lastX,lastY,score,score1,score2;
	public bool onePerTurnBool;
	public float turnTimer, gameTimer;
	public string colorString;
	public GameObject[,] cubes;
	public GameObject aCube;
	public GameObject Spotlight;
	public GameObject[,] SpotLightArray;
	public GameObject[] nextCube;
	public KeyCode[] KeyCodeArray;
	public Color[] colorArray;
	private CubeBehavior cubeBehavior;
	// Use this for initialization
	void Start () {
		//8x5 grid of cubes
		//Next Cube Code
		colorCode = (Random.Range (1, 5));
		colorArray = new Color[4];
		cubes = new GameObject[GridWidth,GridHeight];
		SpotLightArray  = new GameObject [GridWidth, GridHeight];
		nextCube = new GameObject[1];
		nextCube [0] = (GameObject)Instantiate (aCube, new Vector3 (-7.022398f, 2.852758f, 10), Quaternion.identity);
		nextCube[0].GetComponent <CubeBehavior>().Colored=true;
		for(int x =0; x<GridWidth; x++){
			for(int y=0; y<GridHeight; y++){
				cubes[x,y] = (GameObject) Instantiate (aCube, new Vector3(x * 2 - 14, y * 2 - 8, 10), Quaternion.identity);
				cubes[x,y].GetComponent<CubeBehavior>().x=x;
				cubes[x,y].GetComponent<CubeBehavior>().y=y;
				SpotLightArray[x,y] = (GameObject)Instantiate (Spotlight, new Vector3 (x * 2 - 14, y * 2 - 8, -4), Quaternion.identity);
				SpotLightArray[x,y].light.enabled=false;
			}
		}
	
	}
	private bool CheckForPlus (int x, int y) {
				if(cubes[x+1,y].GetComponent<CubeBehavior>().Active &&
				  cubes[x-1,y].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y+1].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y-1].GetComponent<CubeBehavior>().Active &&
				  cubes[x,y].GetComponent<CubeBehavior>().Active)
				{ 
					cubes[x,y].GetComponent<CubeBehavior>().Colored=false;
					cubes[x+1,y].GetComponent<CubeBehavior>().Colored=false;	
					cubes[x-1,y].GetComponent<CubeBehavior>().Colored=false;
					cubes[x,y+1].GetComponent<CubeBehavior>().Colored=false;
					cubes[x,y-1].GetComponent<CubeBehavior>().Colored=false;
					cubes[x,y].GetComponent<CubeBehavior>().Active=false;
					cubes[x+1,y].GetComponent<CubeBehavior>().Active=false;	
					cubes[x-1,y].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y+1].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y-1].GetComponent<CubeBehavior>().Active=false;
					cubes[x,y].GetComponent<CubeBehavior>().Gray=true;
					cubes[x+1,y].GetComponent<CubeBehavior>().Gray=true;	
					cubes[x-1,y].GetComponent<CubeBehavior>().Gray=true;
					cubes[x,y+1].GetComponent<CubeBehavior>().Gray=true;
					cubes[x,y-1].GetComponent<CubeBehavior>().Gray=true;
					cubes[x+1,y].renderer.material.color=Color.gray;
					cubes[x-1,y].renderer.material.color=Color.gray;
					cubes[x,y+1].renderer.material.color=Color.gray;
					cubes[x,y-1].renderer.material.color=Color.gray;
					cubes[x,y].renderer.material.color=Color.gray;
					
				}
		return true;
	}

	private void CheckScore(){
		
		// Check every cube in the grid
		for(int x = 1; x<8-1; x++){
			for(int y = 1; y<5-1;y++){
				CheckForPlus (x,y);
				if ( CheckForPlus(x, y) == true) {
					score+=5;	
					
				}
				/*else if ( (CheckForPlus(x, y) == true) && score1 ) {
					score+=5;
					
				}
				else if ( (CheckForPlus(x, y) == true) && score2 ) {
					score+=10;
				
				}*/
				 
			}
		}
	}
	// Update is called once per frame
	void Update () {
		CheckScore();
		
	
		turnTimer += Time.deltaTime;
		gameTimer += Time.deltaTime;
		if (gameTimer >= 60f) {
			//Switch to Score Script	
		}
		if (turnTimer >= 2f) {
			turnCount += 1;
			colorCode = (Random.Range (1, 5));
		
			if (colorCode == 1) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.black;
				nextCube [0].tag = "Black";
				colorString = "Black";
			} else if (colorCode == 2) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.blue;
				nextCube [0].tag = "Blue";
				colorString = "Blue";
			} else if (colorCode == 3) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.green;
				nextCube [0].tag = "Green";
				colorString = "Green";
			} else if (colorCode == 4) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.red;
				nextCube [0].tag = "Red";
				colorString = "Red";
			} else if (colorCode == 5) {
				nextCube [0].renderer.enabled = true;
				nextCube [0].renderer.material.color = Color.yellow;
				nextCube [0].tag = "Yellow";
				colorString = "Yellow";
				
			}
			/*if(a player hasn't pressed a key){
		  activeCubes[(Random.Range(0, numberOfActiveCubes)].boomBool=false;
		}		
		*/
			onePerTurnBool = false;
			turnTimer = 0;		
	}
	
	if(Input.GetKeyDown (KeyCode.Keypad1) && onePerTurnBool==false){
			
			
			nextCube [0].renderer.enabled = false;
			onePerTurnBool =true;			
			randomInt = Random.Range (0, 8);
			randomInt2 = Random.Range (0, 8);
			
			if (colorString == "Black") {
				colorArray[0]= Color.black;
			}
			else if (colorString == "Blue") {
				colorArray[0]= Color.blue;
			}
			
			else if (colorString == "Green") {
				colorArray[0]= Color.green;
			}
			
			else if (colorString == "Yellow") {
				colorArray[0]= Color.yellow;
				
			}
			else if (colorString == "Red") {
				colorArray[0]= Color.red;
				
			}
			if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 0].renderer.material.color = colorArray[0];
					cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt, 0].GetComponent<CubeBehavior> ().Colored = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 0].renderer.material.color = colorArray[0];
					cubes [randomInt2, 0].GetComponent<CubeBehavior> ().Colored = true;
					cubes [randomInt2, 0].GetComponent<CubeBehavior> ().Active = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
		}
	else if(Input.GetKeyDown (KeyCode.Keypad2) && onePerTurnBool==false){
			nextCube [0].renderer.enabled = false;
			onePerTurnBool =true;
			randomInt = Random.Range (0, 8);
			randomInt2 = Random.Range (0, 8);
			
			if (colorString == "Black") {
				colorArray[0]= Color.black;
			}
			else if (colorString == "Blue") {
				colorArray[0]= Color.blue;
			}
			
			else if (colorString == "Green") {
				colorArray[0]= Color.green;
			}
			
			else if (colorString == "Yellow") {
				colorArray[0]= Color.yellow;
				
			}
			else if (colorString == "Red") {
				colorArray[0]= Color.red;
				
			}
			if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 1].renderer.material.color = colorArray[0];
					cubes [randomInt, 1].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt, 1].GetComponent<CubeBehavior> ().Colored = true;
					
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 1].renderer.material.color = colorArray[0];
					cubes [randomInt2, 1].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt2, 1].GetComponent<CubeBehavior> ().Colored = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
		}
		
	
	else if(Input.GetKeyDown (KeyCode.Keypad3) && onePerTurnBool==false){
			nextCube [0].renderer.enabled = false;
			onePerTurnBool =true;
			randomInt = Random.Range (0, 8);
			randomInt2 = Random.Range (0, 8);
			
			if (colorString == "Black") {
				colorArray[0]= Color.black;
			}
			else if (colorString == "Blue") {
				colorArray[0]= Color.blue;
			}
			
			else if (colorString == "Green") {
				colorArray[0]= Color.green;
			}
			
			else if (colorString == "Yellow") {
				colorArray[0]= Color.yellow;
				
			}
			else if (colorString == "Red") {
				colorArray[0]= Color.red;
				
			}
			if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 2].renderer.material.color = colorArray[0];
					cubes [randomInt, 2].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt, 2].GetComponent<CubeBehavior> ().Colored = true;					
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 2].renderer.material.color = colorArray[0];
					cubes [randomInt2, 2].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt2, 2].GetComponent<CubeBehavior> ().Colored = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
		}
	else if(Input.GetKeyDown (KeyCode.Keypad4) && onePerTurnBool==false){
			nextCube [0].renderer.enabled = false;
			onePerTurnBool =true;
			randomInt = Random.Range (0, 8);
			randomInt2 = Random.Range (0, 8);
			
			if (colorString == "Black") {
				colorArray[0]= Color.black;
			}
			else if (colorString == "Blue") {
				colorArray[0]= Color.blue;
			}
			
			else if (colorString == "Green") {
				colorArray[0]= Color.green;
			}
			
			else if (colorString == "Yellow") {
				colorArray[0]= Color.yellow;
				
			}
			else if (colorString == "Red") {
				colorArray[0]= Color.red;
				
			}
			if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 3].renderer.material.color = colorArray[0];
					cubes [randomInt, 3].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt, 3].GetComponent<CubeBehavior> ().Colored = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 3].renderer.material.color = colorArray[0];
					cubes [randomInt2, 3].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt2, 3].GetComponent<CubeBehavior> ().Colored = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
		}
	else if(Input.GetKeyDown (KeyCode.Keypad5) && onePerTurnBool==false){
			nextCube [0].renderer.enabled = false;
			onePerTurnBool =true;
			randomInt = Random.Range (0, 8);
			randomInt2 = Random.Range (0, 8);
			
			if (colorString == "Black") {
				colorArray[0]= Color.black;
			}
			else if (colorString == "Blue") {
				colorArray[0]= Color.blue;
			}
			
			else if (colorString == "Green") {
				colorArray[0]= Color.green;
			}
			
			else if (colorString == "Yellow") {
				colorArray[0]= Color.yellow;
				
			}
			else if (colorString == "Red") {
				colorArray[0]= Color.red;
				
			}
			if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == false) {
					cubes [randomInt, 4].renderer.material.color = colorArray[0];
					cubes [randomInt, 4].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt, 4].GetComponent<CubeBehavior> ().Colored = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				} else if (cubes [randomInt, 0].GetComponent<CubeBehavior> ().Active == true) {
					cubes [randomInt2, 4].renderer.material.color = colorArray[0];
					cubes [randomInt2, 4].GetComponent<CubeBehavior> ().Active = true;
					cubes [randomInt2, 4].GetComponent<CubeBehavior> ().Colored = true;
					nextCube [0].renderer.enabled = false;
					nextCube [0].GetComponent<CubeBehavior> ().boomBool = true;
				}
		}
			
			
		//When you hit a key, spawn a colored cube in the row of the key pushed in a random location 
		//(but only if there is an available White cube)
	}
	
}
