using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed= 1.0f;
    bool moveControll = true;
    public bool super=false;
    float superTime = 3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveControl();
        if (super) {
            superTime -= Time.deltaTime;
            if (superTime <= 0)
                super = false;
        }
	}
    void MoveControl()
    {
        if (moveControll)
        {
            if (Input.GetKey(KeyCode.RightArrow) == true)
            {
                transform.Translate(-Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) == true)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.UpArrow) == true)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.DownArrow) == true)
            {
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
    }
    public void MoveChange() {
        moveControll = !moveControll;
    }
    public void SuperMode() {
        super = true;
    }
}
