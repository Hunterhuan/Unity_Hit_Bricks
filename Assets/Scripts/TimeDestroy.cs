using UnityEngine;
using System.Collections;

public class TimeDestroy : MonoBehaviour {
    public float destroyTime = 1f;

	// Use this for initialization
	void Start () {
        //销毁物体
        Destroy(gameObject, destroyTime);
	}
	
}
