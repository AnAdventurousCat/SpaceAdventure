using UnityEngine;
using System.Collections;


public class Seecubes : MonoBehaviour {

	// private Instruction Valores; 
	private Instruction Valores;
	GameObject Objeto;	
	public string colorName; 
	private ToogleOptions GameConfiguration;
	private GameObject GameConfigurationToogles;
	int cubeColor = 0;
	bool cubeIsActive=false;

	int nameLenght; 
	int cubeIndex;


	private GameObject ExcerciseManager;
	private InputOutputADS ADSystem;

	void Start (){

		nameLenght = gameObject.name.Length;
		cubeIndex =  int.Parse(gameObject.name[nameLenght - 1].ToString());

		Objeto = GameObject.Find ("Instructions");
		ExcerciseManager = GameObject.Find ("Exercisemanager");
		ADSystem = ExcerciseManager.GetComponent<InputOutputADS> ();
		gameObject.GetComponent<Collider> ().enabled = false;
		//Valores = Objeto.GetComponent<Instruction>();	
		Valores = Objeto.GetComponent<Instruction> (); 
		gameObject.GetComponent<Renderer> ().enabled = false;
		//gameObject.GetComponent<Renderer> ().material.color = Color.clear;
		gameObject.transform.localScale = new Vector3(1.4f,0.6f,1.4f);
	}
	
    void Update () 
	{
		if (GameObject.Find ("GameConfiguration") == true) 
		{
			GameConfigurationToogles = GameObject.Find ("GameConfiguration");
			GameConfiguration = GameConfigurationToogles.GetComponent<ToogleOptions>();

			if (GameConfiguration.ActiveAdaptiveDificulty == false) {
			
				ActiveCubesRS ();
			}
		} else if (GameObject.Find ("GameConfiguration") == false) 
			{
			ActiveCubesRS ();
			}
	}

	void ActiveCubesRS(){

		if (((Valores.pnr1 == cubeIndex || Valores.pnr2 == cubeIndex) && gameObject.tag == "Right")||((Valores.pnl1 == cubeIndex || Valores.pnl2 == cubeIndex) && gameObject.tag == "Left"))
		{
			gameObject.GetComponent<Renderer> ().enabled = true;
			gameObject.GetComponent<Collider> ().enabled = true;
		} else {
			gameObject.GetComponent<Collider> ().enabled = false;	
			gameObject.GetComponent<Renderer> ().enabled = false;
			//gameObject.GetComponent<Renderer> ().material.color = Color.clear;
		}

		if ((Valores.pnr1 == cubeIndex) && gameObject.tag == "Right"){
			Colorchange (Valores.colorname3);
			colorName = Valores.colorname3;
		}
		else if 
		((Valores.pnr2 == cubeIndex)  && gameObject.tag == "Right"){
			Colorchange (Valores.colorname4);
			colorName = Valores.colorname4;
		}
		else if 
		((Valores.pnl1 == cubeIndex)  && gameObject.tag == "Left"){
			Colorchange (Valores.colorname1);
			colorName = Valores.colorname1;
		}
		else if 
		((Valores.pnl2 == cubeIndex) && gameObject.tag == "Left"){
			Colorchange (Valores.colorname2);
			colorName = Valores.colorname2;
		}

//		GrowCube (colorName); // Only in Virtual Reality

	}

	void Colorchange(string color){
		
		if (color == "red") {
			gameObject.GetComponent<Renderer> ().material.color = Color.red;

		} else if (color == "yellow") {
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		
		} else if (color == "green") {
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
	}

	public void ActiveCubesAD(){
	DefineCubeColor ();
	if (gameObject.tag == "Right")
		{
			if (Valores.rightSideAD.Contains(gameObject.name[nameLenght - 1].ToString()))
			    {
				paintcube();
				gameObject.GetComponent<Collider> ().enabled = true;
				}
		}
	else if (gameObject.tag == "Left") 
			{
			if (Valores.leftSideAD.Contains(gameObject.name[nameLenght - 1].ToString()))
				{
				paintcube();
				gameObject.GetComponent<Collider> ().enabled = true;
				}
			}

	}

	public void DefineCubeColor(){

		if (ADSystem.numberofcolors == 1)
		{cubeColor = 1;}
		else if (ADSystem.numberofcolors == 2)
		{cubeColor = Random.Range(1,3);}
		else if (ADSystem.numberofcolors == 3)
		{
			cubeColor = Random.Range(1,4);}
		}

	void paintcube(){

		if (cubeColor == 1){
				gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
		else if (cubeColor == 2){
				gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			}
		else if (cubeColor == 3){
				gameObject.GetComponent<Renderer> ().material.color = Color.green;
				}

	}
}
//  Only in Virtual Reality
//	void GrowCube(string colorName){
//
//
//		try
//		{
//		
//			GameConfiguration = GameConfigurationToogles.GetComponent<ToogleOptions>();
//
//			if (GameConfiguration.ActiveHiddenStates == true)
//			{
//			 	if (colorName == "yellow") {
//				gameObject.transform.localScale = new Vector3(1.4f,3f,1.4f);
//				} 
//			 }
//		} catch (Exception e){}
//
//	}
//	void VisibleWeights(){
//		try
//			{
//				GameConfiguration = GameConfigurationToogles.GetComponent<ToogleOptions>();
//
//					if (GameConfiguration.ActiveHiddenStates == true)
//					{
//					 	if (colorName == "yellow") {
//						
//							
//						
//						} 
//					 }
//			} catch (Exception e){}
//		
//		}

//

		


