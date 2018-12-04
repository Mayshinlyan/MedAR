using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

[System.Serializable]
public class DialogInteractions : MonoBehaviour, ISpeechHandler {


	/*public void OnPointerClick(){
		Debug.Log("test");
	}*/
	public Dialogue dialogue;

	public void OnSpeechKeywordRecognized(SpeechEventData eventData){

		if (!eventData.used) {
			switch (eventData.RecognizedText.ToLower()) {
			case "start":
				Debug.Log ("start heard: ");
				FindObjectOfType<DialogueManager> ().StartDialogue (dialogue);
				break;
			case "next":
				Debug.Log ("next heard: ");
				FindObjectOfType<DialogueManager> ().DisplayNextSentence ();
				break;
			case "back":
				Debug.Log ("back heard: ");
				FindObjectOfType<DialogueManager> ().DisplayPrevSentence ();
				break;
			case "okay":
				FindObjectOfType<DialogueManager> ().DisplayNextSentence ();
				break;
			case "abnormal":
				FindObjectOfType<DialogueManager> ().DisplayNextSentence ();
				break;
			default:
				break;
			}

			eventData.Use ();
		} 


	}

}
