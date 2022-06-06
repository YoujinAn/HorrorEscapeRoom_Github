using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.AllStop();
        SoundManager.instance.Play("OpeningBGM");
        Invoke("StartGame", 3.0f);
    }

    public void StartGame()
    {
        GameManager.Instance.ChangeScene("1_Room");
    }
}
