using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objects : MonoBehaviour
{
    bool objectState = true;
    public Slider gage;
    public Camera camera;
    Collider2D col;
    float time = 0,time2=0;
    float scale;
    bool start = false;
    // Use this for initialization

    void Start()
    {
     gage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            time += Time.deltaTime;
            Debug.Log(time);
            if (time <= 1) {
                gage.value = 1-time;
            }
               
            if (time >= 1.0)
            {
                gage.gameObject.SetActive(false);
                objectState = false;
                col.GetComponent<Player>().MoveChange(true);
                start = false;
                time = 0;
            }
        }
        if (!start && !objectState) {
            time2 += Time.deltaTime;
            if (time2 >= 20) {
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
                gage.gameObject.SetActive(true);
                gage.transform.position =camera.WorldToScreenPoint(new Vector3(transform.localPosition.x, transform.localPosition.y+1, transform.localPosition.z)); 
                col.GetComponent<Player>().MoveChange(false);
                this.col = col;
                start = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                start = false;
                time = 0;
                gage.gameObject.SetActive(false);
                col.GetComponent<Player>().MoveChange(true);
            }
        }
    }

}
