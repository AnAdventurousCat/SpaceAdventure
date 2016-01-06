using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;


public class Feedback : MonoBehaviour {


	private Gamemanager TrialCheck;
	private GameObject trialCheck; 

	private Animate AnimationScale; 
	private GameObject animationScale;

	private TextFeedback FeedbackText; 
	private GameObject feedbackText;

	private ArduinoInputBehavior FeedbackAnimateText;
	private GameObject feedbackAnimateText; 

	private TransArrowLeft LeftArrow;
	private GameObject leftArrow; 
	
	private TransArrowRight RightArrow;
	private GameObject rightArrow; 

	int feedbacktype; 
	Text feedbackToText; 
	public int feedbackReturn; 
	bool level1; 
	bool level2; 
	bool level3; 
	bool level4;

	void Start () {
		
		trialCheck = GameObject.Find ("Exercisemanager"); 
		TrialCheck = trialCheck.GetComponent<Gamemanager> (); 

		animationScale = GameObject.Find ("Scale");
		AnimationScale = animationScale.GetComponent<Animate> ();

		feedbackText = GameObject.Find ("Feedback");
		FeedbackText = feedbackText.GetComponent<TextFeedback>();

		feedbackAnimateText = GameObject.Find ("Scale");
		FeedbackAnimateText = feedbackAnimateText.GetComponent<ArduinoInputBehavior>();

		leftArrow = GameObject.Find ("ArrowLeft");
		LeftArrow = leftArrow.GetComponent<TransArrowLeft>();

		rightArrow = GameObject.Find ("ArrowRight");
		RightArrow = rightArrow.GetComponent<TransArrowRight>();

		level1 = true; 
		level2 = true; 
		level3 = true; 
		level4 = true; 

		feedbacktype = 0; 
		feedbackReturn = 0; 
	}

	public void checktrial (){

		feedbackReturn = 0; 
		if (TrialCheck.taskCount % 4 == 0){//  < 10 || TrialCheck.taskCount == 20 || TrialCheck.taskCount == 30 || TrialCheck.taskCount == 40) {
			whichFeedback(); 
		}

			// If level is 5 give feedback 
		// 
	
	}

	//Randomly Pics a Feedbacktype, Animation more likely than textfeedback
	public void whichFeedback(){

	//	Debug.Log ("In Method");
		feedbacktype = Random.Range (1, 8);

		if (feedbacktype < 3) {
			ScaleAnimation ();
			feedbackReturn = 1; 

		} else {
			WhichLevelTextFeedback ();
			 

		} 

	}

	public void ScaleAnimation(){ 

		if (FeedbackAnimateText.balance == 1) {
			AnimationScale.animate ();
			FeedbackText.Left ();

		} else if (FeedbackAnimateText.balance == 2) {
			AnimationScale.animate ();
			FeedbackText.Right (); 
		} else if (FeedbackAnimateText.balance == 0) {
			FeedbackText.Equilibrium(); 
		}
	}

	public void WhichLevelTextFeedback(){

		if (TrialCheck.levelnumber == 4) {
			if (level4){
				FeedbackText.ReturnFeedbackLevel4();
				level4 = false; 
				feedbackReturn = 2;
			} else {
				ArrowTransform();
				feedbackReturn = 3;
			}
		} else if (TrialCheck.levelnumber == 3){
			if (level3){
				FeedbackText.ReturnFeedbackLevel3();
				level3 = false;
				feedbackReturn = 2; 
			} else {
				ArrowTransform();
				feedbackReturn = 3;
			}
		} else if (TrialCheck.levelnumber == 2){
			if (level2){
				FeedbackText.ReturnFeedbackLevel2();
				level2 = false;
				feedbackReturn = 2; 
			} else {
				ArrowTransform();
				feedbackReturn = 3;
			}
		} else {
			if (level1){
				FeedbackText.ReturnFeedbackLevel1();
				level1 = false;
				feedbackReturn = 2; 
			} else {
				ArrowTransform();
				feedbackReturn = 3;
			}

		}
	}

	public void ArrowTransform(){

		LeftArrow.ArrowTransform (); 
		RightArrow.ArrowTransform (); 

	}

	void Update () {


	}
}
