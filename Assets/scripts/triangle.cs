using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triangle : MonoBehaviour
{
    int T;
    private Rigidbody2D myRigidbody;
    private Collider2D myCollider2D;
    private Animator myAnimator;
    private bool Isalive;
    private bool Isattacked;
    private bool facingRight;


    // Start is called before the first frame update
    void Start()
    {
        T = 0;
        myAnimator = GetComponent<Animator>();
        Isalive = true;
        Isattacked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Isalive)
        {
            if (T < 100)
            {
                this.transform.position = transform.position + new Vector3(0.15f, 0, 0);
                T++;
            }
            else if (T >= 100 && T <= 198)
            {
                this.transform.position = transform.position + new Vector3(-0.15f, 0, 0);
                T++;
            }
            else if (T == 199)
            {
                this.transform.position = transform.position + new Vector3(-0.15f, 0, 0);
                T = 0;
            }
        }
        if (!Isalive)
        {
            this.transform.position = transform.position + new Vector3(0, -0.5f, 0);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void Update()
    {
        if (Isattacked && Input.GetKeyDown(KeyCode.Mouse0))
        {
            myAnimator.SetTrigger("killed");
            Isalive = false;
            Debug.Log("killed");
            GameObject count = GameObject.Find("Text");
            count.GetComponent<count>().cubetriangle++;
        }
        if (this.transform.position.y <= -17)
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "iambeingattacked")
        {
            GameObject hp = GameObject.Find("health2");
            hp.GetComponent<life>().DecreaseHp();
            GameObject catstand = GameObject.Find("catstand");
            AnimatorStateInfo info = catstand.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
            catstand.GetComponent<Animator>().SetBool("beingattack", true);
        }
        if (coll.tag == "attackpoint")
        {
            Isattacked = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "attackpoint")
        {
            Isattacked = false;
        }
    }
}
