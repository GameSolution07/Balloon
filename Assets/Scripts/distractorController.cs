using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distractorController : MonoBehaviour
{
    Rigidbody2D rb;

    public float Movespeed = 4f;

    bool turn = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!turn)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Movespeed * Time.fixedDeltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Movespeed * -1 * Time.fixedDeltaTime, transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bg")
        {
            if (!turn)
            {
                turn = true;
                StartCoroutine(turner());
            }
            else
            {
                turn = false;
                StartCoroutine(turner());
            }

        }
    }

    IEnumerator turner()
    {
        yield return new WaitForSeconds(1f);
        if (Movespeed < 9)
        {
            Movespeed += 1;
        }
    }


}
