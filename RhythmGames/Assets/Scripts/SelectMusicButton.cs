using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;



public class SelectMusicButton : MonoBehaviour {
    public Text targetText;
    private AudioSource audioSource;
    void Start() {
        try{
        audioSource = gameObject.AddComponent<AudioSource>();
        this.targetText.text = Resources.Load("Charts/ahurea/ahurea_music").ToString();
        }catch(NullReferenceException e){
            Debug.Log(e);
        }
    }
    

    public void OnClickSelectButton()
    {
        SceneManager.LoadScene("pineScene");
    }

}

