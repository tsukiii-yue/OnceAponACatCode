using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class life : MonoBehaviour
{
    public string deadretry;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void DecreaseHp()
    {
        this.GetComponent<Image>().fillAmount -= 0.2f;
        if (this.GetComponent<Image>().fillAmount <0.2f)
        {
            SceneManager.LoadScene(deadretry);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
