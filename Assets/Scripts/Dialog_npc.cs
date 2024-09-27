using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialog_npc : MonoBehaviour
{
    public GameObject player;
    public Dialogue[] dialogues;
    public bool conv_started = false;
    public bool conv_finished = true;
    public DIalogue_Manager Dialogue_manager;

    public void TriggerDialogue()
    {
        Dialogue_manager.StartDialogue(dialogues[PlayerPrefs.GetInt("Dialogue")]);
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
        if (!conv_started)
        {
            if (PlayerPrefs.GetInt("Dialogue") == 0)
            {
                CorrectNumber();
            }
            TriggerDialogue();
            conv_started = true;
        }
        if (Mathf.Abs(player.transform.position.x - transform.position.x) < 3 )
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (PlayerPrefs.GetInt("Dialogue") == 4)
                {
                    SceneManager.LoadScene(0);
                }
                conv_finished = Dialogue_manager.finished;
                if (!conv_finished)
                {
                    Dialogue_manager.DisplayNextSentence();
                    conv_finished = Dialogue_manager.finished;
                }
                else
                {
                    TriggerDialogue();
                    conv_started = true;
                    conv_finished = false;
                }
            }
        }

        if(conv_finished)
        {
            player.GetComponent<Movement>().CanMove= true;
        }
        else
        {
            player.GetComponent<Movement>().CanMove = false;

        }
    }

    private void CorrectNumber()
    {
        string[] split_sentence = dialogues[0].sentences[0].Split(new char[] { '#', '.' });
        split_sentence[1] = (PlayerPrefs.GetInt("Deaths") + 1).ToString();
        string whole_sentence = "";
        foreach (string sentence in split_sentence)
        {
            whole_sentence += sentence;
        }
        dialogues[0].sentences[0] = whole_sentence;
    }
}
