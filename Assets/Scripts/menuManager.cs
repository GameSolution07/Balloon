using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class menuManager : MonoBehaviour
{
    public TMP_Text[] highscoreText;
    // Start is called before the first frame update
    void Start()
    {
        int s = PlayerPrefs.GetInt("id");
        for (int i = 0; i < s; i++)
        {
            highscoreText[i].text = PlayerPrefs.GetInt("Player" + i).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void diff(int id)
    {
        if (id == 0)
        {
            PlayerPrefs.SetInt("speed", 5);
        }
        else if (id == 1)
        {
            PlayerPrefs.SetInt("speed", 7);
        }
        else if (id == 2)
        {
            PlayerPrefs.SetInt("speed", 9);
        }
        SceneManager.LoadScene(1);
    }
}
