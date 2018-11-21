using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class wp1 : MonoBehaviour {
    public Image[] childi;
    // Use this for initialization
    void Start () {
        childi = this.GetComponentsInChildren<Image>();
        Fresh();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            int tmp = tags.weapon1id;
            tags.weapon1id = tags.weapon2id;
            tags.weapon2id = tmp;
            Fresh();
        }
    }
    public void Fresh() {
        childi[0].sprite = Resources.Load(tags.weapon1id.ToString(), typeof(Sprite)) as Sprite;
        childi[1].sprite = Resources.Load(tags.weapon2id.ToString(), typeof(Sprite)) as Sprite;
    }
}
