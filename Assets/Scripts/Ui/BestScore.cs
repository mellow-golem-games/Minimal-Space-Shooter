using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text Score;
    // Start is called before the first frame update
    void Start()
    {

      Score.text = "Best Score: " + PlayerPrefs.GetInt ("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
