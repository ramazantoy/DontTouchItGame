using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bitti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void buttonbas(int a)
    {
        if (a == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (a == 1)
        {
            SceneManager.LoadScene("menu");
        }
       
    }
}
