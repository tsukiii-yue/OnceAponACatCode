using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {

        Debug.Log("GoToNextLevel");
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;



    }
}
