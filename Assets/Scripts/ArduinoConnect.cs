using UnityEngine;
using System.Collections;
using System;
using System.IO.Ports; 
using System.Threading;

//
public class ArduinoConnect : MonoBehaviour {

	private ArduinoInputBehavior CalculatedBalance;
	private GameObject calculatedBalance;

//  Input from Pixi (color incorrect but position correct) 
//	public int color1; 
//	public int color2;
//	public int color3; 
//	public int color4;
//	
//	public int position1; 
//	public int position2; 
//	public int position3; 
//	public int position4; 


	int Arduinovalues;

	

	public static SerialPort sp = new SerialPort("COM4", 9600);




//	public bool rightSetting; // input of pixi compared to the instruction, effects the READY -Button
	public static string strIn;

	void Start () {
		calculatedBalance = GameObject.Find ("Scale"); 
		CalculatedBalance = calculatedBalance.GetComponent<ArduinoInputBehavior> (); 
		OpenConnection();
//		sp.Write ("AH");
		Debug.Log ("Connection Open");
	
		//strIn = sp.ReadLine(); // <--- if is only in start, if the person/kid change the position it will not recognize it. It have to be update or a while, I think
	}

//	public void InputArduino(){

		// converts ReadLine - string into individual Ints
		//string s = strIn;
//		string[] values = strIn.Split(',');
//		color1 = Convert.ToInt32(values[0]);
//		position1 = Convert.ToInt32(values[1]);
//		color2 = Convert.ToInt32(values[2]);
//		position2 = Convert.ToInt32(values[3]);
//
//		Debug.Log (color1);
//		print(strIn);
//	}

	public void OutputForArduino(){

		if (sp.IsOpen) {

			if (CalculatedBalance.balance == 1) {
				sp.Write ("AL"); 
				Debug.Log ("Sent AL");
			} else if (CalculatedBalance.balance == 2) {
				sp.Write ("AR");
				Debug.Log ("Sent AR");
			} else {
				sp.Write ("AH");
				Debug.Log ("Sent AH");
			}
		}
	}

	public void MoveBackHome(){
		sp.Write ("AH");
	}
//------------------Still necessary??
//	void ReceiveInput (){
//		// receive 4 bytes 1 = position 1;  2 = color 1; 3 = position 2; 4 = color 2
//		// position = 1 - 6 
//		// color code  A = yellow;  R = Red; V = Green
//
//	}
//-----------------

	public void OpenConnection(){
		try
		{ 
		if (sp != null) 
		{
			if (sp.IsOpen) 
			{
				sp.Close();
				sp.ReadTimeout = 50; 
				print("Closing port, because it was already open!");
			}
			else 
			{
				sp.Open();  // opens the connection
				sp.ReadTimeout = 50;  // sets the timeout value before reporting error
//				print ("Port Opened!");
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print("Port is already open");
			}
			else 
			{
				print("Port == null");
			}
		}
		}
		catch (Exception e){}
	}
	
	void OnApplicationQuit() 
	{
//		sp.Write ("AH");
		sp.Close();
	}

	void Update (){

		try
		{ 
			if (sp.IsOpen){
				print ("Port Opened!");
			}
			//Debug.Log(Convert.ToUInt64(Arduinovalues));
			strIn = sp.ReadLine(); //first value colo(Color left side, Place left side ; Color right side, Place right side)
//			strIn = sp.ReadLine();
			print(strIn);
			Debug.Log ("READ INPUT");
		}
		catch (Exception e){}
		Debug.Log("DIDNT READ");
	
	}

	
}
