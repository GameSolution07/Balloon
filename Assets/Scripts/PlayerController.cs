using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject pinPrefab;
    public GameObject balloon;

    public Transform shootPos;

    Animator anim;

    public AudioSource audioSource;
    public AudioClip shoot;

    Rigidbody2D rb;

    Vector2 MovementInput;

    public float Movespeed = 8f;
    private float sizeBall = 1;
    private float balloonSpeed = 5;

    bool attackStarted;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        int ra = Random.Range(0, 2);
        if (ra == 0)
        {
            balloonSpeed = PlayerPrefs.GetInt("speed", 5);
            Vector2 dir = new Vector2(-balloonSpeed, 1);
            balloon.GetComponent<Rigidbody2D>().velocity = dir;
        }
        else if (ra == 1)
        {
            balloonSpeed = PlayerPrefs.GetInt("speed", 5);
            Vector2 dir = new Vector2(balloonSpeed, 1);
            balloon.GetComponent<Rigidbody2D>().velocity = dir;
        }

        StartCoroutine(droppallow());
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput.x = Input.GetAxisRaw("Horizontal");
        MovementInput.y = Input.GetAxisRaw("Vertical");
        if (MovementInput != null)
        {
            if (MovementInput.x > 0)
            {
                //anim.Play("RunRightLeft");
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (MovementInput.x < 0)
            {
                //anim.Play("RunRightLeft");
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (MovementInput.y > 0)
            {
                //anim.Play("Run");
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (MovementInput.y < 0)
            {
                //anim.Play("RunDown");
                transform.localScale = new Vector3(1, 1, 1);
            }
            rb.MovePosition(rb.position + MovementInput * Movespeed * Time.fixedDeltaTime);

        }
        if (MovementInput.y == 0 && MovementInput.x == 0 && !attackStarted) 
        {
            //anim.Play("Idle");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject a = Instantiate(pinPrefab, shootPos.position, Quaternion.identity);
            if (transform.localScale.x > 0)
            {
                a.transform.Rotate(0, 0, 135);
                a.GetComponent<Rigidbody2D>().velocity = new Vector3(25, 0, 0);
            }
            else
            {
                a.transform.Rotate(0, 0, -45);
                a.GetComponent<Rigidbody2D>().velocity = new Vector3(-25, 0, 0);
            }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
           
        }

        if (collision.gameObject.tag == "Switch")
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Taker")
        {
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            
        }

    }

    IEnumerator droppallow()
    {
        yield return new WaitForSeconds(10f);
        if (sizeBall < 2.6f)
        {
            sizeBall += 0.2f;
        }
        else
        {
            PlayerPrefs.SetInt("Player" + PlayerPrefs.GetInt("id", 0), PlayerPrefs.GetInt("Score", 0));
            int id = PlayerPrefs.GetInt("id", 0);
            id += 1;
            PlayerPrefs.SetInt("id", id);
        }
        balloon.transform.localScale = new Vector3(sizeBall, sizeBall, 1);
        StartCoroutine(droppallow());
    }
}
