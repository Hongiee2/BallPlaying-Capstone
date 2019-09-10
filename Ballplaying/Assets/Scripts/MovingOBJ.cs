using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOBJ : MonoBehaviour {
    public float speed;
    public float targetPosY;

	// Update is called once per frame
	void Update () {
        if (transform.position.y < targetPosY)
        {
            transform.Translate(new Vector3(0,
                                            Time.deltaTime * speed,
                                            0));
        }
	}
}
