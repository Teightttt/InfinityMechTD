using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicPlayers = GameObject.FindGameObjectsWithTag("MusicPlayer");
        if (musicPlayers.Length > 1)
        {
            // 如果存在多个，销毁自身
            Destroy(this.gameObject);
        }
        else
        {
            // 防止这个游戏对象在加载新场景时被销毁
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
