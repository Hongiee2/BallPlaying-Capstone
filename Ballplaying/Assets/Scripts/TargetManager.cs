using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{

    public GameObject prefab_moving_cube;
    public int maxCubeCount;
    //GameObject clone_cube;
    
    float time = 0;

    void Start()
    {
        
    }
    
    void Update()
    {
        time += Time.deltaTime;
        
        ///////////////////////////////////// 타겟 움직임 그려내는 것
        if (time / 1 <= 0.05) // 새로운 루프 시작할 때 타겟 위치, 이동범위 재 설정
        {
            createTarget();
        }
    }

    void createTarget()
    {
        for (int i = 0; i < maxCubeCount; i++)
        {
            GameObject clone_cube = Instantiate(prefab_moving_cube) as GameObject;
        }
    }
}