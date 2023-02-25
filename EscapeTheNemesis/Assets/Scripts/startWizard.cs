using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startWizard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Animator>().SetBool("isRun", true);
    }

    
}
