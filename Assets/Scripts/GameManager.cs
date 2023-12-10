using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endScreen;
    public void EndGame()
    {
        endScreen.SetActive(true);
        endScreen.GetComponent<Animator>().Play("EndingScreenFade");
        StartCoroutine(EndScreen());
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0f;
    }
}
