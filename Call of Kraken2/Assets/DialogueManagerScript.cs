using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerScript : MonoBehaviour
{
    public bool Talk; 
    public Text nameText;
    public Text DialogText;
    public DialogScript dialog;
    private Queue<string> senteces;
    public Animator anim;
    public SceneTransitionAnimationScript nextScene;
    bool CallOnce;
    bool End;
    public bool Lol;
    public DialogueManagerScript OtherDialog;

    // Start is called before the first frame update
    void Start()
    {
        CallOnce = true;
        End = true;
        senteces = new Queue<string>();
        if(Talk == true)
        {
            StartDialogue(dialog);
        }

        Lol = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallDialog()
    {
        
        if(CallOnce == true)
        { 
            CallOnce = false;
            StartDialogue(dialog);
        }
    }

    public void StartDialogue(DialogScript dialogue)
    {
        anim.SetBool("isOpen", true);
        Debug.Log("StartingConversation");
        senteces.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            senteces.Enqueue(sentence);
        }
        DisplaynextSentence();
    }

    public void DisplaynextSentence()
    {
        if(senteces.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = senteces.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        if(!End)
        {
            anim.SetBool("isOpen", false);
            Lol = false;
        }
        else
        {
            Lol = true;
            nextScene.ChangeScene();
          
        }
    }

    public void ChangeEnd()
    {
        End = false;
        if(ProjectMaster.IActMissionNumber == 29)
        {
            ProjectMaster.IActMissionNumber = 30;
        }
    }

    public void ContinueDialog()
    {
        if(!Lol)
        {
            OtherDialog.CallDialog();
        }
    }   

}
