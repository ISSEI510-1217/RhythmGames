using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;



public class SelectMusicButton : MonoBehaviour {
    public Text targetText;
    private AudioSource audioSource;
    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        this.targetText.text = Resources.Load("Charts/ahurea/ahurea_music").ToString();
    }
    

    public void OnClickSelectButton()
    {
        SceneManager.LoadScene("pineScene");
    }

}

