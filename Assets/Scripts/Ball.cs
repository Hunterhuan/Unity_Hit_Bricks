using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float ballInitialVelocity = 600f;   //小球发射时的速度

    private Rigidbody rb;
    private bool ballInPlay;  //小球是否在运动

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //如果按下了左键  并且小球不在运行
	    if(Input.GetButtonDown("Fire1") && ballInPlay == false)
        {
            //设置不要父物体
            transform.parent = null;
            ballInPlay = true;
            //设置非动力学
            rb.isKinematic = false;
            //添加一个力让他运动
            rb.AddForce(new Vector3(ballInitialVelocity, ballInitialVelocity, 0));
        }
	}
}
