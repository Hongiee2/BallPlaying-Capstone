using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public int s_s, mu_s1, mu_s2;
    GameManager gm;
    
    void start()
    {
        s_s = gm.yellow_score;
        mu_s1 = gm.blue_score;
        mu_s2 = gm.red_score;
    }

	void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
