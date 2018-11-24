using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skills : MonoBehaviour
{

    public int lossStamina;
    private float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameManager.boolTransparency == 1)
        {
            if (timer > 0.5)
            {
                tags.pMP -= lossStamina;
                timer = 0;
            }

        }
        else
            if(timer > 0.5&&tags.pMP <= 100)
        {
            tags.pMP += lossStamina / 2;
            timer = 0;
        }
        if (tags.pMP <= 0)
            GameManager.boolTransparency = 0; 
    }
}
