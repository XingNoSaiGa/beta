using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Box : MonoBehaviour {
    public Baginfo Bag;
    public GameObject Info;
    public Transform kuang;
    public Transform Now;
    public Transform Then;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FreshBox();
        Freshinfo();
        Equip();
    }
    public void Equip() {
        if (Input.GetKeyDown(KeyCode.J)) {
            tags.weapon1id = tags.Boxinfoid;
            Now.transform.position = GameObject.Find("thing" + tags.weapon1id.ToString()).GetComponent<Transform>().position;
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            tags.weapon2id = tags.Boxinfoid;
            Then.transform.position = GameObject.Find("thing" + tags.weapon2id.ToString()).GetComponent<Transform>().position;
        }
    }
    public void Freshinfo() {
        Bag.Freshweapon(Info, tags.Boxinfoid+1);
        if (Input.GetKeyDown(KeyCode.UpArrow)) tags.Boxinfoid -= 3;
        if (Input.GetKeyDown(KeyCode.DownArrow)) tags.Boxinfoid += 3;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) tags.Boxinfoid -= 1;
        if (Input.GetKeyDown(KeyCode.RightArrow)) tags.Boxinfoid += 1;
        if (tags.Boxinfoid < 0) tags.Boxinfoid = 0;
        if (tags.Boxinfoid > tags.boxcount-1) tags.Boxinfoid = tags.boxcount-1;
        kuang.transform.position = GameObject.Find("thing" + tags.Boxinfoid.ToString()).GetComponent<Transform>().position;
        
    }
    public void Readbox() {
        int id, boxcount = 0; ;
        string line;
        FileStream path = new FileStream(Application.streamingAssetsPath + "\\save.csv", FileMode.Open);
        StreamReader sr = new StreamReader(path);
        while ((line = sr.ReadLine()) != null) {
            id = int.Parse(line);
            Weapon w = tags.library.Find(s => s.ID == id);
            tags.box.Add(w);
            boxcount++;
        }
        tags.boxcount = boxcount;
    
        sr.Close();
    }
    public void FreshBox() {
        exp[] child = this.GetComponentsInChildren<exp>();
        for(int i = 0; i < tags.box.Count; i++) {
            child[i].id = tags.box[i].ID;
            child[i].nam = tags.box[i].name;
            child[i].attack = tags.box[i].attack;
            child[i].skill = tags.box[i].skill;
            child[i].effect = tags.box[i].effect;
            child[i].effcount = tags.box[i].effcount;
            child[i].explain = tags.box[i].explain;
        }
    }
}
