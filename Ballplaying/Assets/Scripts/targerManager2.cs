using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targerManager2 : MonoBehaviour
{

    public GameObject prefab_moving_cube;
    List<GameObject> clone_cubes = new List<GameObject>();
    public int maxCount;

    void Start()
    {
        StartCoroutine(CreateObject()); //코루틴 실행
        for (int i = 0; i < 2; i++)
        {
            GameObject clone_cube = Instantiate(prefab_moving_cube) as GameObject; // 오브젝트 생성
            clone_cubes.Add(clone_cube); // list에 오브젝트 추가
        }
    }

    IEnumerator CreateObject()
    {
        yield return new WaitForSeconds(3f); //3초간 기다립니다.
        if (clone_cubes.Count < maxCount) // max count 보다 적으면 list에 오브젝트를 추가합니다.
        {
            GameObject clone_cube = Instantiate(prefab_moving_cube) as GameObject; // 오브젝트 생성
            clone_cubes.Add(clone_cube); // list에 오브젝트 추가
        }
        StartCoroutine(CreateObject()); // 코루틴을 스스로 실행
    }
}