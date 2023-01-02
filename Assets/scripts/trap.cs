using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    private bool istrapped;
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.tag == "Player" && istrapped == false)
        {
            istrapped = true;
            GameObject hp = GameObject.Find("health2");
            hp.GetComponent<life>().DecreaseHp();
            GameObject catstand = GameObject.Find("catstand");
            AnimatorStateInfo info = catstand.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            catstand.GetComponent<Animator>().SetBool("beingattack", true);
        }
    }
    
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player" && istrapped == true)
        {
            istrapped = false;

        }
    }
}
