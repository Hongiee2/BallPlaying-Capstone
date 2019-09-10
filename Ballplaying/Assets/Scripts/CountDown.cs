using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public Text txtCountDown;//텍스트를 가져옴
    float countDown = 5.0f;//텍스트에 넣을 실제 카운트되는 값
    bool isCountdown = true;//카운트되는 기능을 담당

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isCountdown)
        {
            countDown -= Time.deltaTime;
            txtCountDown.text = "" + ((int)countDown + 1);//5부터 시작

            if (countDown < 0)//카운트 숫자가 0으로 되면 
            {
                txtCountDown.text = "";//텍스트 초기화
                Color color = txtCountDown.color;//색깔 투명하게 만듦
                color.a = 0.0f;
                txtCountDown.color = color;
                isCountdown = false;//작동을 멈춤
            }
        }
	}
}
