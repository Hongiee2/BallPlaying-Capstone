using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultScore : MonoBehaviour {

    public Text txtResult;
    GameManager gm;

    int single_s, multi_s1, multi_s2;

    public Text Red_scoreText;
    public Text Blue_scoreText;
    public Text Yellow_scoreText;

    public Text GameOver_Red_Score_Text;
    public Text GameOver_Blue_Score_Text;
    public Text GameOver_Yellow_Score_Text;

    public GameObject getscore;

    // Use this for initialization
    void Start () {
        single_s = gm.yellow_score;
        multi_s1 = gm.red_score;
        multi_s2 = gm.blue_score;
    }
	
	// Update is called once per frame
	void Update () {
        GameOver_Red_Score_Text.text = "" + getscore.GetComponent<Score>().mu_s1;
        GameOver_Blue_Score_Text.text = "" + getscore.GetComponent<Score>().mu_s2;
        GameOver_Yellow_Score_Text.text = "" + getscore.GetComponent<Score>().s_s;
    }
}
/*
       int r = Mathf.FloorToInt(rs_multi1);
       Text multi1 = GetComponent<Text>();
       multi1.text = r.ToString();

       Text uiText = GetComponent<Text>();
       uiText.text = t.ToString();

       multi2 = GetComponent<Text>();
       multi2.text = rs_multi2.ToString();
       */
//Yellow_scoreText.text = "" + single_s;
//Red_scoreText.text = "" + multi_s1;
//Blue_scoreText.text = "" + multi_s2;