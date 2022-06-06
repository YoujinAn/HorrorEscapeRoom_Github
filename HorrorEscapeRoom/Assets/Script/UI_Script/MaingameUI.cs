using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaingameUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.AllStop();
        SoundManager.instance.Play("MaingameBGM");
    }

}
