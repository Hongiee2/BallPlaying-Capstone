using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text txtTimer;//텍스트를 가져옴
    public static float timer;
    Color color;
    int gameTime = 30;

    // Use this for initialization
    void Start () {
        timer = (float)(gameTime+5) + 1;

        color = txtTimer.color;//색깔 투명하게 만듦
        color.a = 0.0f;
        txtTimer.color = color;
    }
	
	// Update is called once per frame
	void Update () {

        if (timer != 0)
        {
            timer -= Time.deltaTime;

            if (timer <= gameTime+1)//카운트 숫자가 60으로 되면
            {
                Color color = txtTimer.color;//색깔 투명하게 만듦
                color.a = 255.0f;
                txtTimer.color = color;
            }

            if (timer <= 0)
            {
                timer = 0;
                SceneManager.LoadScene("3_MultiGame_Score");
            }
        }
        int t = Mathf.FloorToInt(timer);
        Text uiText = GetComponent<Text>();
        uiText.text = t.ToString();
	}
}