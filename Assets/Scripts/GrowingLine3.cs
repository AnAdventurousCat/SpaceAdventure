using UnityEngine;
using System.Collections;

public class GrowingLine3 : MonoBehaviour {
//
//	private LineRenderer LineLeft1; 
//	
//	private float counter1;
//
//	
//	private float distance1; 
//	
//	public Color red = Color.red;
//	public Color yellow = Color.yellow; 
//	public Color green = Color.green; 
//
//	private GameObject levelcomesfrom;
//	private Gamemanager levelis;
//	
//	
//	public float LineDrawSpeed = 6f; 
//	
//	public Transform Origin; 
//	public Transform destination1;
//	public Transform destination2;
//	public Transform destination3;
//	public Transform destination4;
//	public Transform destination5;
//	public Transform destination6;
//	
//	// Get cube position & color
//	private Instruction CubePosition;
//	private GameObject cubePosition; 
//	
//	Vector3 VecDestination1; 
//	Vector3 VecDestination2;
//	
//	// Use this for initialization
//	void Start () {
//
//		levelcomesfrom = GameObject.Find ("Exercisemanager"); 
//		levelis = levelcomesfrom.GetComponent<Gamemanager> ();
//
//		cubePosition = GameObject.Find ("Instructions"); 
//		CubePosition = cubePosition.GetComponent<Instruction> (); 
//
//	}
//
//	public void DecideSetActive()
//	{
//		if (levelis.levelnumber == 4) {
//			gameObject.SetActive(true);
//			DrawLine();
//			Debug.Log ( "Line is Activvvvvvvvvvvvveeeee Script 3");
//		}
//	}
//
//	private void DrawLine(){
//		
//		LineLeft1 = GetComponent<LineRenderer>(); 
//
//		if (CubePosition.LeftW2 == 1) {	// draw a red line left LineLeft1
//			LineLeft1.SetColors (red, red); 
//			
//		} else if (CubePosition.LeftW2 == 2) {
//			LineLeft1.SetColors (yellow, yellow);
//		} else {
//			LineLeft1.SetColors(green, green);
//		}
//		
//		if (CubePosition.pnl2 == 1) {
//			distance1 = Vector3.Distance (Origin.position, destination1.position);
//			VecDestination1 = destination1.position;
//			
//		} else if (CubePosition.pnl2 == 2) {
//			distance1 = Vector3.Distance (Origin.position, destination2.position);
//			VecDestination1 = destination2.position;
//			
//		} else if (CubePosition.pnl2 == 3) {
//			distance1 = Vector3.Distance (Origin.position, destination3.position);
//			VecDestination1 = destination3.position;
//			
//		} else if (CubePosition.pnl2 == 4) {
//			distance1 = Vector3.Distance (Origin.position, destination4.position);
//			VecDestination1 = destination4.position;
//			
//		} else if (CubePosition.pnl2 == 5) {
//			distance1 = Vector3.Distance (Origin.position, destination5.position);
//			VecDestination1 = destination5.position;
//			
//		} else if (CubePosition.pnl2 == 6) {
//			distance1 = Vector3.Distance (Origin.position, destination6.position);
//			VecDestination1 = destination6.position;
//		}
//		
//		LineLeft1.SetPosition (0, Origin.position); 
//		LineLeft1.SetWidth (14.0f, 14.0f);
//;
//		
//		//distance1 = Vector3.Distance (Origin.position, destination4.position); 
//		
//		// LineLeft1.SetColors (yellow, yellow); 
//		
//		if (counter1 < distance1) { 
//			counter1 += .1f / LineDrawSpeed; 
//			
//			float x = Mathf.Lerp (0, 20, counter1); 
//			Vector3 pointA = Origin.position; 
//			// Vector3 VecDestination = destination4.position; 
//			
//			Vector3 pointAlongLine1 = x * Vector3.Normalize (VecDestination1 - pointA) + VecDestination1;
//
//			LineLeft1.SetPosition (1, pointAlongLine1); 
//
//		}
//	}
//	
//	void Update () {
//		
//		
//		
//		//		if (counter1 < distance1){ 
//		//			counter1 += .1f/LineDrawSpeed; 
//		//
//		//			float x = Mathf.Lerp(0,20,counter1); 
//		//			Vector3 pointA = origin.position; 
//		//			Vector3 pointB = destination4.position; 
//		//
//		//			Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA)+ pointB;
//		//
//		//
//		//			LineLeft1.SetPosition(4,pointAlongLine); 
//		//	
//		//		}
//		
//	}
}
