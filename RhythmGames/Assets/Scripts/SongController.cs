using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongController : MonoBehaviour {
    AudioSource Music;
    public string ClipPath;

    //Start is called before the first frame update
    void Start() {
        Music = this.GetComponent<AudioSource>();
        Music.clip = (AudioClip)Resources.Load(ClipPath);
        Music.Play();
    }
    void Update()
    {
        if (!Music.isPlaying)
        {
            SceneManager.LoadScene("result");
        }
    }
}
