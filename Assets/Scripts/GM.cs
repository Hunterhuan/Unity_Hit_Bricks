using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class GM : MonoBehaviour {

    public int lives = 3;  //生命值
    public int bricks = 20;  //砖块数
    public float resetDelay = 1f;  //唤醒方法时的延迟时间
    public Text livesText;   //得到生命值这个文本
    public GameObject gameOver;   //游戏结束文本这个物体
    public GameObject youWon;  //胜利文本物体
    public GameObject brickPrefab;   //所有砖块组成的prefab
    public GameObject paddle;   //移动的基座
    public GameObject deathParticles;   //被打坏时的粒子特效
    public static GM instance = null;    //要使用单例模式

    private GameObject clonePaddle;   //把移动的物体克隆出来操作它

	// Use this for initialization
	void Start ()
    {
	    if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        Setup();
	}

    //实例化出需要使用的东西
    private void Setup()
    {
        //实例化克隆移动的基座
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        //实例化砖块
        Instantiate(brickPrefab, transform.position, Quaternion.identity);
    }

    //检查游戏是否结束的方法
    void CheckGameOver()
    {
        //如果砖块数量小于1，也就是打完了
        if (bricks < 1 )
        {
            //把胜利文本显示
            youWon.SetActive(true);
            //放慢游戏时间
            Time.timeScale = 0.25f;
            //又重新开始游戏
            Invoke("Reset", resetDelay);
        }

        //如果生命值小于1
        if (lives < 1)
        {
            //显示失败文本
            gameOver.SetActive(true);
            Time.timeScale = 0.25f;
            Invoke("Reset", resetDelay);
        }
    }

    //重新加载游戏
    void Reset()
    {
        Time.timeScale = 1f;   //回复游戏速度
        SceneManager.LoadScene("Start");   //重新加载当前场景
    }

    //减少生命值
    public void LoseLife()
    {
        lives--;  //减少生命值
        livesText.text = "Lives:" + lives;    //设置生命值的文本
        //实例化一个粒子特效
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        //销毁当前这个丢失生命值的基座
        Destroy(clonePaddle);
        //唤醒设置基座的方法，
        Invoke("SetupPaddle", resetDelay);
        //检查游戏是否结束
        CheckGameOver();
    }

    void SetupPaddle()
    {
        //实例化克隆移动的基座
        clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
    }

    //销毁砖块的方法
    public void DestroyBrick()
    {
        //砖块数减少一
        bricks--;
        //检查游戏是否结束
        CheckGameOver();
    }
}
