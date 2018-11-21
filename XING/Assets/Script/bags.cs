using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class bags : MonoBehaviour {
    int bagcount;
    public GameObject thing;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }/*

    public void loadbag() {
        int id, count,type;
        string[] linecat;
        FileStream path = new FileStream(@"E:\Unity\Bags\Assets\load\save.csv", FileMode.Open);
        StreamReader sr = new StreamReader(path);
        bagcount = int.Parse(sr.ReadLine());
        Image[] childs = this.GetComponentsInChildren<Image>();
        Transform[] childn = this.GetComponentsInChildren<Transform>();
        exp[] childt = GetComponentsInChildren<exp>();
        for (int i = 1; i <= bagcount; i++) {
            linecat = sr.ReadLine().Split(',');
            id = int.Parse(linecat[0]);
            count = int.Parse(linecat[1]);

            if (id < 11000) type = 1;
            else if (id < 11100) type = 2;
            else type = 3;
           
            childs[i].sprite = Resources.Load(linecat[0], typeof(Sprite)) as Sprite;
            ///childn[i].name = wu.name;
            //childt[i-1].expn = wu.explain;
            childt[i - 1].type =type;
        }
        sr.Close();
    }
    
    /*
    public void freshbag(int ID) {
        int type;
        if (ID < 11000) type = 1;
        else if (ID < 11100) type = 2;
        else type = 3;
        string name =loadlib.library.Find(s => s.ID == ID).name;
        string explain = loadlib.library.Find(s => s.ID == ID).explain;

        int index = bag.FindIndex(s => s.ID == ID);
        if (index == -1) {
            bag.Add(new Info(ID,type, name, 1, explain));
            bagcount++;
            
        }
        else {
            bag[index].Addcount();
        }

        bag.Sort((Info a, Info b) => {
            if (a.ID > b.ID) return 1;
            else if (a.ID == b.ID) return 0;
            else return -1;
        });

        Image[] childs = GetComponentsInChildren<Image>();
        Transform[] childn= GetComponentsInChildren<Transform>();
        exp[] childt= GetComponentsInChildren<exp>();
        for (int i = 1; i <= bagcount; i++) {
            childs[i].sprite= Resources.Load(bag[i-1].ID.ToString(), typeof(Sprite)) as Sprite;
            childn[i].name = bag[i-1].name;
            childt[i].expn = bag[i].explain;
            Debug.Log(childt[i].type);
            
        }
    }*/
}
