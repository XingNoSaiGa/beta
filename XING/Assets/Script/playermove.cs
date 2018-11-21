﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour {

    public GameObject Box;

    private Animator animator;
    private GameObject gmManager;

    public  float speed;

    // Use this for initialization
    void Start () {
        //  bag.SetActive(false);
        animator = GetComponent<Animator>();
        gmManager = GameObject.FindGameObjectWithTag("gmManager");
    }
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x > 0)
            animator.Play("rightMove");
        if (x < 0)
            animator.Play("leftMove");

           
        
        transform.position += new Vector3(x, y, 0)/10;
        
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.collider.name == "Boxn" && Input.GetKeyDown(KeyCode.T)) {
            if (!tags.boxon) { tags.boxon = true; speed = 0; }
            else { tags.boxon = false; speed = 1f; }
            Box.SetActive(tags.boxon);
        }
    }
}
