using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.EventSystems;
[System.Serializable]
public class DialogInteractions : MonoBehaviour, IFocusable, IInputClickHandler, ISpeechHandler {

	private bool next;
	private bool prev;

	public Dialogue dialogue;


	public void OnInputClicked(InputClickedEventData eventData){
		Debug.Log ("Clicked");
	}
		

	public void OnSpeechKeywordRecognized(SpeechEventData eventData){

		switch (eventData.RecognizedText.ToLower()) {
		case "next":
			nextDialogue();
			break;
		case "prev":
			prevDialogue();
			break;
		default:
			break;
		}
	}

	public void nextDialogue(){
		Debug.Log("Next Dialog!");
	}

	public void prevDialogue(){
		Debug.Log("Previous Dialog!");
	}


	public void OnFocusEnter(){
		
	}

	public void OnFocusExit(){
		
	}
}
