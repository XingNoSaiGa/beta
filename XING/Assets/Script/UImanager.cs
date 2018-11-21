using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {
    public float x, y;
	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(Screen.width * x, Screen.height * y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
