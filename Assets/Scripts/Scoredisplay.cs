using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scoredisplay : MonoBehaviour {


	private Animate Scorecalculator;
	public GameObject Scorescript;
	Text text;


	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
		Scorecalculator = Scorescript.GetComponent<Animate>();
	}
	
	// Update is called once per frame
	void Update () 

		{
		text.text = "Points: " + Scorecalculator.score;
			
		}
	
	
}
