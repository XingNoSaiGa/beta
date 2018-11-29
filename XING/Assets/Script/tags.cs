using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Weapon {
    public int ID;
    public string name;
    public int attack;
    public string skill;
    public string effect;
    public float effcount;
    public string explain;
    public Weapon(int ID, string name,int attack,string skill,string effect, float effcount, string explain) {
        this.ID = ID;
        this.name = name;
        this.attack = attack;
        this.skill = skill;
        this.effect = effect;
        this.effcount = effcount;
        this.explain = explain;
    }
}
public class tags : MonoBehaviour {
    public static bool bagon = false;
    public static bool uion = true;
    public static bool boxon = false;

    public static int pHP = 100;
    public static int pMP = 100;
    public static float pspeed = 1f;

    public static int weapon1id = 0;
    public static int weapon2id = 1;
    public static int Boxinfoid = 0;



    public static int boxcount = 0;
    public static List<Weapon> library = new List<Weapon>();
    public static List<Weapon> box = new List<Weapon>();
}
