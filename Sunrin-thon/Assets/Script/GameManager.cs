using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text coinText;
    public Text hText,mText,sText;
    public Image[] heart = new Image[3];
    public Team[] deathTeam = new Team[12];

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
        if (time <= 0)
        {
            PlayerData.instance.score = coin * 1000 + (int)time;
            for (int i = 0; i < 12; ++i) {
                if(deathTeam[i].death)
                    PlayerData.instance.kill++;
            }
            PlayerData.instance.hp = hp;
            Application.LoadLevel("ScoreScene");

        }
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
        hText.text = hour + "";
        mText.text = min  + "";
        sText.text = sec  + "";
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
        if (hp <= 0) {
            PlayerData.instance.score = coin * 1000 + (int)time;
            for (int i = 0; i < 12; ++i)
            {
                if (deathTeam[i].death)
                    PlayerData.instance.kill++;
            }
            PlayerData.instance.hp = hp;
            Application.LoadLevel("ScoreScene");
        }
        SetHp();
    }
    public bool useMoney(int money) {
        if (coin - money >= 0&& hp!=3)
            return true;
        else
            return false;
    }
}
