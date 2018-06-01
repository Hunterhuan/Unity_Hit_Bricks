using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float paddleSpeed = 1f;  //移动速度

    private Vector3 playerPos = new Vector3(0, -9.4f, 0);  //初始位置
	
	// Update is called once per frame
	void Update () {
        //按下水平按键时，得到当前位置与水平方向的位移
        float xPos = transform.position.x + Input.GetAxis("Horizontal") * paddleSpeed;
        //重新设置位置为水平方向改变后的值
        //小于-8时值是-8，大于8时，值是8，
        //因为是水平移动，y，z轴不变
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.4f, 0);
        //更行位置
        transform.position = playerPos;
	}
}
