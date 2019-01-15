using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PerformanceTester : MonoBehaviour {


    public GameObject chunk;
    public int index = 0;

    public int currentObjects;
    public Text text;

    private void Start()
    {
        currentObjects = UnityEngine.Object.FindObjectsOfType<Transform>().Length;
        text.text = "Current GameObjects : " + currentObjects;


    }

}
