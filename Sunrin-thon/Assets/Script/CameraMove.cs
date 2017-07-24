using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public GameObject player;       //Public variable to store a reference to the player game object

    public AudioClip soundExplosion;    //사운드 파일을 가진다
    AudioSource audio;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.loop = true;
        audio.clip = soundExplosion;
        audio.Play();
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
        MoveLimit();

    }
    void MoveLimit() {
        Vector3 temp;
        temp.x = Mathf.Clamp(transform.position.x, -3.54f, 3.54f);
        temp.y = Mathf.Clamp(transform.position.y, -14.85f, 14.85f);
        temp.z = -10f;
        transform.position = temp;
    }

}