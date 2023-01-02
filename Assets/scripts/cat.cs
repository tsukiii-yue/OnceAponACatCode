using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class cat : MonoBehaviour
{
    private Rigidbody2D myRigidbody; 
    private Animator myAnimator;
    public Animator catAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool attack;
    private bool facingRight;
    [SerializeField]
    private Transform[] groundpoints;

    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;
    private bool jump;
    [SerializeField]
    private float jumpForce;
    public Vector3 positionrec;
    private Vector3 flashposrec;
    [SerializeField]
    GameObject echo;
    [SerializeField]
    GameObject echoLeft;
    private bool flashcd;
    GameObject cdcircle;




    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        catAnimator = GetComponent<Animator>();
        this.transform.position = new Vector3(-5.1f,7,-2f);
        positionrec = new Vector3(-5.1f, 7, -2f);
        flashcd = true;
        GameObject trail = GameObject.Find("Trail");
        trail.GetComponent<TrailRenderer>().startWidth = 0;

    }

    void Update()
    {
        HandleInput();
        AnimatorStateInfo info = myAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.IsTag("revive") && info.normalizedTime > 1f) {
            myAnimator.SetBool("revive", false);
        }
        if (info.IsTag("beingattack") && info.normalizedTime > 1f)
        {
            myAnimator.SetBool("beingattack", false);
        }

        if (transform.position.y < -20)
        {
            
            this.transform.position = new Vector3(positionrec.x, positionrec.y, positionrec.z);
            myAnimator.SetBool("revive", true);
            GameObject hp = GameObject.Find("health2");
            hp.GetComponent<life>().DecreaseHp();
            
           
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)&&flashcd==true)
        {
            flashposrec = this.transform.position;
            cdcircle = GameObject.Find("button2");
            cdcircle.GetComponent<Image>().fillAmount -= 1;
            flashcd = false;
            if (facingRight)
            {
                for (int i = 0; i < 7; i++)
                {
                    GameObject Instance = (GameObject)Instantiate(echo, flashposrec, this.transform.rotation);
                    flashposrec += new Vector3(2, 0, 0);
                    Destroy(Instance, 0.5f);
                    
                }
                this.transform.position += new Vector3(12, 0, 0);
            }
            if (!facingRight) {
                for (int i = 0; i < 7; i++)
                {
                    GameObject Instance = (GameObject)Instantiate(echoLeft, flashposrec, this.transform.rotation);
                    flashposrec += new Vector3(-2, 0, 0);
                    Destroy(Instance, 0.5f);
                    
                }
                this.transform.position += new Vector3(-12, 0, 0);
            }
           
        }
        
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsGrounded();
        HandleMovement(horizontal);
        Flip(horizontal);
        HandleAttacks();
        HandleLayers();
        ResetValues();
        cdcirclefilled();

    }

    private void HandleMovement(float horizontal){

        if (myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true);
            this.myRigidbody.gravityScale = 5;
        }
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("catattack") )
        {
            if (!isGrounded)
            {
                this.myRigidbody.velocity = new Vector2(horizontal * 10, myRigidbody.velocity.y);
                
            }
            else {
                this.myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
            }
            
        }
        if (isGrounded && jump) {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("Jump");
            GameObject trail = GameObject.Find("Trail");
            trail.GetComponent<TrailRenderer>().startWidth = 0.47f;

        }
        if (isGrounded) {
            GameObject trail = GameObject.Find("Trail");
            trail.GetComponent<TrailRenderer>().startWidth = 0;
        }
        
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));


            

    }

    private void HandleAttacks(){
        if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("catattack") && isGrounded == true) {
            myAnimator.SetTrigger("attack");
            myRigidbody.velocity = Vector2.zero;
        }
    }

    private void HandleInput() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            jump = true;
        }
        if (Input.GetMouseButtonDown(0)) {
            attack = true;
        }
        

    }

    private void Flip(float horizontal){
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    private void ResetValues() {
        attack = false;
        jump = false;
        if (this.myRigidbody.velocity.y >= 0)
        {
            this.myRigidbody.gravityScale = 5;
        }
        

    }

    private bool IsGrounded() {
        if (myRigidbody.velocity.y <= 0) {
            foreach (Transform point in groundpoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i=0;i<colliders.Length;i++) {
                    if (colliders[i].gameObject != gameObject) {
                        myAnimator.ResetTrigger("Jump");
                        myAnimator.SetBool("land", false);

                        return true;
                    }
                }
            }
        }
        return false;
    }


    private void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else {
            myAnimator.SetLayerWeight(1, 0);
        }
    }

    
    void OnTriggerStay2D(Collider2D coll)
    {

        if (coll.tag == "checkpoint")
        {
            positionrec = this.transform.position;
            
        }
        
    }

    

    void cdcirclefilled() {
        cdcircle = GameObject.Find("button2");
        if (flashcd == false) {
            cdcircle.GetComponent<Image>().fillAmount += 0.01f;
        }
        if (cdcircle.GetComponent<Image>().fillAmount == 1) {
            flashcd = true;
        }
    }

    
}
