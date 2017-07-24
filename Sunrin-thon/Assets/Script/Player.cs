using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public bool moveControll = true;
    public bool super = false;
    float superTime = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
        if (super)
        {
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
                transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow) == true)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, -90f);
                transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.UpArrow) == true)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
                transform.Translate(Vector3.down * speed * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.DownArrow) == true)
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                transform.Translate(Vector3.down * speed * Time.deltaTime);

            }
        }
    }
    public void MoveChange(bool value)
    {
        moveControll = value;
    }
    public void SuperMode()
    {
        superTime = 3;
        super = true;
        ShowReady();
    }
    IEnumerator ShowReady()                  //코루틴함수 코루틴은 나중에 설명
    {
        int count = 0;
        while (count < 3)                    // 텍스트를 깜빡깜빡하게 만드는 소스
        {
            gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            count++;
        }
    }
}
