using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueParser))]
public class DatabaseManager : MonoBehaviour
{
    //[SerializeField]
    //string csv_FileName;

    //Dictionary<int, Dialogue> diagDic = new Dictionary<int, Dialogue>();

    //public bool isFinish = false;

    //#region singleton
    //private static DatabaseManager instance = null;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DialogueParser parser = GetComponent<DialogueParser>();
    //        Dialogue[] dialogues = parser.Parse(csv_FileName);

    //        for(int i = 0; i < dialogues.Length; i++)
    //        {
    //            diagDic.Add(i + 1, dialogues[i]);
    //        }

    //        isFinish = true;

    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    //public static DatabaseManager Instance => instance == null ? null : instance;

    //#endregion
   

    //public Dialogue[] GetDialogue(int _startNum, int _endNum)
    //{
    //    List<Dialogue> dialogueList = new List<Dialogue>();

    //    for(int i = 0; i <= _endNum - _startNum; i++)
    //    {
    //        dialogueList.Add(diagDic[_startNum + i]);
    //    }

    //    return dialogueList.ToArray();
    //}
}
