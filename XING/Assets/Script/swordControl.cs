using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordControl : MonoBehaviour {


    private Animator animator;
    private Vector2 lastPosition;
    private Transform player;
    private float timer;
    public int attackDirection = 1;//1:up 2:right 3:down 4:left
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;//获得主角位置（2）
        lastPosition = player.position;

    }

    // Update is called once per frame
    void Update () {
        float x, y;

        timer += Time.deltaTime;
        x = player.position.x - lastPosition.x;
        y = player.position.y - lastPosition.y;

        if (GameManager.boolTransparency == 1)
            this.GetComponent<SpriteRenderer>().color = new Color(256, 256, 256, (float)0.1);

        else
            this.GetComponent<SpriteRenderer>().color = new Color(256, 256, 256, 1);
        if (x == 0 && y == 0) ;
        else if (x >= 0&&y >= 0)
        {
            if (x > y)
                attackDirection = 2;
            else
                attackDirection = 1;
        }
        else if(x >= 0&&y <= 0)
        {
            if (x >= (-y))
                attackDirection = 2;
            else
                attackDirection = 3;
        }
        else if(x <= 0&&y >= 0)
        {
            if ((-x) >= y)
                attackDirection = 4;
            else
                attackDirection = 1;
        }
        else if(x <= 0&&y <= 0)
        {
            if (x >= y)
                attackDirection = 3;
            else
                attackDirection = 4;

        }
        if (Input.GetKeyDown(KeyCode.J) && timer > 1.5) { 
            switch (attackDirection)
            {
                case 1: animator.Play("upAttack"); break;
                case 2: animator.Play("rightAttack"); break;
                case 3: animator.Play("downAttack"); break;
                case 4: animator.Play("leftAttack"); break;
            }
            timer = 0;
        }
        lastPosition = player.position;
	}
}
