using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class GameManager : MonoBehaviour {
    public GameObject Hp;
    public GameObject Mp;
    public GameObject UI;
    public GameObject Bag;
    public GameObject Box;
    public static int boolTransparency = 0;

    private Transform player;

    // Use this for initialization
    void Start () {
        Readlib();
        Bag.GetComponent<Baginfo>().Init();
        Box.GetComponent<Box>().Readbox();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F))
            boolTransparency = (boolTransparency + 1) % 2;
        if (boolTransparency == 1)
            player.GetComponent<SpriteRenderer>().color = new Color(256, 256, 256, (float)0.1);

        if (boolTransparency == 0)
            player.GetComponent<SpriteRenderer>().color = new Color(256, 256, 256,1);

//改变颜色

        Hp.GetComponent<Slider>().value = tags.pHP;
        Mp.GetComponent<Slider>().value = tags.pMP;

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (tags.bagon) {tags.bagon = false;tags.uion = true;}
            else { tags.bagon = true; tags.uion = false; }
            UI.SetActive(tags.uion);
            Bag.SetActive(tags.bagon);
        }
	}
    public void Readlib() {
        int id, attack, effcount;
        string[] linecat;
        string name,skill, effect, explain, line;
        FileStream path = new FileStream(Application.streamingAssetsPath+"\\library.csv", FileMode.Open);
        StreamReader sr = new StreamReader(path);
        while ((line = sr.ReadLine()) != null) {
            linecat = line.Split(',');
            id = int.Parse(linecat[0]);
            name = linecat[1];
            attack = int.Parse(linecat[2]);
            skill = linecat[3];
            effect = linecat[4];
            effcount = int.Parse(linecat[5]);
            explain = linecat[6];
            tags.library.Add(new Weapon(id, name, attack,skill, effect, effcount, explain));
        }
        sr.Close();

       

    }
     public void TakeDamage(int enemyAttack)
        {
            tags.pHP -= enemyAttack;
        }
    
}
