using UnityEngine;
using System.Collections;
//using System.IO.Ports;

public class ArduinoInputBehavior : MonoBehaviour {

	private Instruction Instructionvalues;

	public GameObject Objeto;

	public int balance = 0;
	public int leftpos1; 
	public int leftpos2; 
	public int rightpos1; 
	public int rightpos2; 
	public int leftW1Red; 
	public int leftW2Yell; 
	public int rightW1Red;
	public int rightW2Yell;
	public int doubleValueLeft;
	public int doubleValueRight; 

	public bool pushbutton = false;
	public int whichbutton = 0; 

	public int powerleft; 
	public int powerright;

	
	// SerialPort arduinoinput = new SerialPort("COMX", 9600);

	// Use this for initialization
	void Start () 
	{
		Instructionvalues = Objeto.GetComponent<Instruction>();


		// SetWeigth(leftpos1, leftpos2, rightpos1, rightpos2, leftW1Red, leftW2Yell, rightW1Red, rightW2Yell);
	}
//		Debug.Log (balance);
//		
//		if (!GetComponent<Animation>().isPlaying) {
//			
//			if (balance == 1) {
//				GetComponent<Animation>().Play ("Balance Moves Left");//left
//			} else if (balance == 2) {
//				GetComponent<Animation>().Play ("Balance Moves Right");// Move Balance to the right
//			} else {
//				//Balance in equilibrium 
//			}
//		}
	 
	
	// Update is called once per frame

	void Update ()
	{
		if (Instructionvalues.pnl1 == 1) {
			leftpos1 = 6;
		} else if (Instructionvalues.pnl1 == 2) {
			leftpos1 = 5; 
		} else if (Instructionvalues.pnl1 == 3) {
			leftpos1 = 4; 
		} else if (Instructionvalues.pnl1 == 4) {
			leftpos1 = 3; 
		} else if (Instructionvalues.pnl1 == 5) {
			leftpos1 = 2; 
		} else if (Instructionvalues.pnl1 == 6) {
			leftpos1 = 1; 
		}

		if (Instructionvalues.pnl2 == 1) {
			leftpos2 = 6;
		} else if (Instructionvalues.pnl2 == 2) {
			leftpos2 = 5; 
		} else if (Instructionvalues.pnl2 == 3) {
			leftpos2 = 4; 
		} else if (Instructionvalues.pnl2 == 4) {
			leftpos2 = 3; 
		} else if (Instructionvalues.pnl2 == 5) {
			leftpos2 = 2; 
		} else if (Instructionvalues.pnl2 == 6) {
			leftpos2 = 1; 
		}

		if (Instructionvalues.pnr1 == 1) {
			rightpos1 = 6;
		} else if (Instructionvalues.pnr1 == 2) {
			rightpos1 = 5; 
		} else if (Instructionvalues.pnr1 == 3) {
			rightpos1 = 4; 
		} else if (Instructionvalues.pnr1 == 4) {
			rightpos1 = 3; 
		} else if (Instructionvalues.pnr1 == 5) {
			rightpos1 = 2; 
		} else if (Instructionvalues.pnr1 == 6) {
			rightpos1 = 1; 
		}

		if (Instructionvalues.pnr2 == 1) {
			rightpos2 = 6;
		} else if (Instructionvalues.pnr2 == 2) {
			rightpos2 = 5; 
		} else if (Instructionvalues.pnr2 == 3) {
			rightpos2 = 4; 
		} else if (Instructionvalues.pnr2 == 4) {
			rightpos2 = 3; 
		} else if (Instructionvalues.pnr2 == 5) {
			rightpos2 = 2; 
		} else if (Instructionvalues.pnr2 == 6) {
			rightpos2 = 1; 
		}


//		leftpos2 = Instructionvalues.pnl2;
//		rightpos1 = Instructionvalues.pnr1;
//		rightpos2 = Instructionvalues.pnr2;
		leftW1Red = Instructionvalues.LeftW1;
		leftW2Yell = Instructionvalues.LeftW2;
		rightW1Red = Instructionvalues.RightW1;
		rightW2Yell = Instructionvalues.RightW2;

		doubleValueLeft = 1; 
		doubleValueRight = 1; 

		if (leftW1Red == leftW2Yell) {
			doubleValueLeft = 2; 
		}
		if (rightW1Red == rightW2Yell) {
			doubleValueRight = 2; 
		}

		SetWeigth(leftpos1, leftpos2, rightpos1, rightpos2, leftW1Red, leftW2Yell, rightW1Red, rightW2Yell, doubleValueLeft, doubleValueRight);


	}



//	int TakeValuesArduino ()
//	{
//		// Some input will be somehow translated into values 1-4 for position and 1-2 for object
//		return leftpos1; 
//		return leftpos2; 
//		return rightpos1; 
//		return rightpos2; 
//		return leftW1; 
//		return leftW2;
//		return rightW1; 
//		return rightW2;
//	}


	//balance coded for 1 = left, 2 = right, 0 = balanced
	int SetWeigth (int leftpos1, int leftpos2, int rightpos1, int rightpos2, int leftW1, int leftW2, int rightW1, int rightW2, int dValLeft, int dValRight)
	{	

		powerleft = (leftpos1 * leftW1 + leftpos2 * leftW2)*2*dValLeft;
		powerright = (rightpos1 * rightW1 + rightpos2 * rightW2)*dValRight;

		balance = 0;

		if (powerleft > powerright) {
			balance = 1;
		} 
		else if (powerleft < powerright) {
			balance = 2;
		} 

		return balance;
		return powerleft; 
		return powerright; 


	}
	

//	void ScaleMove (balance)
//	{
//		if (balance = 1) {
//			// Move balance to the left
//		} else if (balance = 2) {
//			// Move Balance to the right
//		} else 
//		{
//			//Balance in equilibrium 
//		}
//	}
}
