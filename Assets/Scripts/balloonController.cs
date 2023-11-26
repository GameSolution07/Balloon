using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloonController : MonoBehaviour
{
    int score;
    private void Awake()
    {
        score = PlayerPrefs.GetInt("Score", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pin")
        {
            this.GetComponent<Animator>().Play("Pop");
            int s = PlayerPrefs.GetInt("speed", 5);

            s += 1;
            PlayerPrefs.SetInt("speed", s);
            StartCoroutine(restart());
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //this.GetComponent<Rigidbody2D>().position = Vector3.zero;
            score += 5;
            PlayerPrefs.SetInt("Score", score);


        }

        if (collision.gameObject.tag == "Border")
        {
            Vector2 dir = new Vector2(Random.Range(-5, 5), Random.Range(-1, 1));
            this.GetComponent<Rigidbody2D>().velocity = dir;
        }
    }

    IEnumerator restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
