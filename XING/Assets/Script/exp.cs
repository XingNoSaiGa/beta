using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exp : MonoBehaviour {
    public int id;
    public string nam;
    public int attack;
    public string skill;
    public string effect;
    public float effcount;
    public string explain;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Image>().sprite= Resources.Load(id.ToString(), typeof(Sprite)) as Sprite;
    }

}
