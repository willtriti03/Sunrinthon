using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour {
    float time = 0;
    float time2 = 0,time3=0;
    public int percent=1000;
    public float speed = 5.0f;
    bool move = false;
    public GameObject range;
    public GameObject gm,mark;
    
    int[] log = new int[8];
    int[] log2 = new int[8];
    int cnt = 0 ,rcnt=0;
    public int sight = 4;
    Vector3 pos;
    // Use this for initialization
    void Start () {
        pos = transform.position;
        mark.gameObject.SetActive(false);
        range.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (!move)
        {
            time += Time.deltaTime;
            if (time >= 1f)
            {
                int rd = Random.Range(1, percent);
                if (1==rd)   
                {
                    move = true;
                    range.gameObject.SetActive(true);

                    for (int i = 0; i < 8; ++i)
                    {

                        log[i] = Random.Range(1, 4);
                        log2[i] = Random.Range(1, 2);
                    }
                    time = 0;
                }
            }
        }
        if (move) {
            time2 += Time.deltaTime;
            if (log2[cnt] > time2)
            {
                switch (log[cnt])
                {
                    case 1:
                        transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                        transform.Translate(Vector3.down * speed * Time.deltaTime);
                        break;
                    case 2:
                        transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                        transform.Translate(Vector3.down * speed * Time.deltaTime);
                        break;
                    case 3:
                        transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                        transform.Translate(Vector3.down * speed * Time.deltaTime);

                        break;
                    case 4:
                        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                        transform.Translate(Vector3.down * speed * Time.deltaTime);
                        break;
                }
                MoveLimit();
            }
           else
            {
                time2 = 0;
                cnt++;
            }

            if (cnt == 8)
            {
                cnt = 0;
                move = false;
                transform.position = pos;
                mark.gameObject.SetActive(false);
                range.gameObject.SetActive(false);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "wall"){
            log[cnt]++;
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && col.GetComponent<Player>().super == false && move && col.GetComponent<Player>().moveControll==false)
        {
            if (CheckSight(col))
            {
                time3++;
                mark.gameObject.SetActive(true);
                gm.GetComponent<GameManager>().AddHp(-1);
                col.GetComponent<Player>().SuperMode();
                speed = 0;
                cnt = 0;
                if (time3 >= 2) {
                    speed = 5;
                    cnt = 0;
                    move = false;
                    transform.position = pos;
                    mark.gameObject.SetActive(false);
                    range.gameObject.SetActive(false);

                }
            }
        }
    }

    public bool CheckSight(Collider2D col)
    {
        float angle;
        Vector3 objectAngle;
        switch (log[cnt])
        {
            case 1:
                objectAngle = col.transform.position - transform.position;
                angle = GetAngle(transform.right, objectAngle);
                if (-45 <= angle && angle <= 45)
                {
                    return true;
                }
                else return false;
            case 2:
                objectAngle = col.transform.position - transform.position;
                angle = GetAngle(transform.up, objectAngle);
                if (-45 <= angle && angle <= 45)
                {
                    return true;
                }
                else return false;
            case 3:
                objectAngle = col.transform.position - transform.position;
                angle = GetAngle(-1 * (transform.right), objectAngle);
                if (-45 <= angle && angle <= 45)
                {
                    return true;
                }
                else return false;

            case 4:
                objectAngle = col.transform.position - transform.position;
                angle = GetAngle(-1 * (transform.up), objectAngle);
                if (-45 <= angle && angle <= 45)
                {
                    return true;
                }
                else return false;
            default:
                return false;
        }
    }

    public float GetAngle(Vector3 vStart, Vector3 vEnd)
    {
        return Vector3.Angle(vStart, vEnd);
    }
    void MoveLimit()
    {
        Vector3 temp;
        temp.x = Mathf.Clamp(transform.position.x, -12f, 12f);
        temp.y = Mathf.Clamp(transform.position.y, -19f,19f);
        temp.z = -1f;
        transform.position = temp;
    }
}
