using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class Instruction : MonoBehaviour {

	public GameObject levelcomesfrom; // level comes from Excercise Manager
	private Gamemanager levelis;
	
	// Check if is AD or RS
	private ToogleOptions GameConfiguration;
	private GameObject GameConfigurationToogles;
	private GameObject ExcerciseManager;
	private InputOutputADS ADSystem;
	
	//AD variables
	public string rightSideAD;
	public string leftSideAD;
	public int numberofplaces;
	
	
	// number of the active cube (max. 2)
	public int pnl1;
	public int pnl2;
	public int pnr1;
	public int pnr2;
	
	// Define the color with random (pcolor) and assign the color of the active cubes depending in the value (colorname) (max. 2)
	
	public float pcolor1;
	public string colorname1; 
	public float pcolor2;
	public string colorname2; 
	public float pcolor3;
	public string colorname3; 
	public float pcolor4;
	public string colorname4; 
	
	public int LeftW1;
	public int LeftW2;
	public int RightW1;
	public int RightW2;
	
	// variables for the TextLog
	public int numberWeightsRed; 
	public int numberWeightsYellow; 
	public int numberWeightsGreen; 
	
	public int positionRedCube1; 
	public int positionRedCube2; 
	public int positionYellowCube1;
	public int positionYellowCube2;
	public int positionGreenCube1;
	public int positionGreenCube2;
	
	public int positionRedCube3; 
	public int positionRedCube4; 
	public int positionYellowCube3;
	public int positionYellowCube4;
	public int positionGreenCube3;
	public int positionGreenCube4;
	
	Text instruction;
	
	void Start () {
		levelis = levelcomesfrom.GetComponent<Gamemanager> (); //Declare level
		
		ADSystem = levelcomesfrom.GetComponent<InputOutputADS> (); //Declare ADS variables
		
		if (GameObject.Find("GameConfiguration") == null){// if the Game configuration is unactive run reactive system
			level1();
		}
		else {                                               // If game configuration is active...
			GameConfigurationToogles = GameObject.Find ("GameConfiguration");
			GameConfiguration = GameConfigurationToogles.GetComponent<ToogleOptions>();
			
			if (GameConfiguration.ActiveAdaptiveDificulty == false && GameConfiguration.ActiveAdaptiveLevels == false) //If ADS & ADSLevels are not active run reactive system
			{
				level1 (); 
			}
			
			else if(GameConfiguration.ActiveAdaptiveLevels == true){ // If ADLevels is active run Adaptive levels
				AdaptiveLevels();
			}
		}
		
		
		
	}
	
	public void SetInstructions (){
		
		
		if (GameObject.Find ("GameConfiguration") == true) {
			if (GameConfiguration.ActiveAdaptiveDificulty == true) {
				ADSystem.SendOutputADS ();
			} else if (GameConfiguration.ActiveAdaptiveLevels == true) {
				AdaptiveLevels ();
				
			} else {
				displayinstructions ();
			}
		} else {
			displayinstructions ();
		}
	}
	
	
	public void displayinstructions (){ // Run the instructions every time that you press "Next Excercise" button. 
		
		
		if (levelis.levelnumber == 1) {
			level1 ();	
		} else if (levelis.levelnumber == 2) {
			level2 ();
		} else if (levelis.levelnumber == 3) {
			level3 ();
		} else if (levelis.levelnumber == 4) {
			level4 ();
		} 
	}
	
	public void level1 (){
		
		// creates instructions for level 1: only two weights in the same position on either side but different color
		
		instruction = GetComponent <Text> ();
		
		numberWeightsRed = 0; 
		numberWeightsYellow = 0; 
		numberWeightsGreen = 0; 
		
		pnl1 = Random.Range (1, 7);
		pnl2 = 0;
		pnr1 = pnl1; 
		pnr2 = 0;
		pcolor1 = Random.Range (0, 6);
		pcolor2 = 0;
		pcolor3 = Random.Range (0, 6);
		pcolor4 = 0;
		
		positionRedCube1 = 0; 
		positionRedCube2 = 0;
		positionYellowCube1 = 0; 
		positionYellowCube2 = 0; 
		positionGreenCube1 = 0;
		positionGreenCube2 = 0;
		
		
		if (pcolor1 < 2) {
			colorname1 = "red";
			LeftW1 = 2;
			numberWeightsRed ++;
			positionRedCube1 = (pnl1*(-1)); 
			
		} else if (pcolor1 < 5) {
			colorname1 = "yellow";
			LeftW1 = 1;
			numberWeightsYellow ++; 
			positionYellowCube1 = (pnl1*(-1)); 
			
		} else {
			colorname1 = "green";
			LeftW1 = 3;
			numberWeightsGreen ++; 
			positionGreenCube1 = (pnl1*(-1)); 
			
		}
		
		if (pcolor3 < 2) {
			colorname3 = "red";
			RightW1 = 2;
			positionRedCube2 = pnr1; 
			numberWeightsRed ++;
			
		} else if (pcolor3 < 4) {
			colorname3 = "yellow";
			RightW1 = 1;
			
			if (positionYellowCube1 != 0){
				positionYellowCube2 = pnr1; }
			else {
				positionYellowCube1 = pnr1; 
			}
			
			numberWeightsYellow ++;
			
			
		} 
		else {
			colorname3 = "green";
			RightW1 = 3;
			numberWeightsGreen ++; 
			positionGreenCube1 = pnr1;  
			
			
		}
		
		if (colorname1 == "red" && colorname3== "red")
		{
			int color = Random.Range (0, 6);
			if (color < 3){ 
				colorname3 = "yellow";
				RightW1 = 1;
				numberWeightsRed --; 
				numberWeightsYellow ++;
				if (positionYellowCube1 != 0){
					positionYellowCube2 = pnr1;}
				else{positionYellowCube1 = pnr1;}
				positionRedCube2 = 0; 
			} 
			else {
				colorname3 = "green";
				RightW1 = 3;
				numberWeightsGreen ++; 
				numberWeightsRed --; 
				if (positionGreenCube1 != 0){
					positionGreenCube2 = pnr1;}
				else{positionGreenCube2 = pnr1;}
				positionRedCube2 = 0; 
			}
			
		}
		
		if (colorname1 == "green" && colorname3== "green")
		{
			int color = Random.Range (0, 6);
			if (color < 3){ 
				colorname3 = "yellow";
				RightW1 = 1;
				numberWeightsGreen --; 
				numberWeightsYellow ++;
				if (positionYellowCube1 != 0){
					positionYellowCube2 = pnr1;}
				else{positionYellowCube1 = pnr1;}
				positionGreenCube2 = 0; 
			} 
			else {
				colorname3 = "red";
				RightW1 = 2;
				numberWeightsGreen --; 
				numberWeightsRed ++; 
				if (positionRedCube1 != 0){
					positionRedCube2 = pnr1;}
				else{positionRedCube2 = pnr1;}
				positionGreenCube2 = 0; 
			}
			
		}
		
		if (colorname1 == "yellow" && colorname3== "yellow")
		{
			int color = Random.Range (0, 6);
			if (color < 3){ 
				colorname3 = "red";
				RightW1 = 2;
				numberWeightsRed ++; 
				numberWeightsYellow --; 
				if (positionRedCube1 != 0){
					positionRedCube2 = pnr1;}
				else{positionRedCube2 = pnr1;}
				positionYellowCube2 = 0; 
				
			} else {
				colorname3 = "green";
				RightW1 = 3;
				numberWeightsGreen ++; 
				numberWeightsYellow --; 
				if (positionGreenCube1 != 0){
					positionGreenCube2 = pnr1;}
				else{positionGreenCube2 = pnr1;}
				positionYellowCube2 = 0; 
			}
		}		
		
		{
			instruction.text= "Press Ready to Start Trial";
			//instruction.text = "Place:\n1 " + colorname1 + " piece in the left place number " + pnl1 + ".\n1 " + colorname3 + " piece in the right place number " + pnr1;
			
		}
	}
	
	public void level2 (){
		instruction = GetComponent <Text> ();
		
		numberWeightsRed = 0; 
		numberWeightsYellow = 0; 
		numberWeightsGreen = 0; 
		
		positionRedCube1 = 0; 
		positionRedCube2 = 0;
		positionYellowCube1 = 0; 
		positionYellowCube2 = 0;
		positionGreenCube1 = 0; 
		positionGreenCube2 = 0; 
		
		pnl1 = Random.Range (1, 7);
		pnl2 = 0;
		pnr1 = Random.Range (1, 7);
		pnr2 = 0;
		pcolor1 = Random.Range (0, 6);
		pcolor2 = 0;
		pcolor3 = Random.Range (0, 6);
		pcolor4 = 0;
		
		while (pnl1 == pnl2) {
			pnl2 = Random.Range (1, 7);
		}
		
		while (pnr1 == pnr2) {
			pnr2 = Random.Range (1, 7);
		}
		
		
		if (pcolor1 < 2) {
			colorname1 = "red";
			LeftW1 = 2;
			numberWeightsRed ++; 
			positionRedCube1 = (pnl1 * (-1));
			
		} else if (pcolor1 < 4) {
			colorname1 = "green";
			LeftW1 = 3;
			numberWeightsGreen ++; 
			positionGreenCube1 = (pnl1 * (-1));
		}
		
		else {
			colorname1 = "yellow";
			LeftW1 = 1;
			numberWeightsYellow ++; 
			positionYellowCube1 = (pnl1*(-1));
		}
		
		colorname3 = colorname1;
		RightW1 = LeftW1;
		
		if (LeftW1 == 2) {
			numberWeightsRed ++; 
			positionRedCube2 = pnr1; 
			positionYellowCube1 = 0; 
			positionGreenCube1 = 0; 
			
		} else if (LeftW1 == 1) {
			numberWeightsYellow ++; 
			positionYellowCube2 = pnr1; 
			positionRedCube1 = 0; 
			positionGreenCube1 = 0; 
			
		} else {
			numberWeightsGreen ++;
			positionGreenCube2 = pnr1; 
			positionYellowCube1 = 0;
			positionRedCube1 = 0; 
		}
		
		{
			//instruction.text = "Place:\n1 " + colorname1 + " piece in the left place number " + pnl1 + ".\n1 " + colorname3 + " piece in the right place number " + pnr1;
			instruction.text="Press Ready to Start Trial";
		}
	}
	
	
	public void level3 (){
		instruction = GetComponent <Text> ();
		
		numberWeightsRed = 0; 
		numberWeightsYellow = 0; 
		numberWeightsGreen = 0; 
		
		positionRedCube1 = 0; 
		positionRedCube2 = 0;
		positionYellowCube1 = 0; 
		positionYellowCube2 = 0;
		positionGreenCube1 = 0; 
		positionGreenCube2 = 0; 
		
		pnl1 = Random.Range (1, 7);
		pnl2 = 0;
		pnr1 = Random.Range (1, 7);
		pnr2 = 0;
		pcolor1 = Random.Range (0, 6);
		pcolor2 = 0;
		pcolor3 = Random.Range (0, 6);
		pcolor4 = 0;
		
		while (pnl1 == pnl2) {
			pnl2 = Random.Range (1, 7); 
			
		}
		
		while (pnr1 == pnr2) {
			pnr2 = Random.Range (1, 7);
			
			
		}
		
		if (pcolor1 < 2) {
			colorname1 = "red";
			LeftW1 = 2;
			numberWeightsRed ++; 
			positionRedCube1 = (pnl1 * (-1));
			
		} else if (pcolor1 < 3){
			colorname1 = "green";
			LeftW1 = 3;
			numberWeightsGreen ++; 
			positionGreenCube1 = (pnl1 * (-1));
		} else {
			colorname1 = "yellow";
			LeftW1 = 1;
			numberWeightsYellow ++; 
			positionYellowCube1 = (pnl1 * (-1));
		}
		
		
		if (pcolor3 < 2) {
			colorname3 = "green";
			RightW1 = 3;
			numberWeightsGreen ++; 
			positionGreenCube2 = pnr1; 
			
		} else if (pcolor3 < 4){
			colorname3 = "yellow";
			RightW1 = 1;
			numberWeightsYellow ++; 
			positionYellowCube2 = pnr1; 
		} else {
			colorname3 = "red";
			RightW1 = 2;
			numberWeightsRed ++; 
			positionRedCube2 = pnr1; 
		}
		
		
		if (colorname1 == "red" && colorname3 == "red") {
			
			int color = Random.Range (0, 6);
			if (color < 3){ 
				colorname3 = "yellow";
				RightW1 = 1;
				numberWeightsRed --; 
				numberWeightsYellow ++; 
				
				if (positionYellowCube1 != 0) {
					positionYellowCube2 = pnr1;
				} else {
					positionYellowCube1 = pnr1;
				}
				positionRedCube2 = 0; 
				
			} else {
				colorname3 = "green";
				RightW1 = 3;
				numberWeightsRed --; 
				numberWeightsGreen ++; 
				
				if (positionGreenCube1 != 0) {
					positionGreenCube2 = pnr1;
				} else {
					positionGreenCube1 = pnr1;
				}
				positionRedCube2 = 0; 
			}
			
			// positionYellowCube2 = pnr1; 
			// positionRedCube1 = 0; 
		}
		
		if (colorname1 == "yellow" && colorname3 == "yellow") {
			
			
			int color = Random.Range (0, 6);
			if (color < 3){ 
				colorname3 = "red";
				RightW1 = 2;
				numberWeightsRed ++; 
				numberWeightsYellow --; 
				
				if (positionRedCube1 != 0) {
					positionRedCube2 = pnr1;
				} else {
					positionRedCube1 = pnr1;
				}
				positionYellowCube2 = 0; 
				
			} else {
				colorname3 = "green";
				RightW1 = 3;
				numberWeightsYellow --; 
				numberWeightsGreen ++; 
				
				if (positionGreenCube1 != 0) {
					positionGreenCube2 = pnr1;
				} else {
					positionGreenCube1 = pnr1;
				}
				positionYellowCube2 = 0; 
			}
			
		}
		
		
		{
			instruction.text="Press Ready to Start Trial";
			//instruction.text = "Place:\n1 " + colorname1 + " piece in the left place number " + pnl1 + ".\n1 " + colorname3 + " piece in the right place number " + pnr1;
			
		}
	}
	
	
	public void level4 (){
		
		instruction = GetComponent <Text> ();
		
		numberWeightsRed = 0; 
		numberWeightsYellow = 0; 
		numberWeightsGreen = 0; 
		
		positionRedCube1 = 0; 
		positionRedCube2 = 0; 
		positionYellowCube1 = 0;
		positionYellowCube2 = 0;
		positionGreenCube1 = 0; 
		positionGreenCube2 = 0; 
		
		positionRedCube3 = 0; 
		positionRedCube4 = 0; 
		positionYellowCube3 = 0;
		positionYellowCube4 = 0;
		positionGreenCube3 = 0; 
		positionGreenCube4 = 0; 
		
		pnl1 = Random.Range (1, 7);
		pnl2 = Random.Range (1, 7);
		pnr1 = Random.Range (1, 7);
		pnr2 = Random.Range (1, 7);
		pcolor1 = Random.Range (0, 6);
		pcolor2 = Random.Range (0, 6);
		pcolor3 = Random.Range (0, 6);
		pcolor4 = Random.Range (0, 6);
		
		while (pnl1 == pnl2) {
			pnl2 = Random.Range (1, 7);
		}
		
		while (pnr1 == pnr2) {
			pnr2 = Random.Range (1, 7);
		}
		
		
		// --------------Cube 1
		
		if (pcolor1 < 2) {
			colorname1 = "red";
			LeftW1 = 2;
			numberWeightsRed ++;
			positionRedCube1 = (pnl1*(-1)); 
			
		} else if (pcolor1 < 4) {
			colorname1 = "yellow";
			LeftW1 = 1;
			numberWeightsYellow ++; 
			positionYellowCube1 = (pnl1*(-1)); 
			
		} else {
			colorname1 = "green";
			LeftW1 = 3;
			numberWeightsGreen ++; 
			positionGreenCube1 = (pnl1*(-1)); 
			
		}
		
		// ---------------------- Cube 2
		if (pcolor2 < 2) {
			colorname2 = "red";
			LeftW2 = 2;
			numberWeightsRed ++;
			
			if (positionRedCube1 != 0){
				positionRedCube2 = (pnl2*(-1));
			}
			else {
				positionRedCube1 = (pnl2*(-1));
			}
			
		} else if (pcolor2 < 4) {
			colorname2 = "yellow";
			LeftW2 = 1;
			numberWeightsYellow ++; 
			if (positionYellowCube1 != 0){
				positionYellowCube2 = (pnl2*(-1));
			}
			else {
				positionYellowCube1 = (pnl2*(-1));
			}
			
			
		} else {
			colorname2 = "green";
			LeftW2 = 3;
			numberWeightsGreen ++; 
			
			if (positionGreenCube1 != 0){
				positionGreenCube2 = (pnl2*(-1));
			}
			else {
				positionGreenCube1 = (pnl2*(-1));
			}
			
		}
		//colorname1 = "red";
		//colorname2 = "yellow";
		//LeftW1 = 1;
		//LeftW2 = 2;
		
		// Gianna's code for cube of colorname2
		
		
		
		
		//		} else {
		//
		//			colorname1 = "yellow";
		//			colorname2 = "red";
		//			LeftW1 = 2;
		//			LeftW2 = 1;
		//			numberWeightsYellow ++;
		//			numberWeightsRed ++; 
		//			positionYellowCube1 = (pnl1*(-1));
		
		// Gianna's code for cube of colorname2
		//
		//			if (positionRedCube1 != 0){
		//				positionRedCube2 = (pnl2*(-1));
		//			}
		//			else {
		//				positionRedCube1 = (pnl2*(-1));
		//			}
		
		// ------------------ Cube 3
		if (pcolor3 < 2) {
			colorname3 = "red";
			RightW1 = 2;
			numberWeightsRed ++;
			//positionRedCube1 = (pnr1 * (-1)); 
			
			if (positionRedCube1 != 0) {
				if (positionRedCube2 != 0) {
					positionRedCube3 = pnr1;
				} else {
					positionRedCube2 = pnr1;
				}
			} else {
				positionRedCube1 = pnr1;
			}
			
			
		} else if (pcolor3 < 4) {
			
			colorname3 = "yellow";
			RightW1 = 1;
			numberWeightsYellow ++; 
			//			positionYellowCube1 = (pnr1 * (-1)); 
			
			if (positionYellowCube1 != 0) {
				
				if (positionYellowCube2 != 0) {
					
					//					if (positionYellowCube3 != 0) {
					//						positionYellowCube4 = pnr1;
					//					} else {
					positionYellowCube3 = pnr1;
					//					}
					
				} else {
					positionYellowCube2 = pnr1;
				}
				
			} else {
				positionYellowCube1 = pnr1;
			}
			
		} else {
			colorname3 = "green";
			RightW1 = 3;
			numberWeightsGreen ++; 
			//			positionGreenCube1 = (pnr1 * (-1)); 
			
			if (positionGreenCube1 != 0) {
				
				if (positionGreenCube2 != 0) {
					
					//					if (positionGreenCube3 != 0) {
					//						positionGreenCube4 = pnr1;
					//					} else {
					positionGreenCube3 = pnr1;
					//					}
					
				} else {
					positionGreenCube2 = pnr1;
				}
				
			} else {
				positionGreenCube1 = pnr1;
			}
		}
		
		if (pcolor4 < 2) {
			colorname4 = "red";
			RightW2 = 2;
			numberWeightsRed ++;
			
			if (positionRedCube1 != 0) {
				
				if (positionRedCube2 != 0) {
					
					if (positionRedCube3 != 0) {							
						positionRedCube4 = pnr2;
					} else {
						positionRedCube3 = pnr2;
					}
					
				} else {
					positionRedCube2 = pnr2;
				}
				
			} else {
				positionRedCube1 = pnr2;
			}
			//			positionRedCube1 = (pnr2*(-1)); 
			
		} else if (pcolor4 < 4) {
			colorname4 = "yellow";
			RightW2 = 1;
			numberWeightsYellow ++; 
			if (positionYellowCube1 != 0) {
				
				if (positionYellowCube2 != 0) {
					
					if (positionYellowCube3 != 0) {
						positionYellowCube4 = pnr2;
					} else {
						positionYellowCube3 = pnr2;
					}
					
				} else {
					positionYellowCube2 = pnr2;
				}
				
			} else {
				positionYellowCube1 = pnr2;
			}
			//			positionYellowCube1 = (pnr2*(-1)); 
			
			
		} else {
			colorname4 = "green";
			RightW2 = 3;
			numberWeightsGreen ++; 
			
			if (positionYellowCube1 != 0) {
				
				if (positionYellowCube2 != 0) {
					
					if (positionGreenCube3 != 0) {
						positionGreenCube4 = pnr2;
					} else {
						positionGreenCube3 = pnr2;
					}
					
				} else {
					positionGreenCube2 = pnr2;
				}
				
			} else {
				positionGreenCube1 = pnr2;
			}
			//			positionGreenCube1 = (pnr2*(-1)); 
			
		}
		
		{
			//			Debug.Log ("1: " + colorname1.ToString() + "2: " +colorname2.ToString() + "3: " +colorname3.ToString() + "4: " +colorname4.ToString());
			instruction.text="Press Ready to Start the Trial";
			//instruction.text = "Place:\n1 " + colorname1 + " piece in the left place number " + pnl1 + ".\n1 " + colorname2 + " piece in the left place number " + pnl2 + ".\n1 " + colorname3 + " piece in the right place number " + pnr1 + ".\n1 " + colorname4 + " piece in the right place number " + pnr2;
			
		}
	}
	
	public void prueba(){
		Debug.Log ("Prueba");
	}
	
	public void ADexercise(){
		Debug.Log ("GotHere5");
		
		instruction = GetComponent <Text> ();
		instruction.text = "Place the required weights in the marked places";
		
		rightSideAD = Generatecubespositions(ADSystem.numberofcubes);
		
		leftSideAD = Generatecubespositions(ADSystem.numberofcubes);
		numberofplaces = ADSystem.numberofcubes;
		Debug.Log ("Right: " + rightSideAD + " Left: " + leftSideAD);
		
		GameObject Cubes = GameObject.Find ("Invisible Spaces");
		Cubes.GetComponent<ColorcubesAD> ().ActiveCubesAD ();
		
		
	}
	
	string Generatecubespositions(int Size)  {
		
		string input = "123456";
		StringBuilder activecubes = new StringBuilder();
		char ch;
		for (int i = 0; i < Size; i++)
		{
			
			ch = input[Random.Range(0, input.Length-1)];
			activecubes.Append(ch);
			input = input.Replace(ch.ToString(),string.Empty);
			
		}
		return activecubes.ToString();
		
	}
	
	
	
	public void AdaptiveLevels(){
		
		
		if (levelis.performancelevel >= 60) {
			if (levelis.levelnumber == 4){
				levelis.levelnumber = levelis.levelnumber;}
			else{
				levelis.levelnumber = levelis.levelnumber + 1;
			}
		}
		if (levelis.performancelevel <= 40) {
			if (levelis.levelnumber == 1){
				levelis.levelnumber = levelis.levelnumber;}
			else {
				levelis.levelnumber = levelis.levelnumber - 1;}
		}
		else {
			levelis.levelnumber = levelis.levelnumber;
		}
		displayinstructions ();
	}
}
	
	
