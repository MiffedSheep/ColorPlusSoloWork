using UnityEngine;
using System.Collections;

public class CubeBehavior : MonoBehaviour {
public bool Active, boomBool, Clicked, Gray, Colored,CubeIsClicked,Ridge;
public int x,y;
public GameController gameController;
public GameObject aCube;
public Color lastColor;
	// Use this for initialization
	void Start () {
	Active=false;
	Clicked=false;
	Gray=false;
	Ridge=false;
	gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
	lastColor = gameController.cubes[x,y].renderer.material.color;	
	}
	
	// Update is called once per frame
	void Update () {
		
	if(Colored==false && !Gray){	
			this.gameObject.renderer.material.color=Color.white;			
		}
	if(Clicked){
			gameController.SpotLightArray[x,y].light.enabled = true;
		}
	else if (Clicked == false){
			gameController.SpotLightArray[x,y].light.enabled = false;
			
		}
	
	/*if(Active=true){	
			
		}
	else if(Active=false){
		 this.gameObject.renderer.material.color = Color.gray;
		 Gray=true;
		}*/
	}
	
	
	void OnMouseDown(){
		gameController.IsCubeTrue(x,y);
		if ((Active == false && 
				Colored==false && tag=="NotRidge")	&& 
				(gameController.cubes[x+1,y+1].GetComponent<CubeBehavior>().Colored==true || 
				gameController.cubes[x+1,y-1].GetComponent<CubeBehavior>().Colored==true ||
				gameController.cubes[x-1,y+1].GetComponent<CubeBehavior>().Colored==true ||
				gameController.cubes[x-1,y-1].GetComponent<CubeBehavior>().Colored==true ||
				gameController.cubes[x+1,y].GetComponent<CubeBehavior>().Colored==true ||
				gameController.cubes[x-1,y].GetComponent<CubeBehavior>().Colored==true ||
				gameController.cubes[x,y+1].GetComponent<CubeBehavior>().Colored==true ||
				gameController.cubes[x,y-1].GetComponent<CubeBehavior>().Colored==true) && CubeIsClicked==true)
		{
			lastColor= gameController.cubes[gameController.lastX,gameController.lastY].renderer.material.color;
			gameController.cubes[gameController.lastX,gameController.lastY].renderer.material.color = Color.white;
			gameController.cubes[gameController.lastX,gameController.lastY].GetComponent<CubeBehavior>().Active=false;
			gameController.cubes[gameController.lastX,gameController.lastY].GetComponent<CubeBehavior>().Colored=false;
			gameController.cubes[gameController.lastX,gameController.lastY].GetComponent<CubeBehavior>().Clicked=false;
			gameController.SpotLightArray[gameController.lastX,gameController.lastY].light.enabled=false;
			gameController.cubes[x,y].renderer.material.color = lastColor;
			gameController.cubes[x,y].GetComponent<CubeBehavior>().Active=true;
			gameController.cubes[x,y].GetComponent<CubeBehavior>().Colored=true;
			gameController.cubes[x,y].GetComponent<CubeBehavior>().Clicked=true;
			gameController.SpotLightArray[x,y].light.enabled=true;
			gameController.lastX = x;
			gameController.lastY = y;
			
			//gameController.cubes[x,y] = gameController.cubes[gameController.lastX,gameController.lastY];
			//Swap the clicked cube states with the found cube, and store the new cube as the last clicked cube
			// lastX =x, lastY = y;
			
		
		}
		else if ((Active== true && 
			Colored==true) && Clicked ==false)
		{
			Clicked=true;
			gameController.lastX = x;
			gameController.lastY = y;
			lastColor = gameController.colorArray[0];
			//Store this as the last clicked cube
		}
		else if((Active== true && 
			Colored==true) 
			&& Clicked==true){
			Clicked = false;
			lastColor = gameController.colorArray[0];
		}
	}
}
