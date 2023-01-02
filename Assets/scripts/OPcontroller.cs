using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OPcontroller : MonoBehaviour
{
    public VideoPlayer vid;
    // Start is called before the first frame update
    void Start()
    {
        vid.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("menu");
        }
    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("Video Over");
        SceneManager.LoadScene("menu");
    }
    
}
