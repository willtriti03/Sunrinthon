using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuttoncallRight : MonoBehaviour {
    float time = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (4 > time)
            transform.Translate(Vector3.right *200 * Time.deltaTime);
    }
}
