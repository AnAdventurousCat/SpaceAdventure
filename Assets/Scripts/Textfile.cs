using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Text;
using System; 

public class Textfile : MonoBehaviour {
	
	//int time;
	// takes the trial number to print 
	private Gamemanager Tasknumber;
	private GameObject tasknumber; 
	
	
	// takes the number of weights for each trial
	private Instruction Weightnumber;
	private GameObject weightnumber; 
	
	// takes the correct input 
	private ArduinoInputBehavior CorrectButton;
	private GameObject correctButton; 
	
	// takes the user input 
	private Animate Useranswer; 
	private GameObject useranswer; 
	
	// takes the position for each cube 
	private Instruction CubePosition;
	private GameObject cubePosition; 

	// Config Scene necessary Particpipant# & Age
//	private Userfinaldata FinalData;
//	private GameObject finalData; 

	//Check which feedback is given: 0 = none, 1 = Animation of correct answer, 2 = TextFeedback
	private Feedback FeedbackType;
	private GameObject feedbackType; 
	
	private StreamWriter writer;  
	string sceneName; 
	string logFileName; 
//	int loggedTask;
	int loggedCorrect; 
//	int loggedUserButton; 
	int loggedCorrectButton; 
	int loggedLevelNumber; 
	int loggedScore; 
	int loggedNumberWeightsRed; 
	int loggedNumberWeightsYellow;
	
	DateTime startTime;
	DateTime readyTime;
	DateTime endTime;
	
	TimeSpan reactionTime1; 
	TimeSpan reactionTime2;
	TimeSpan reactionTime3; 
	
	
	void Start () {
		
		cubePosition = GameObject.Find ("Instructions"); 
		CubePosition = cubePosition.GetComponent<Instruction> (); 
		
		weightnumber = GameObject.Find ("Instructions"); 
		Weightnumber = weightnumber.GetComponent<Instruction> (); 
		
		tasknumber = GameObject.Find ("Exercisemanager");
		Tasknumber = tasknumber.GetComponent<Gamemanager> ();
		
		useranswer = GameObject.Find ("Scale"); 
		Useranswer = useranswer.GetComponent<Animate> ();

		feedbackType = GameObject.Find ("Exercisemanager"); 
		FeedbackType = feedbackType.GetComponent<Feedback> ();
		
		correctButton = GameObject.Find ("Scale");
		CorrectButton = correctButton.GetComponent<ArduinoInputBehavior> (); 

//		finalData = GameObject.Find ("Userdata");
//		FinalData = finalData.GetComponent<Userfinaldata> ();
//		
		sceneName = Application.loadedLevelName; 

//		Debug.Log (FinalData.gender.ToString ());
		StoreStartTime (); 
		createLogFile (); 
		
	}
	
	private void createLogFile(){
		// Creates Numbered log-files in assigned folder starting with nr_0

		string logFilePath = Application.persistentDataPath + @"Assets\Resources\" + sceneName + "_balancescale_staticFeedback_nr_"; // For saving on Android Device
		//string logFilePath = @"Assets\Resources\"  + sceneName + "_balancescale_nr_"; // For saving on the computer & Testing 

		int version = 0;
		logFileName = logFilePath + version + ".txt";
		
		
		while (File.Exists(logFileName)) {
			version ++;
			
			logFileName = logFilePath + version + ".txt";
		}
		
		writer = new StreamWriter (logFileName);
		writer.WriteLine ("Trial#, Feedback, Correct , Button Correct , Button Pressed , Level, Score, #RedWeights, #YellowWeights, #GreenWeights ,TimeSet, TimeChoose, TimeTotal, RedPos1, RedPos2, RedPos3, RedPos4, YellPos1, YellPos2, YellPos3, YellPos4, GreenPos1, GreenPos2, GreenPos3, GreenPos4"); 
		writer.WriteLine ("Date and time: " + System.DateTime.Now.ToString()+ ", Condition: Static Feedback, Participant #: " );
	}
	
	public void StoreStartTime ()
	{	
		// Time when NEW TRIAL STARTS, push of next button, in first trial with start
		startTime = System.DateTime.Now;
	}
	
	public void StoreReadyTime()
	{
		// Time when ready button is pressed
		readyTime = System.DateTime.Now; 
	}
	
	public void StoreEndTime()
	{	
		//Time when LEFT, RIGHT, EQUILIBRIUM button is pressed, END OF TRIAL
		endTime = System.DateTime.Now; 
	}
	
	public void write () {
		
		// Useranswer = gameObject.GetComponent<Animate> ();
		loggedLevelNumber = Tasknumber.levelnumber;
		loggedCorrectButton = CorrectButton.balance; 
//		loggedUserButton = Useranswer.whichbutton; 
		loggedCorrect = Useranswer.correct; 
//		loggedTask = Tasknumber.taskCount;
		loggedScore = Useranswer.score; 
		
		reactionTime1 = readyTime.Subtract(startTime); 
		reactionTime2 = endTime.Subtract(readyTime); 
		reactionTime3 = endTime.Subtract (startTime); // Complete Time of trial 
		
		// reactionTime3 = endTime.Subtract(readyTime); 
		
	
		writer.WriteLine (Tasknumber.taskCount.ToString () +","+FeedbackType.feedbackReturn.ToString()+ "," + loggedCorrect.ToString () + "," + loggedCorrectButton.ToString() + "," + Useranswer.whichbutton.ToString()+ "," + loggedLevelNumber.ToString() + ","+ loggedScore.ToString() + "," + Weightnumber.numberWeightsRed.ToString() + "," + Weightnumber.numberWeightsYellow.ToString() + "," + Weightnumber.numberWeightsGreen.ToString() + "," +  reactionTime1.ToString()+ "," +  reactionTime2.ToString() +"," + reactionTime3.ToString()+","+CubePosition.positionRedCube1.ToString() + "," + CubePosition.positionRedCube2.ToString() + ","+ CubePosition.positionRedCube3.ToString() + "," + CubePosition.positionRedCube4.ToString() +","+ CubePosition.positionYellowCube1.ToString() + "," + CubePosition.positionYellowCube2.ToString() + "," + CubePosition.positionYellowCube3.ToString() + "," + CubePosition.positionYellowCube4.ToString()+","+ CubePosition.positionGreenCube1.ToString()+","+ CubePosition.positionGreenCube2.ToString()+","+CubePosition.positionGreenCube3.ToString()+","+CubePosition.positionGreenCube4.ToString()); 
		writer.Flush ();
		
	}
	
	void Update () {
//		actually unneccessary Update 
//		loggedNumberWeightsRed = Weightnumber.numberWeightsRed; 
//		loggedNumberWeightsYellow = Weightnumber.numberWeightsYellow;
//		loggedCorrectButton = CorrectButton.balance; 
//		loggedUserButton = Useranswer.whichbutton; 
//		loggedCorrect = Useranswer.correct; 
//		loggedTask = Tasknumber.taskCount;
		
	}

}
