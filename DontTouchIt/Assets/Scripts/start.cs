using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
    public Text t;

    // Start is called before the first frame update
    void Start()
    {
        t.text = "" + PlayerPrefs.GetFloat("topskor");
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
        else if(a==1)
        {
            Application.Quit();
        }
        else if (a == 2)
        {
            SceneManager.LoadScene("menu");
        }
        else if (a == 3)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
