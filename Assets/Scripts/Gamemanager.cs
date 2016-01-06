using UnityEngine;
using System.Collections;

public class Gamemanager : MonoBehaviour {
	
	public int taskCount;
	public int score;
	public int levelnumber;
	public float performancelevel;
	public int adaptiveTaskNumber;

	private GameObject ScoreObject;
	private Animate Scorecode;

	ToogleOptions GameConfiguration;
	GameObject GameConfigurationToogles;


	public void addtrial(){

			taskCount = taskCount + 1;

			Debug.Log ("Trial Added" + taskCount.ToString ());

			adaptiveTaskNumber = adaptiveTaskNumber + 1;
		
	}

	void Update(){
		score = Scorecode.score;
	}

	void Start (){
		ScoreObject = GameObject.Find ("Scale");
		Scorecode = ScoreObject.GetComponent<Animate>();

		taskCount = 1;
		levelnumber = 1; 
		adaptiveTaskNumber = 1;

	}



			
	public void Checklevel (){


//		if (GameConfiguration.ActiveAdaptiveDificulty == true || GameConfiguration.ActiveAdaptiveLevels == true) {
//			if (taskCount == 31) {
//				Application.LoadLevel ("UserInstructionTask2");
//			}
//		}
//
//		else {
		
				if (taskCount <= 15) {
					levelnumber = 1; 
					
				} else if (taskCount <= 30) {
					levelnumber = 2;
					
				} else if (taskCount <= 45) {
					levelnumber = 3;
					
				} else if (taskCount <= 60) {
					levelnumber = 4;


				}else if (taskCount > 60) {
				Application.LoadLevel ("FinalSceneSpace");
				}
//		}
	}
}
