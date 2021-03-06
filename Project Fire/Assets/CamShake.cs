﻿using UnityEngine; 
using System.Collections;

public class CamShake : MonoBehaviour { 

	public bool shakePosition;
	public bool shakeRotation;

	public float shakeIntensity = 0.5f; 
	public float shakeDecay = 0.02f;

	private Vector3 OriginalPos;
	private Quaternion OriginalRot;

	private bool isShakeRunning = false;


	public void DoShake()
	{
		OriginalPos = transform.localPosition;
		OriginalRot = transform.rotation;

		StartCoroutine ("ProcessShake");
	}

	IEnumerator ProcessShake()
	{
		Vector3 tempPos = OriginalPos;
		if (!isShakeRunning) {
			isShakeRunning = true;
			float currentShakeIntensity = shakeIntensity;

			while (currentShakeIntensity > 0) {
				if (shakePosition) {
					transform.localPosition = OriginalPos + Random.insideUnitSphere * currentShakeIntensity;
				}
				if (shakeRotation) {
					transform.rotation = new Quaternion (OriginalRot.x + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f,
						OriginalRot.y + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f,
						OriginalRot.z + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f,
						OriginalRot.w + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f);
				}
				currentShakeIntensity -= shakeDecay;
				yield return null;
			}

			isShakeRunning = false;
		}
	}
}