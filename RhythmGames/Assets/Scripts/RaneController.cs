using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RaneController : MonoBehaviour {
    public AudioClip PerfectSound;
    public AudioClip GoodSound;

    AudioSource audioSource;

    float PERFECT = 0.05f;
    float GOOD = 0.15f;

    float Score;
    float Combo;
    //public Text ScoreText;

    private float starttime;
    float clicked_time;
    string blockName;

    float diff;

    GameObject clickedGameObject;
    public GameObject[] noteObjects;

    // Start is called before the first frame update
    void Start() {
        starttime = Time.time;
        audioSource = GetComponent<AudioSource>();
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
                    float plusScore = 0;
                    float comboCount = 0;

                    // 差の大きさによって判定を行う。
                    if (diff <= PERFECT){
                        audioSource.PlayOneShot(PerfectSound);
                        plusScore = 300;
                        comboCount = 1;
                        FindObjectOfType<ScoreManager>().AddScore(300);
                        FindObjectOfType<ScoreManager>().AddCombo(1);
                        Debug.Log("Perfect");
                        nearObject.SetActive(false);
                    } else if(diff <= GOOD){
                        audioSource.PlayOneShot(GoodSound);
                        plusScore = 100;
                        comboCount = 1;
                        FindObjectOfType<ScoreManager>().AddScore(100);
                        FindObjectOfType<ScoreManager>().AddCombo(1);
                        Debug.Log("Good");
                        nearObject.SetActive(false);
                    } else{
                        plusScore = 0;
                        comboCount = 0;
                        FindObjectOfType<ScoreManager>().AddScore(0);
                        FindObjectOfType<ScoreManager>().AddCombo(1);
                        Debug.Log("Miss");
                    }   
                    Score += plusScore;
                    Combo += comboCount;
                    Debug.Log(Score);
                    Debug.Log(Combo);
                    //ScoreText.text = Score.ToString();    
                }  catch(NullReferenceException e){
                    Debug.LogWarning(e);
                }
                 
            }catch(ArgumentException e){
                Debug.LogWarning(e);
            }
        }
    }
}
