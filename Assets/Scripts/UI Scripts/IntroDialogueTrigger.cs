using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroDialogueTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
        gameObject.SetActive(false);
    }
}
