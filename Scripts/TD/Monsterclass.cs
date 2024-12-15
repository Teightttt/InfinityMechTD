using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Towerclass;

public class Monsterclass : MonoBehaviour
{
    public float hp;
    public float hpupl;
    public float atk;
    public float def;
    public float radius;
    public int number;
    public string bulletname;
    public float HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            //血量监听
            if (hp < 0)
            {
                // 销毁怪物对象
                Destroy(this.gameObject);
            }
        }
    }

    public float HPupl
    {
        get
        {
            return hpupl;
        }
        set
        {
            hpupl = value;
        }
    }

    public float ATK
    {
        get
        {
            return atk;
        }
        set
        {
            atk = value;
        }
    }

    public float DEF
    {
        get
        {
            return def;
        }
        set
        {
            def = value;
        }
    }

    public float Radius
    {
        get
        {
            return radius;
        }
        set
        {
            radius = value;
        }
    }
    public int Number
    {
        get
        {
            return number;
        }
        set
        {
            number = value;
        }
    }

    // 构造函数，初始化属性值
    public Monsterclass()
    {
        HP = 20;
        HPupl = 20;
        ATK = 8;
        DEF = 1;
        Radius = 5;
    }
}
