using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CubeInteractions : MonoBehaviour, IFocusable, IInputClickHandler, ISpeechHandler {
	
	public Color NormalColor;
	public Color HighLightColor;
	private Renderer myRenderer;
	private Material myMaterialInstance;
	private bool canRotate;
	private Vector3 initialRotation;
	private Vector3 updatedRotation;

	private void Awake(){
		myRenderer = gameObject.GetComponent<Renderer>();
		myMaterialInstance = myRenderer.material;
		initialRotation = gameObject.transform.localRotation.eulerAngles;
	}


	private void Update(){
		if(canRotate){
			updatedRotation = Vector3.zero;
			updatedRotation.x = 1; 
			transform.localRotation *= Quaternion.Euler(updatedRotation);
		}
	}
	public void OnFocusEnter(){
		myMaterialInstance.color = HighLightColor;
	}

	public void OnFocusExit(){
		myMaterialInstance.color = NormalColor;
	}

	private void onDestroy(){
		Destroy (myMaterialInstance);
	}

	public void OnInputClicked(InputClickedEventData eventData){
		Debug.Log ("Clicked");
	}

	public void OnSpeechKeywordRecognized(SpeechEventData eventData){

		switch (eventData.RecognizedText.ToLower()) {
			case "rotate":
				startRotation();
				break;
		case "stop":
				stopRotation();
				break;
			default:
				break;
		}
	}

	public void startRotation(){
		canRotate = true;
	}

	public void stopRotation(){
		canRotate = false;
	}
}
