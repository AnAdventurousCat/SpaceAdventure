using UnityEngine;
using System.Collections;

public class TransArrowRight : MonoBehaviour {
	
	
	public GameObject Arrow;  

//	private ArduinoInputBehavior FeedbackAnimateText;
//	private GameObject feedbackAnimateText; 

	private ArduinoInputBehavior CorrectButton;
	private GameObject correctButton; 

	int divisionFactor; 

	// Use this for initialization

	void Start () {

		correctButton = GameObject.Find ("Scale");
		CorrectButton = correctButton.GetComponent<ArduinoInputBehavior> (); 
		//gameObject.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
//		feedbackAnimateText = GameObject.Find ("Scale");
//		FeedbackAnimateText = feedbackAnimateText.GetComponent<ArduinoInputBehavior>();
		
	}

	public void CalculateTransform(){

//		feedbackAnimateText = GameObject.Find ("Scale");
//		FeedbackAnimateText = feedbackAnimateText.GetComponent<ArduinoInputBehavior>();

		//divisionFactor = CorrectButton.powerright/CorrectButton.powerleft; 
//		divisionFactor = CorrectButton.powerright/CorrectButton.powerleft; 

	//	Debug.Log (divisionFactor + "  Right");
		ArrowTransform ();
	}

	public void ArrowTransform(){

		if (divisionFactor > 3) {
			Arrow.transform.localScale = new Vector3 (130.4f, 300.6f, 1.4f);
		} else if (divisionFactor > 2) {
			Arrow.transform.localScale = new Vector3 (130.4f, 225.6f, 1.4f);

		} else if (divisionFactor > 1) {
			Arrow.transform.localScale = new Vector3 (130.4f, 150.6f, 1.4f);

		} else if (divisionFactor == 1) {
			Arrow.transform.localScale = new Vector3 (130.4f, 90.6f, 1.4f);
		} else {
			Arrow.transform.localScale = new Vector3 (130.4f, 40.6f, 1.4f);
		}
	//	Debug.Log (divisionFactor + "ArrowRight");
	}
	
	public void ArrowTransformBack(){

		gameObject.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
		
	}
	

	
	// Update is called once per frame
	void Update () {
		divisionFactor = CorrectButton.powerright/CorrectButton.powerleft; 

	}
}
