using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;

    public LineRenderer lineRenderer;//导航路线画线
    // Start is called before the first frame update
    void Start()
    {
        agent= GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))//检测鼠标左键是否松开
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            /*
             * 通过 Physics.Raycast 进行射线检测
             * 从主摄像机（Camera.main）朝着鼠标在屏幕上的位置（Input.mousePosition）发射一条射线
             * 如果射线与场景中的碰撞体相交，条件判断为 true，进入 if 语句块内执行后续操作
             * 若没有相交则跳过整个 if 语句块。
            */
            {
                print(hit.collider.name);//直观地知道射线击中了哪个物体
                agent.isStopped = false;//开始移动，取消之前可能处于的停止状态
                agent.SetDestination(hit.point);//朝着这个目的地移动
            }
        }

        if (!agent.pathPending && agent.pathStatus == NavMeshPathStatus.PathComplete)//agent 的路径不存在挂起,待处理等情况且已经是完整可用的状态
        {
            //Debug.Log("FindPath");
            DrawPath();//画导航路线
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            agent.isStopped = true;//停止移动
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            GameObject NewTower = Instantiate(Resources.Load<GameObject>("Prefabs/TD/Tower/Tower"));
            NewTower.transform.position=this.transform.position;
        }
    }

    void DrawPath()
    {
        Vector3[] PlayerPath=agent.path.corners;//这个导航代理所规划出的路径上的拐角点（节点）的集合
        lineRenderer.positionCount=PlayerPath.Length;
        for (int i = 0; i < PlayerPath.Length; i++) 
        {
            Vector3 p = PlayerPath[i];
            lineRenderer.SetPosition(i,p);//将当前索引 i 对应的顶点位置设置为刚刚从 path 数组中获取的点 p 的坐标
        }
    }
}
