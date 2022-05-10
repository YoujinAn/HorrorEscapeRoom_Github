using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region singleton
    private static GameManager instance = null;


    private void Awake()
    {
        //Cursor.visible = false;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance => instance == null ? null : instance;

    #endregion

    public bool playerCanControl = true;
    public int curDiagNum;
    public List<int> invItemIdxList;
}
