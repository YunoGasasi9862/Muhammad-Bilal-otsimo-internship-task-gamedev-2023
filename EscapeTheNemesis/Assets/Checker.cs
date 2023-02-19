using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Grid;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player")==null && Time.time>1f)
        {
            UI.SetActive(true);
            Grid.SetActive(false);
        }
    }
}
