using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField] GameObject UI;
    [SerializeField] GameObject Grid;
    [SerializeField] GameObject nextLevel;

    // Update is called once per frame

    private void Start()
    {
        PlayerControllerScript._progress = false;

    }
    void Update()
    {
        if(GameObject.FindWithTag("Player")==null && Time.time>1f)
        {
            UI.SetActive(true);
            Grid.SetActive(false);
        }

        if(PlayerControllerScript._progress)
        {
            Grid.SetActive(false);
            nextLevel.SetActive(true);

        }

        if(!PlayerControllerScript._progress) {

            Grid.SetActive(true);
            nextLevel.SetActive(false);
        }
    }
}
