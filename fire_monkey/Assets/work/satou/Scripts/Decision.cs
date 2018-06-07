using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        string layerName = LayerMask.LayerToName(other.gameObject.layer);

        if(layerName == "Dead")
        {
            Debug.Log("しんだ");
        }

        if(layerName == "Clear")
        {
            Debug.Log("くりあー");
        }
    }
}
