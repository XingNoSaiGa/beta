using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class Baginfo : MonoBehaviour {
    public GameObject weapon1;
    public GameObject weapon2;


    // Use this for initialization
    public void Init () {
        Freshweapon(weapon1, tags.weapon1id);
        Freshweapon(weapon2, tags.weapon2id);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Freshweapon(GameObject weapon,int id) {
        Weapon info = tags.library.Find(s => s.ID == id);
        Image[] childi = weapon.GetComponentsInChildren<Image>();
        childi[1].sprite= Resources.Load(info.ID.ToString(), typeof(Sprite)) as Sprite;
        childi[2].sprite= Resources.Load(info.skill, typeof(Sprite)) as Sprite;
        Text[] childt= weapon.GetComponentsInChildren<Text>();
        childt[0].text = info.name;
        childt[1].text = info.attack.ToString();
        childt[2].text = info.effect;
        childt[3].text = info.effcount.ToString();
        childt[4].text = info.explain;
    }
}
