using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
//STATUS: DOESN'T WORK FOR KATAMARI GAME. WORKS WITH MOUSE COTNROLLED CAMERA. 
	

	public float minDistance = 1.0f;

	public float maxDistnace = 1.0f;

	public float smooth = 10.0f;

	private Vector3 dolly;

	public float distance;
	
	// Use this for initialization
	void Awake ()
	{
		dolly = transform.localPosition.normalized;
		distance = transform.localPosition.magnitude;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 desiredCameraPosition = transform.parent.TransformPoint(dolly * maxDistnace);
		RaycastHit hit;

		if (Physics.Linecast(transform.parent.position, desiredCameraPosition, out hit))
		{
			distance = Mathf.Clamp(hit.distance, minDistance, maxDistnace);
			
		}
		else
		{
			distance = maxDistnace;
		}

		transform.localPosition = Vector3.Lerp(transform.localPosition, dolly * distance, Time.deltaTime * smooth);
	}
}
