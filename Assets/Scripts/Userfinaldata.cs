using UnityEngine;
using System.Collections;

public class Userfinaldata : MonoBehaviour {

	public string participantAge; //Variable that save the age of the participant


	public string participantGender; //Variable that save the gender of the participant
	public int gender; 

	public string participantNumber; //Variable that save the number of the participant

	GameObject participantageobject;
	Checkage participantage;

	GameObject participantNumberObject;
	Capturetextdata participantNumberData;

	void Start(){
		
		DontDestroyOnLoad (transform.gameObject);
	}


	public void SetGenderfemenine(){

			participantGender = "femenine";
			gender = 1; 

		}

	public void SetGendermasculine(){
		participantGender = "masculine";
		gender = 0; 
	}


	public void printfinaldata()			

	{
		participantageobject = GameObject.Find ("Agetext");
		participantage = participantageobject.GetComponent<Checkage> ();
		participantAge = participantage.participantAge;

	}

//	public void SaveParticipantNumber()
//	{
//		participantNumberObject = GameObject.Find ("ParticipantNumberText");
//		participantNumberData = participantNumberObject.GetComponent<Capturetextdata> ();
//		participantNumber = participantNumberData.participantNumber;
//
//	}

}
