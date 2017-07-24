using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {
    public int health = 150;
    public bool death = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddHealth(int addhealth) {
        health += addhealth;
        if (health <= 0) {
            death = true;
        }
    }
}
