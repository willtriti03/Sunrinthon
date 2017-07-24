using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour {
    public Text tt;
	// Use this for initialization
	void Start () {
        if(PlayerData.instance.hp==0)
            tt.text = "참가상\n" + PlayerData.instance.score;
        else
        switch (PlayerData.instance.kill) {
            case 12: tt.text = "대상\n" + PlayerData.instance.score; break;
            case 11:case 10: tt.text = "금상\n" + PlayerData.instance.score; break;
            case 9: case 8: case 7: tt.text = "은상\n" + PlayerData.instance.score; break;
            case 6: case 5: case 4: case 3: tt.text = "금상\n" + PlayerData.instance.score; break;
            default: tt.text = "참가상\n" + PlayerData.instance.score; break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
