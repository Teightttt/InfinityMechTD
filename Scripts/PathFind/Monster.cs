using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    #region 计时器
    private float timer = 0f;
    // 定义检测间隔时间，这里设置为1秒，你可以根据需求调整
    private float ddl = 1f;
    #endregion

    private NavMeshAgent agent;

    public GameObject target;

    public GameObject Player;

    private int state;//怪物寻路状态
                      //1--寻找Player  
                      //2--寻找防御塔
                      //3--攻击防御塔

    private float checkRadius;//索敌半径

    private Towerclass tower;//待攻击的防御塔

    private float Atk;//怪物当前攻击力


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        state = 1;
        Player = GameObject.FindGameObjectWithTag("Player");
        checkRadius = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 1:
                target = Player;
                agent.SetDestination(target.transform.position);
                Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);
                float PlayerDistance=Vector3.Distance(transform.position,Player.transform.position);
                foreach (Collider collider in colliders)
                {
                    //Debug.Log(collider.name);
                    if (collider.CompareTag("Tower"))
                    {
                        float distance= Vector3.Distance(transform.position, collider.gameObject.transform.position);
                        if (PlayerDistance < distance) continue;
                        //Debug.Log(collider.gameObject.name);
                        // transform.LookAt(collider.transform);
                        target= collider.gameObject;
                        tower = target.GetComponent<Towerclass>();           
                        Atk = GetComponent<Monsterclass>().ATK;
                        state = 2;
                        break;
                    }
                }

                break;

            case 2:
                if (target == null)
                {
                    target = Player;
                    agent.SetDestination(target.transform.position);
                    state = 1;
                    break;
                }
                else if(agent.remainingDistance<1.2f)//离防御塔一定距离开始攻击防御塔
                {
                    agent.ResetPath();
                    state = 3;
                    break;
                }

                agent.SetDestination(target.transform.position);
                break;

            case 3:
                AttackTower();
                return;

            default:
                target = Player;
                agent.SetDestination(target.transform.position);
                break;
        }
    }

    void AttackTower()
    {
        if (target == null)
        {
            target = Player;
            agent.SetDestination(target.transform.position);
            state = 1;
            return;
        }
        timer += Time.deltaTime;
        if (timer >= ddl)
        {
            #region 伤害计算
            if (Atk < tower.DEF) Atk = 3;//固定最小伤害
            else Atk -= (float)tower.DEF;
            tower.HP -= Atk;
            #endregion
            timer = 0f;
        }
    }
}
