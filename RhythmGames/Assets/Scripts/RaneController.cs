using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaneController : MonoBehaviour {

    float PERFECT = 0.05f;
    float GOOD = 0.15f;

    private float starttime;
    float clicked_time;
    string blockName;

    float diff;

    GameObject clickedGameObject;
    public GameObject[] noteObjects;

    // Start is called before the first frame update
    void Start() {
        starttime = Time.time;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            clicked_time = Time.time;  //クリックした時刻を取得

            //クリックされた場所を取得しRayに代入する
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            //クリックしたオブジェクトの名前を取得
            if (hit2d){
                clickedGameObject = hit2d.transform.gameObject;
                blockName =　clickedGameObject.name;
            }

            //タグを使ってクリックしたノーツオブジェクトを取得する       
            try{
                noteObjects = GameObject.FindGameObjectsWithTag(blockName);

                //取得したノーツオブジェクトとタップしたオブジェクトとの距離が最短となるノーツを取得する
                float tmpDis = 0;
                float nearDis = 0;
                GameObject nearObject = null;

                foreach (GameObject i in noteObjects){
                    tmpDis = Vector3.Distance(clickedGameObject.transform.position, i.transform.position);
                    // Debug.Log(tmpDis);
                    if (nearDis == 0 || nearDis > tmpDis){
                        nearDis = tmpDis;
                        nearObject = i;
                    }
                }
                
                // クリックした時間とノーツの到着時間の差の絶対値を取る
                try{
                    Debug.Log(nearObject);
                    diff = Mathf.Abs(clicked_time - nearObject.GetComponent<NomalNoteController>().getGeneratoTime());  

                    // 差の大きさによって判定を行う。
                    if (diff <= PERFECT){
                        Debug.Log("Perfect");
                        nearObject.SetActive(false);
                    } else if(diff <= GOOD){
                        Debug.Log("Good");
                        nearObject.SetActive(false);
                    } else{
                        Debug.Log("Miss");
                    }       
                }  catch(NullReferenceException e){
                    Debug.LogWarning(e);
                }
                 
            }catch(ArgumentException e){
                Debug.LogWarning(e);
            }
        }
    }
}
