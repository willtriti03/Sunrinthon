using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public static PlayerData instance;

    public int score = 0, kill = 0,hp;


	private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }
}
