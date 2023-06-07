using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    public bool isSliding = false;
    public bool coolDown = true;

    public Rigidbody2D rb;
    public Animator anim;

    public BoxCollider2D regularCollide;
    public BoxCollider2D slideCollider;

    public float slideSpeed = 5f;
    [SerializeField] private SpriteRenderer playerSprite;

    private void Start()
    {
        anim= GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown (KeyCode.LeftShift) && coolDown)
        {
            preformSlide();
            StartCoroutine("CoolDown");
        }
    }

    private void preformSlide()
    {
        isSliding = true;
        anim.SetBool("IsSlide", true);

        regularCollide.enabled = false;
        slideCollider.enabled = true;

        if (!playerSprite.flipX)
        {
            rb.AddForce(Vector2.right * slideSpeed);
            

        }
        else
        {
            rb.AddForce(Vector2.left * slideSpeed);
            
        }
        StartCoroutine("StopSlide");
    }

    IEnumerator StopSlide()
    {
        yield return new WaitForSeconds(0.0f);
        anim.Play("NewState");
        anim.SetBool("IsSlide", false);
        regularCollide.enabled = true;
        slideCollider.enabled = false;
        isSliding= false;
    }

    private IEnumerator CoolDown()
    {
        coolDown= false;
        yield return new WaitForSeconds(1.0f);
        coolDown = true;
    }
}
