using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroDialogueTrigger : MonoBehaviour
{
    public FriendEnemy friendEnemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<DialogueTrigger>().TriggerDialogue();
        friendEnemy.Attack();
        gameObject.SetActive(false);
    }
}
