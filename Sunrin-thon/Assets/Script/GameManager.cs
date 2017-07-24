using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text coinText;
    public Text timeText;
    public Image[] heart = new Image[3];

    public float time = 72000f;
    float tmp;
    float token = 0f;

    int hour, min, sec;
    int hp=3;
    int coin = 0;
	// Use this for initialization
	void Start () {
        SetHp();
        SetCoin();
	}
	
	// Update is called once per frame
	void Update () {
        Chainger();
        SetText();
    }
    void Chainger()
    {
        time -= Time.deltaTime * 240;
        hour = (int)time / 3600;
        tmp = time % 3600;
        sec = (int)tmp % 60;
        min = (int)tmp / 60;
    }
    void SetText()
    {
        timeText.text = hour + " : " + min + " : " + sec;
    }
    void SetCoin() {
        coinText.text = coin+"";
    }
    void SetHp() {
        for (int i = 0; i < 3; ++i)
        {
            heart[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < hp; ++i) {
            heart[i].gameObject.SetActive(true);

        }
    }
    public void AddCoin(int addCoin) {
        coin += addCoin;
        SetCoin();
    }
    public void AddHp(int addHp) {
        hp += addHp;
        SetHp();
    }

}
