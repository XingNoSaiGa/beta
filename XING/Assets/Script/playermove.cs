using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour {

    public GameObject Box;

    private Animator animator;
    
    public int ATK;

    // Use this for initialization
    void Start () {
        //  bag.SetActive(false);
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if (x > 0)animator.Play("rightMove");
        if (x < 0)animator.Play("leftMove");
        transform.position += new Vector3(x, y, 0)/10*tags.pspeed;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.name == "Boxn" && Input.GetKeyDown(KeyCode.T)) {
            if (!tags.boxon) { tags.boxon = true; Box.SetActive(tags.boxon); tags.pspeed = 0; }
        }
        if (collision.name == "HPmed") {
            tags.pHP += 25;
            if (tags.pHP > 100) tags.pHP = 100;
            Destroy(collision.gameObject);
        }
    }
}
