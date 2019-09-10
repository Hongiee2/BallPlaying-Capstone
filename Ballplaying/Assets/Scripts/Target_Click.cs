using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target_Click : MonoBehaviour {

    public GameObject PlayerTarget;//복제할 타겟 오브젝트
    public Transform TargetLocation;//타겟이 발사될 위치
    public float Target_Speed;//타겟 발사 속도(타겟이 날아가는 속도X)
    private bool Target_State;//타겟 발사 속도를 제어할 변수

	// Use this for initialization
	void Start () {
        Target_State = true;
        //처음에 타켓을 발사할 수 있도록 제어변수를 true로 설정
    }

    // Update is called once per frame
    void Update()
    {
        TargetFire();
        //매 프레임마다 타겟발사 함수를 체크한다.

        if (Input.GetMouseButtonDown(0)) // 좌클릭 시
        {
            print("pos x = " + Input.mousePosition.x + "    /// pos y =" + Input.mousePosition.y);
        }
    }

    private void TargetFire()//타겟을 발사하는 함수
    {
        if (Target_State)//제어변수가 true일때만 작동
        {
            if (Input.GetKey(KeyCode.A))//키보드의 'A'를 누르면
            {
                StartCoroutine(FireCycleControl());// 코루틴 "FireCycleControl"이 실행되며
                Instantiate(PlayerTarget, TargetLocation.position, TargetLocation.rotation);
                //PlayerTarget을 TargetLocation의 위치에 TargetLocation의 방향으로 복제한다.
            }
        }
    }

    IEnumerator FireCycleControl()//코루틴 함수
    {
        Target_State = false;//처음에 Target_Statefmf false로 만들고
        yield return new WaitForSeconds(Target_Speed);//Target_Speed초 후에
        Target_State = true;//Target_Speed를 true로 만든다.
    } 
}