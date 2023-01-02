using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class scoreboard : MonoBehaviour
{
    private count CountKilled;
    private int get_score;
    [SerializeField] 
    private int full_score;
    public GameObject scoreboardtext;
    [SerializeField] 
    private Text score;
    public bool first_star;
    public bool second_star;
    public bool third_star;
    public flag flagscript;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public Sprite starLight;
    public Sprite star0;

    // Start is called before the first frame update
    void Start()
    {
        
        CountKilled = scoreboardtext.GetComponent<count>();
        first_star = false;
        second_star = false;
        third_star = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flagscript.ReachedFlag==true){
            flagscript.ReachedFlag=false;
            score.text = CountKilled.cubetriangle + "/" + full_score;
            get_score = CountKilled.cubetriangle;
            //Debug.Log(full_score/3);
            //Debug.Log(full_score/3*2);
            //Debug.Log(full_score/3*3);
            if(get_score>0&&get_score<(full_score/3*2)){
                first_star = true;
                second_star = false;
                third_star = false;
            }else if(get_score>=(full_score/3*2)&&get_score<full_score){
                first_star = true;
                second_star = true;
                third_star = false;
            }else if(get_score==full_score){
                first_star = true;
                second_star = true;
                third_star = true;
            }
            if(first_star == true){
                star1.GetComponent<Image>().sprite = starLight;
            }else{
                star1.GetComponent<Image>().sprite = star0;
            }
            if(second_star == true){
                star2.GetComponent<Image>().sprite = starLight;
            }else{
                star2.GetComponent<Image>().sprite = star0;
            }
            if(third_star == true){
                star3.GetComponent<Image>().sprite = starLight;
            }else{
                star3.GetComponent<Image>().sprite = star0;
            }    
            
        }
        

        
        
    }
    
}
