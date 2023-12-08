using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3,10)]
    public string[] sentences;
}
