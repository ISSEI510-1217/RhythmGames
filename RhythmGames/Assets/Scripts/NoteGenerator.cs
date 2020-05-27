using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour {
    // Start is called before the first frame update
    public string FilePath;
    public GameObject NomalNotes;
    public Transform FirstPos;
    List<float> angle = new List<float>{-10.0f,-40.0f,-100.0f,-130.0f,-190.0f,-220.0f,-280.0f,-310.0f};

    //読み込むjsonに合わせたクラス
    [System.Serializable]
    public class InputJson{
        public string name;
        public int maxBlock;
        public float BPM;
        public int offset;
        public NotesDate[] notes;

    }
    
    [System.Serializable]
    public class NotesDate {
        public float LPB;
        public float num;
        public int block;
        public int type;
        public NotesDate[] notes;
    }

    string Title;
    float BPM;
    List<GameObject> All_Notes;


    /*
    jsonファイルのロード
    Resourcess.Loadはファイルを文字列として読み込んでいる．
    JsonNodeは，よくわからん
    foreachは，リストの中身を一つずつ読み込む
    */
    void loadjson() {
        All_Notes = new List<GameObject>();
        string jsonText = Resources.Load<TextAsset>(FilePath).ToString();
        InputJson json = JsonUtility.FromJson<InputJson>(jsonText);
        Title = json.name;
        BPM = json.BPM;
        foreach(var note in json.notes) {

            int block = note.block;
            float LPB = note.LPB;
            float num = note.num;
            int type  = note.type;
            float generatoTime = num * ((60.0f / BPM) / LPB);
            //Debug.Log(generatoTime);
            //NotesDate A_notes = note.notes
            GameObject Note;

            if(type == 1 ) {
                Note = Instantiate(NomalNotes,FirstPos.position,Quaternion.Euler(0,0,angle[block - 1 ]));
            } else {
                Note = Instantiate(NomalNotes,FirstPos.position, Quaternion.Euler(0,0,angle[block - 1 ]));
                //Debug.Log("error");
            }
            Note.GetComponent<NomalNoteController>().setParameter(type,generatoTime,block);
            All_Notes.Add(Note);
        }
    }
    void Start() {
        loadjson();
    }
}
