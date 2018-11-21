using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Box : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FreshBox();
	}
    public void Readbox() {
        int id, boxcount = 0; ;
        string line;
        FileStream path = new FileStream(Application.streamingAssetsPath + "\\save.csv", FileMode.Open);
        StreamReader sr = new StreamReader(path);
        tags.boxcount = int.Parse(sr.ReadLine());
        while ((line = sr.ReadLine()) != null) {
            id = int.Parse(line);
            Weapon w = tags.library.Find(s => s.ID == id);
            tags.box.Add(w);
            boxcount++;
        }
        tags.boxcount = boxcount;

        Debug.Log(tags.boxcount);
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
