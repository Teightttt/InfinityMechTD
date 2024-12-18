using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TowerStateBar : MonoBehaviour
{
    public Image HpTiao;

    public Image HpTiaoReduce;

    /// <summary>
    /// Ѫ�����ض���
    /// </summary>
    public Object WhichGuy;

    private void Update()
    {

        var Guy = WhichGuy.GetComponentInChildren<Towerclass>();

        float nowHP = Guy.HP;
        float HPupl = Guy.HPupl;

        onHpChange((float)nowHP / (float)HPupl);
        if (HpTiaoReduce.fillAmount > HpTiao.fillAmount)
        {
            HpTiaoReduce.fillAmount -= Time.deltaTime * 0.3f;
        }
        else
        {
            HpTiaoReduce.fillAmount = HpTiao.fillAmount;
        }
    }
    /// <summary>
    /// ����HP�ı���ٷֱ�
    /// </summary>
    /// <param name="persentage">�ٷֱȣ���ǰѪ��/���Ѫ��</param>
    public void onHpChange(float persentage)
    {
        //Debug.Log(persentage);
        HpTiao.fillAmount = persentage;
    }
}
