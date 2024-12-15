using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerclass : MonoBehaviour
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
                // 销毁塔
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

    public string BulletName
    {
        get
        {
            return bulletname;
        }
        set
        {
            bulletname = value;
        }
    }

    // 构造函数，初始化属性值
    public Towerclass()
    {
        HP = 100;
        HPupl = 100;
        ATK = 10;
        DEF= 5;
        Radius = 5;
        BulletName = "Bullet1";
    }
}