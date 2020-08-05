using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public GameObject score_object = null;
    public GameObject combo_object = null;
    //public Ranecontroller ranecontroller;
    
    float Score;
    float Combo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Text score_text = score_object.GetComponent<Text> ();
        score_text.text = "Score:" + Score.ToString();
        Text combo_text = combo_object.GetComponent<Text> ();
        combo_text.text = "Combo:" + Combo.ToString();
        //comboText.text = Combo.ToString();
    }
    public void AddScore (float plusscore)
    {
        Score = Score + plusscore;
    }
    public void AddCombo (float pluscombo)
    {
        Combo = Combo + pluscombo;
    }
}
