using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class TextFeedback : MonoBehaviour {

	Text feedbackToText; 
	// Use this for initialization
	void Start () {
	
	}

	public void ReturnFeedbackLevel1(){

		feedbackToText = GetComponent <Text> ();

		feedbackToText.text = "It seems like each color has a different weight, but the order is the same as the place of the first-letter of the color's name in the alphabet.."; 

	}

	public void ReturnFeedbackLevel2(){
		
		feedbackToText = GetComponent <Text> ();
		
		feedbackToText.text = "One earth, the further an object is from the middle of the scale, the stronger is its pull on the scale. Here this seems different..."; 

	}

	public void ReturnFeedbackLevel3(){
		
		feedbackToText = GetComponent <Text> ();
		
		feedbackToText.text = "Objects of the same color seem to have different weights on the left side in comparison to the rights side..."; 

	}

	public void ReturnFeedbackLevel4(){
		
		feedbackToText = GetComponent <Text> ();
		
		feedbackToText.text = "If two objects of the same color are together on one side they seem to be more powerful..."; 

	}
	public void Left(){
		feedbackToText = GetComponent<Text> ();
		feedbackToText.text = "Correct Answer: Left";
	}

	public void Right(){
		feedbackToText = GetComponent<Text> ();
		feedbackToText.text = "Correct Answer: Right";
	}

	public void Equilibrium(){
		feedbackToText = GetComponent<Text> ();
		feedbackToText.text = "Correct Answer: Equilibrium";
	}

	public void Empty(){

		feedbackToText = GetComponent <Text> ();
		feedbackToText.text = ""; 
	} 
	// Update is called once per frame
	void Update () {
	
	}
}
