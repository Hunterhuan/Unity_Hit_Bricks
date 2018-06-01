using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

    public GameObject brickParticle;   //得到破坏的粒子特效

    //当碰撞进入时
    void OnCollisionEnter(Collision other)
    {
        //实例化一个粒子特效
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        //利用GM的单例模式调用检查游戏是否结束的方法
        GM.instance.DestroyBrick();
        //销毁当前这个物体
        Destroy(gameObject);
    }

}
