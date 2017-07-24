using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorCollider : MonoBehaviour {
    public int sight=1; // 1오른쪽 2위 3왼쪽 4아래

    // Use this for initialization
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && col.GetComponent<Player>().super == false){
            if (CheckSight(col)){
                
            }
        }
    }

    public bool CheckSight(Collider2D col) {
        float angle;
        Vector3 objectAngle;
        switch (sight) {
            case 1:
                objectAngle = col.transform.position- transform.position;
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
                angle = GetAngle(-1*(transform.right), objectAngle);
                if (-45 <= angle && angle <= 45)
                {
                    return true;
                }
                else return false;

            case 4:
                objectAngle = col.transform.position - transform.position;
                angle = GetAngle(-1*(transform.up), objectAngle);
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
        return  Vector3.Angle(vStart, vEnd);
   }
}