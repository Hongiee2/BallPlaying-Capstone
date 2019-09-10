using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Move : MonoBehaviour {

    public float MoveSpeed;//타겟이 날라가는 속도
    public float DestroyPos;//타겟이 사라지는 지점

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * MoveSpeed * Time.deltaTime);
        //매 프레임마다 타겟이 MoveSpeed만큼 up방향(Y축 +방향)으로 날라감
        if (transform.position.y >= DestroyPos)
        //만약에 타겟의 위치가 DestroyPos를 넘어서면
        {
            Destroy(gameObject);//타겟을 제거
        }
    }
}
