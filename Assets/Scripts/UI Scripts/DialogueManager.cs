using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private AudioSource audioSource;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;

    void Start()
    {
        sentences = new Queue<string>();
        audioSource = GetComponent<AudioSource>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetTrigger("Open");

        audioSource.Play();

        Time.timeScale = 0f;

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
            audioSource.Stop();

            animator.ResetTrigger("Open");
            animator.SetTrigger("Close");

            Time.timeScale = 1f;
        }
    }
}
