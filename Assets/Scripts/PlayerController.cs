using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rgdBody;
    public float heroSpeed;
    public float jumpForce;    
    bool dirToRitght = true;
    private bool onTheGround;
    public Transform groundTester;
    public LayerMask layerToTest;
    private float radius = 0.1f;
    public Transform startPoint;

    void Start()
    {
        anim = GetComponent<Animator>();
        rgdBody = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo (0).IsName("SpikeFail"))
        {
            rgdBody.velocity = Vector2.zero;
            return;
        }
            onTheGround = Physics2D.OverlapCircle(groundTester.position, radius, layerToTest);
            float horizontalMove = Input.GetAxis("Horizontal");
            rgdBody.velocity = new Vector2 (horizontalMove * heroSpeed, rgdBody.velocity.y);
            anim.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.UpArrow) && onTheGround)
        {
            rgdBody.AddForce(new Vector2(0f, jumpForce));
            anim.SetTrigger("jump");
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("shoot");
        }

        if (horizontalMove < 0 && dirToRitght)
        {
            Flip();
        }        
        
        if (horizontalMove > 0 && !dirToRitght)
        {
            Flip();
        }
    }

    void Flip ()
    {
        dirToRitght = !dirToRitght;
        Vector3 heroScale = gameObject.transform.localScale;
        heroScale.x*=-1;
        gameObject.transform.localScale = heroScale;
    }

    public void RestartHero()
    {
        gameObject.transform.position = startPoint.position;
    }
}