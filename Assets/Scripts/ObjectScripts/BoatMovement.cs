using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BoatMovement : MonoBehaviour
{
    public GameObject buttonLight;
    public GameObject boatParent;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            audioSource.Play();
            buttonLight.SetActive(true);
            boatParent.GetComponent<Animator>().Play("BoatSwim");
        }
    }
}
