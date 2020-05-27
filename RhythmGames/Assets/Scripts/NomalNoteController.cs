using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalNoteController : MonoBehaviour {

    public Transform[] lanePos;
    int Type;
    float GeneratoTime;
    int Block;

    float Distance;
    float During;
    bool isGo;
    float GoTime;


    float starttime;
    float now;
    float duration;
    float arrivalTime = 0.6f;

    float Vx;
    float Vy;
    Vector3 firstScale;
    Vector3 scale;


    public void setParameter(int type, float generatoTime, int block) {
        Type = type;
        GeneratoTime = generatoTime;
        Block = block;
    }

    public int getType() {
        return Type;
    }
    
    public float getGeneratoTime() {
        return GeneratoTime;
    }

    public int getBlock(){
        return Block;
    }

    public void go(float distance, float during) {
        Distance = distance;
        During = during;
    }

    // Start is called before the first frame update
    void Start() {
        starttime = Time.time;
        Vector3 pos = lanePos[getBlock() - 1].transform.position;
        Vx = pos.x / arrivalTime;
        Vy = pos.y / arrivalTime;
        firstScale = this.gameObject.transform.localScale;
        scale = lanePos[getBlock() - 1].transform.localScale - firstScale;
        
        //Debug.Log(Vx);
    }

    // Update is called once per frame
    void Update() {
        now = Time.time;
        duration = now - starttime;
        GoTime = duration - GeneratoTime + arrivalTime;
        if (GoTime > 0 ) {
            Debug.Log(GoTime);
            this.gameObject.transform.position = new Vector3(Vx * Mathf.Abs(GoTime) , Vy * Mathf.Abs(GoTime),0);
            this.gameObject.transform.localScale = new Vector3(firstScale.x + ((scale.x/arrivalTime)* Mathf.Abs(GoTime)), firstScale.y + ((scale.x/arrivalTime)* Mathf.Abs(GoTime)), 1);
        }
        
    }
}
