using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticeManager : MonoBehaviour {
    public Text t;
    public GameObject back;
    public string[] noteText = new string[5];
    public string[] storeText = new string[5];
    public string[] tabletText = new string[5];
    public string[] bottleText = new string[5];
    public string[] drinkText = new string[5];
    public string moneyText;
    public string networkText;
    public string switchText;
    float showTime = 2f;
    bool show = false;
    // Use this for initialization
    void Start () {
        t.gameObject.SetActive(false);
        back.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (show) {
            showTime -= Time.deltaTime;
            if (showTime <= 0) {
                show = false;
                t.gameObject.SetActive(false);
                back.SetActive(false);
            }
        }
	}

    public void NoticeMessage(int kind) {
        showTime = 2;
        show = true;
        string s=null;
        switch (kind) {
            case 1:
                s = noteText[Random.Range(0, 5)];
                break;
            case 2:
                s = storeText[Random.Range(0, 5)];
                break;
            case 3:
                s = tabletText[Random.Range(0, 5)];
                break;
            case 4:
                s = bottleText[Random.Range(0, 1)];
                break;
            case 5:
                s = drinkText[Random.Range(0, 1)];
                break;
            case 6:
                s = moneyText;
                break;
            case 7:
                s = networkText;
                break;
            case 8:
                s = switchText;
                break;
            case 9:
                s = "콘센트 전원을 껐따";
                break;
        }
        t.text = s;
        t.gameObject.SetActive(true);
        back.SetActive(true);

    }
}
