using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalNoteController : MonoBehaviour {

    public Transform[] lanePos;
    int Block;

    float Distance;
    float During;


    float starttime;
    float now;
    float duration;
    float arrivalTime = 0.6f;
    float generatoTime;

    float Vx;
    float Vy;
    Vector3 firstScale;
    Vector3 scale;


    public void setParameter(int block) {
        Block = block;
    }

    public void setParameterFloat(float generatoTime){
        this.generatoTime = generatoTime;
    }


    public float getGeneratoTime(){
        return generatoTime;
    }
    
    public int getBlock(){
        return Block;
    }

    // Start is called before the first frame update
    void Start() {
        starttime = Time.time;
        Vector3 pos = lanePos[getBlock()].transform.position;
        Vx = pos.x / arrivalTime;
        Vy = pos.y / arrivalTime;
        firstScale = this.gameObject.transform.localScale;
        scale = lanePos[getBlock()].transform.localScale - firstScale;
    }

    // Update is called once per frame
    void Update() {
        now = Time.time;
        duration = now - starttime;
        this.gameObject.transform.position = new Vector3(Vx * duration , Vy * duration,0);
        this.gameObject.transform.localScale = new Vector3(firstScale.x + ((scale.x/arrivalTime) * duration), firstScale.y + ((scale.x/arrivalTime) * duration), 1);
        if (duration > 2.0f) {
            Destroy(gameObject);
        }
 
    }
}
