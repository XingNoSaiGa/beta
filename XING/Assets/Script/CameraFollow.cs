using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = 0, y = 0;
        if (player.position.x > -9f && player.position.x < 9f) x = player.position.x;
        else if (player.position.x <= -9f) x = -9f; else x = 9f;
        if (player.position.y > -16f && player.position.y < 16f) y = player.position.y;
        else if (player.position.y <= -16f) y = -16f; else y = 16f;
        transform.position = new Vector3(x, y, -10f);

    }
}
