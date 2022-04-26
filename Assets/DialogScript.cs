using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogScript : MonoBehaviour
{

    public string sentence;
    [TextArea(3,10)]
    public string[] sentences;
}
