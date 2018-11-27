using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.UX.Dialog;
using UnityEngine.UI;


[System.Serializable]
public class DialogueManager : MonoBehaviour {


	public TextMesh title;
	public TextMesh messages;

	private Stack<string> forward;
	private Stack<string> backward;

	public Image image;


	void Start() {
		forward = new Stack<string>();
		backward = new Stack<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		image.sprite = dialogue.bodyPart;

		Debug.Log ("Starting..." + dialogue.title);
		title.text = dialogue.title;

		forward.Clear();	

		backward.Clear();

		for (int i = dialogue.sentences.Length - 1; i >= 0; i--) {
			forward.Push (dialogue.sentences [i]);
			Debug.Log (dialogue.sentences [i]);
		}

		DisplayNextSentence();
	}


	public void DisplayNextSentence()
	{
		if (forward.Count == 0) {
			EndDialogue ();
			return;
		} else {
			string sentence = forward.Pop ();
			backward.Push (sentence);

			if (!messages.text.TrimEnd().Equals(sentence)) {
				messages.text = sentence;
			} else {
				string s = forward.Pop ();
				backward.Push (s);
				messages.text = s;
			}

		} // end of if clause 
	
	}

	public void DisplayPrevSentence()
	{
		Debug.Log ("Stack count: " + backward.Count);
		if (backward.Count == 0) {
			EndDialogue ();
			return;
		} else {
			string sentence = backward.Pop ();
			string messagesText = messages.text.TrimEnd();
			forward.Push (sentence);

			if (!messagesText.Equals(sentence)) {
				messages.text = sentence;
			} else {
				string s = backward.Pop ();
				forward.Push (s);
				messages.text = s;
			}
		} // end of if clause 	

	}

	public void EndDialogue(){
		Debug.Log ("Sentence ended");
	}
}
