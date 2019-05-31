// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DoubleTrouble : MonoBehaviour {

//     public GameObject objA;
//     public GameObject objB;

//     public SteamVR_TrackedObject left;
//     public SteamVR_TrackedObject right;

//     private bool bothHands = false;
	
// 	// Update is called once per frame
// 	void Update () {
//         if (!left.isActiveAndEnabled || !right.isActiveAndEnabled)
//             return;

//         var lDevice = SteamVR_Controller.Input((int)left.index);
//         var rDevice = SteamVR_Controller.Input((int)right.index);

//         if ( lDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) ||rDevice.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) ) {
//             bothHands = !bothHands;
//         }

//         if (bothHands) {
//             Vector3 leftGuiding = left.transform.position - head.position;
//             Vector3 rightGuiding = right.transform.position - head.position;

//             Vector3 obj_path = leftGuiding + rightGuiding;

//             objA.transform.position += obj_path;
//             objB.transform.position += obj_path;

//         }
// 	}
// }