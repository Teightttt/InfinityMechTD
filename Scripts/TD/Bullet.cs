using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Atk;
    public Collider target;
    public float speed = 5f;

    // Start是在第一帧更新前调用一次
    void Start()
    {

    }

    // Update每帧都会被调用一次
    void Update()
    {
        if (target != null)
        {
            // 计算子弹指向目标的方向向量
            Vector3 direction = (target.transform.position - transform.position).normalized;
            // 让子弹沿着该方向移动
            transform.position += direction * speed * Time.deltaTime;
            // 使子弹的朝向对准目标（这里只是简单的让子弹朝向目标方向）
            transform.forward = direction;

            float distance = Vector3.Distance(transform.position, target.transform.position);
            Monsterclass monsterclass= target.GetComponent<Monsterclass>();
            if (distance < 0.5f)
            {
                // 当距离小于阈值时，销毁子弹
                Destroy(gameObject);

                #region 伤害计算
                if (Atk < monsterclass.DEF) Atk = 3;//固定最小伤害
                else Atk-=(float)monsterclass.DEF;
                monsterclass.HP-=Atk;
                #endregion
            }
        }
        else
        {
            Destroy (gameObject);//目标死亡导致丢失
        }
    }
}
