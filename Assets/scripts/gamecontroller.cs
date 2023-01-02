using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour
{
    private int i;
    [SerializeField] GameObject intro0;
    [SerializeField] GameObject intro1;
    [SerializeField] GameObject intro2;
    [SerializeField] GameObject intro3;
    [SerializeField] GameObject intro4;
    
        // Start is called before the first frame update
    void Start()
    {
        i = 0;
        intro0.SetActive(true);
        intro1.SetActive(false);
        intro2.SetActive(false);
        intro3.SetActive(false);
        intro4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetMouseButtonDown(0))
            {   
                i++;
                if(i==1){
                    intro0.SetActive(false);
                    intro1.SetActive(true);
                    intro2.SetActive(false);
                    intro3.SetActive(false);
                    intro4.SetActive(false);
                }
                else if(i==2){
                    intro0.SetActive(false);
                    intro1.SetActive(false);
                    intro2.SetActive(true);
                    intro3.SetActive(false);
                    intro4.SetActive(false);
                }
                else if(i==3){
                    intro0.SetActive(false);
                    intro1.SetActive(false);
                    intro2.SetActive(false);
                    intro3.SetActive(true);
                    intro4.SetActive(false);
                }
                else if(i==4){
                    intro0.SetActive(false);
                    intro1.SetActive(false);
                    intro2.SetActive(false);
                    intro3.SetActive(false);
                    intro4.SetActive(true);
                }
                else if(i==5){
                    intro0.SetActive(false);
                    intro1.SetActive(false);
                    intro2.SetActive(false);
                    intro3.SetActive(false);
                    intro4.SetActive(false);
                    SceneManager.LoadScene("SampleScene");
                }
                
                
            }        
        
        
        
        
    }
}
