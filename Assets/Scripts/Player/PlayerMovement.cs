//problem --> in pc start point is not the same as on mobile


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
	private Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed;//


    Touch touch;
    Vector3 touchPosition, whereToMove;
    private bool isMoving;

    float previousDistanceToTouchPos, currentDistanceToTouchPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        anim.SetFloat("X", whereToMove.x);//
        anim.SetFloat("Y", whereToMove.y);//
       if (isMoving)
       { 
           currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;
       }
        if (Input.touchCount > 0 )//????? touch
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began )
            {
               
                previousDistanceToTouchPos = 0;
                currentDistanceToTouchPos = 0;
                isMoving = true;
                anim.SetBool("isMoving", isMoving);//
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
               
                touchPosition.z = 0;
                anim.SetFloat("X", touchPosition.x);//
                anim.SetFloat("Y", touchPosition.y);//
                whereToMove = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(whereToMove.x * moveSpeed, whereToMove.y * moveSpeed);

            }
            //Vector2 direction = new Vector2(whereToMove.x, whereToMove.y);
        }

        if (currentDistanceToTouchPos > previousDistanceToTouchPos)//????????
        { 
            isMoving = false;
            anim.SetBool("isMoving", isMoving); // 
            StopMoving();
        }

        if (isMoving)
        { //????????   
            previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
        }
           // Debug.Log(currentDistanceToTouchPos);
          //  Debug.Log(previousDistanceToTouchPos);

    }
    private void StopMoving()//StopMoving
    {
        rb.velocity = Vector3.zero;
       

    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Animator anim;///***********************************************
    public float moveSpeed;//

    public float x, y;//
    private bool isWalking;//

    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        //??????
        x = Input.GetAxisRaw("Horizontal");//
        y = Input.GetAxisRaw("Vertical");//

        if (x != 0 || y != 0)
        {
            anim.SetFloat("X", x);//
            anim.SetFloat("Y", y);//
            if (!isWalking)//
            {
                isWalking = true;
                anim.SetBool("isMoving", isWalking);//

            }
            //
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("isMoving", isWalking); // 
                StopMoving();
            }
        }

        moveDir = new Vector3(x, y).normalized;//???????
    }

    

    private void FixedUpdate()//Movement
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }

    private void StopMoving()//StopMoving
    {
        rb.velocity = Vector3.zero;
    }
}

*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public Animator anim;///***********************************************
    public float moveSpeed;//

    public float x, y;//
    private bool isWalking;//

    private Vector3 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        //??????
        x = Input.GetAxisRaw("Horizontal");//
        y = Input.GetAxisRaw("Vertical");//
        
        if (x != 0 || y != 0)
        {
            anim.SetFloat("x", x);//
            anim.SetFloat("y", y);//
            if (!isWalking)//
            {
                isWalking = true;
                anim.SetBool("isMoving", isWalking);//

            }
        //
        }else
        {
            if (isWalking)
            {
                isWalking = false;
                anim.SetBool("isMoving", isWalking); // 
                StopMoving();
            }
        }

            moveDir = new Vector3(x, y).normalized;//???????
        }

       

        private void FixedUpdate() {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
        }

        private void StopMoving()
        {
            rb.velocity = Vector3.zero;        
        }
    }*/


