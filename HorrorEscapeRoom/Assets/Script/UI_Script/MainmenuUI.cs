using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.AllStop();
        SoundManager.instance.Play("MainmenuBGM");
    }
    
    public void StartOpening()
    {
        SoundManager.instance.Play("Button");
        GameManager.Instance.ChangeScene("Opening");
    }

}
