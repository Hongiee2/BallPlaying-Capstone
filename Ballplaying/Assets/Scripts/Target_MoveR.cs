using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_MoveR : MonoBehaviour
{

    protected float Animation;

    Vector3 startPoint;
    Vector3 target_scale = new Vector3(0.1f, 0.1f, 0);
    float width, height, duration;

    // Use this for initialization
    void Start()
    {
        startPoint.z = 0;
        duration = 4;
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////////////////////////// 타겟의 사이즈 변화주는 것
        //transform.localScale += target_scale;
        if (transform.localScale.x >= 1.7) // 너무 커지면 줄이고
            target_scale = new Vector3(-0.005f, -0.005f, 0);
        else if (transform.localScale.x <= 1.3) // 너무 작아지면 키우고
            target_scale = new Vector3(0.005f, 0.005f, 0);

        ///////////////////////////////////// 타겟 움직임 그려내는 것
        if (Animation % duration < 0.02) // 새로운 루프 시작할 때 타겟 위치, 이동범위 재 설정
        {
            startPoint.x = Random.RandomRange(-8, 8); // 시작점 좌표 지정
            startPoint.y = Random.RandomRange(-5, 5);

            width = Random.RandomRange(8, 12); // 너비, 높이 지정
            height = Random.RandomRange(2, 6);
        }

        Animation += Time.deltaTime;
        Animation = Animation % duration; // 루프를 위한 설정

        transform.position = MathParabola.Parabola(startPoint, Vector3.right * width, height, Animation / duration);
        //transform.Rotate += 1;
    }
}
