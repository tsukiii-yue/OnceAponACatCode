using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class count : MonoBehaviour
{
    private Text m_MyText;
    public int cubetriangle;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        cubetriangle = 0;
        m_MyText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_MyText.text = cubetriangle + "/" + num;
        
    }
}
