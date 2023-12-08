using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetTrigger("Open");

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string  sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplaySentences();
    }

    public void DisplaySentences()
    {
        if (sentences.Count > 0)
        {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }
        else if (sentences.Count == 0)
        {
            animator.ResetTrigger("Open");
            animator.SetTrigger("Close");
        }
    }
}
