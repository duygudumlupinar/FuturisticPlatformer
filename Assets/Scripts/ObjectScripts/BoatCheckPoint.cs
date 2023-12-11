using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCheckPoint : MonoBehaviour
{
    public GameObject Boat;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Boat.GetComponent<Animator>().Play("BoatBack");
    }
}
