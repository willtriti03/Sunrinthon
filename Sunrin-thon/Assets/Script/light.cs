using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    bool turn = false;
    float time = 0;
    // Use this for initialization
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (turn)
        {
            time += Time.deltaTime;
            if (time >= 5)
            {
                turn = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void TurnOn()
    {
        time = 0;
        gameObject.SetActive(true);
        turn = true;
    }
}
