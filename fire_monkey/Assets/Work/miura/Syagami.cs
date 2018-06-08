using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Syagami : MonoBehaviour {
    SteamVR_Controller.Device head = null;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_Utils.RigidTransform Head_tr = head.transform;
        Debug.Log(Head_tr);

    }
}
