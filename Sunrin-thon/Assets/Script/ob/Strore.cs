﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strore : MonoBehaviour {
    bool objectState = true;
    public GameObject paricle;
    public GameObject gm;
    Collider2D col;
    float time = 0, time2 = 0;
    float scale;
    bool start = false;
    int cost=5;
    // Use this for initialization

    void Start()
    {
        paricle.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            time += Time.deltaTime;

            if (time >= 1.0)
            {
                paricle.gameObject.SetActive(false);
                objectState = false;
                col.GetComponent<Player>().MoveChange(true);
                start = false;
                time = 0;
                ////////////////////////////////////////////////
                if (gm.GetComponent<GameManager>().useMoney(cost))
                {
                    gm.GetComponent<GameManager>().AddCoin(-cost);
                    gm.GetComponent<GameManager>().AddHp(1);
                    cost += 5;
                }
            }
        }
        if (!start && !objectState)
        {
            time2 += Time.deltaTime;
            if (time2 >= 20)
            {
                time2 = 0;
                objectState = true;
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && objectState)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (gm.GetComponent<GameManager>().useMoney(cost))
                    paricle.gameObject.SetActive(true);
                col.GetComponent<Player>().MoveChange(false);
                this.col = col;
                start = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                start = false;
                time = 0;
                paricle.gameObject.SetActive(false);
                col.GetComponent<Player>().MoveChange(true);
            }
        }
    }

}
