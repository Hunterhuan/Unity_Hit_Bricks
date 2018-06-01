using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {

    //与触发器接触时
    void OnTriggerEnter(Collider other)
    {
        //调用减少生命值的方法
        GM.instance.LoseLife();
    }
}
