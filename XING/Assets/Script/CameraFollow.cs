using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform player;
    public float edge;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = 0, y = 0;
        if (player.position.x > -edge && player.position.x < edge) x = player.position.x;
        else if (player.position.x <= -edge) x = -edge; else x = edge;
        if (player.position.y > -edge && player.position.y < edge) y = player.position.y;
        else if (player.position.y <= -edge) y = -edge; else y = edge;
        transform.position = new Vector3(x, y, -10f);

    }
}
