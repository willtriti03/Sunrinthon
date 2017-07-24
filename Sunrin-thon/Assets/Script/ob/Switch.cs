using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    bool objectState = true;
    public GameObject paricle;
    public GameObject blackout;
    Collider2D col;
    public GameObject[] team = new GameObject[12];
    float time = 0, time2 = 0;
    float scale;
    bool start = false;
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
                for (int i = 0; i < 12; ++i)
                    team[i].GetComponent<Team>().AddHealth(-5);
                blackout.GetComponent<light>().TurnOn();
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