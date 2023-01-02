using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag : MonoBehaviour
{
    public GameObject Text;
    public GameObject FinishPanel;
    private count CountKilled;
    public bool ReachedFlag;
    // Start is called before the first frame update
    void Start()
    {
        CountKilled = Text.GetComponent<count>();
        ReachedFlag  = false;
        FinishPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.tag=="iambeingattacked"){
            Debug.Log("reach the flag");
            //Debug.Log(CountKilled.cubetriangle);
            ReachedFlag  = true;
            FinishPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }
        
        
}
