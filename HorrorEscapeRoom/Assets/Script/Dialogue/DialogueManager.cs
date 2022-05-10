using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("Can modify value")]
    public float typingSpeed = 0.1f;
    // conversation array
    [Header("Conversations")]
    public Conversation[] convs;

    // for function data value
    [Header("Don't modify this value")]
    public Text dialogue;
    public GameObject diagWindow;
    public Button nextButton;

    // private value
    public Conversation curConversation;
    private Conversation prevConversation;
    private int curIndex;
    private int prevIndex;
    private Coroutine typing;
    private bool isTyping;
    private bool isSkip;

    #region singleton
    private static DialogueManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            diagWindow.SetActive(false);
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static DialogueManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    #endregion

    public void StartConversation(int convNum)
    {
        GameManager.Instance.playerCanControl = false;
        diagWindow.SetActive(true);
        // init
        curConversation = convs[convNum];
        curIndex = 0;
        dialogue.text = "";
        nextButton.enabled = true;
        // start dialogue
        ReadNext();
    }

    private void Update()
    {
        if (!GameManager.Instance.playerCanControl)
        {
            // for skip function
            if (Input.GetMouseButtonDown(0) && isTyping)
            {
                isSkip = true;
            }
        }
    }

    // next dialogue
    public void ReadNext()
    {
        //Debug.Log("curIndex :" + curIndex);
        //Debug.Log("length :" + curConversation.GetLength());
        //Debug.Log("conversation :" + curConversation.allLines.Length);

        // when dialogue is end, close window
        if (curIndex > curConversation.GetLength())
        {
            CloseDialogueWindow();
        }

        // typing function
        DialogueTyping();
        // index increase
        curIndex++;
        // active next button
        if (curIndex >= curConversation.GetLength())
        {
            nextButton.gameObject.SetActive(true);
        }
        
    }

    private void DialogueTyping()
    {
        // print the conversation text
        if (typing == null)
        {
            // typing text dialogue
            typing = StartCoroutine(TypeText(curConversation.GetLineByIndex(curIndex).dialogue[0]));
        }
        else
        {
            StopCoroutine(typing);
            typing = null;
            {
                typing = StartCoroutine(TypeText(curConversation.GetLineByIndex(curIndex).dialogue[0]));
            }
        }
    }

    public void CloseDialogueWindow()
    {
        prevConversation = curConversation;
        prevIndex = curIndex;

        curIndex = 0;

        diagWindow.SetActive(false);
        nextButton.enabled = false;
        GameManager.Instance.playerCanControl = true;
        return;
    }

    // typing function
    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        isTyping = true;

        yield return new WaitForSeconds(0.01f);
        for (int i = 0; i <= text.Length; i++)
        {
            nextButton.gameObject.SetActive(false);
            dialogue.text = text.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);

            // dialogue line end
            if (i == text.Length)
            {
                nextButton.gameObject.SetActive(true);
                isTyping = false;
            }

            // skip function
            if (isSkip)
            {
                nextButton.gameObject.SetActive(true);
                dialogue.text = "";
                dialogue.text = text;
                i = text.Length + 1;
                isSkip = false;
                isTyping = false;
                StopCoroutine(typing);
            }
        }
    }
}
