﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockAction : MonoBehaviour
{
	public Vector3 centerPosition;
	public Vector3 centerScale;
	public bool inCenter = false;
	public float radius;
	public float rotationSpeed = 1; //negative for counterclockwise

	public GameObject rhythmObject;
	private float y = 0;

	void Awake () {
		inCenter = false;
		//rhythmObject = transform.parent.Find("RhythmObject");
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (inCenter) {
			y += rotationSpeed;
        	transform.rotation = Quaternion.Euler(0, y, 0);

			//transform.rotation.y += 1;
		} else {
			Vector3 delta = centerPosition - transform.localPosition;
			if (delta.magnitude < .25f) {
				inCenter = true;
                transform.localPosition = centerPosition;
			} else {
				transform.position += delta / 75;
			}
		}

		if (rhythmObject != null) {
			float deltaRadius = radius - rhythmObject.transform.localPosition.x;
			if (deltaRadius < .1f ) {
				rhythmObject.transform.localPosition = new Vector3(radius, 0, 0);
			} else {
				rhythmObject.transform.localPosition += new Vector3(deltaRadius / 75, 0, 0);
			}
		}

		Vector3 deltaScale = centerScale - transform.localScale;
		if (deltaScale.magnitude < .1f && deltaScale.magnitude > -.1f)  {
			transform.localScale = centerScale;
		} else {
			if (deltaScale.magnitude > 0) {
				transform.localScale += deltaScale / 75;
			} else {
				transform.localScale -= deltaScale / 75;		
			}
		}
	}

	public void OnEnable(){
		GameObject center = transform.parent.transform.Find("CenterArea").gameObject;
		transform.SetParent(center.transform);
	}
}
