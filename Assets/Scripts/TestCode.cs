using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    private int i = 100;
   
    void Start()
    {
        //System.Int32 �^
         i = 20; // �����^�̕ϐ�
        //float�̎��̂�single�^
        float u = 3f;

        //+ ���Z�q�ɂ�镶���񌋍�
        //  Debug.Log("i="+i);

        int a = 90;
        var c = 20;

        c = a;
        //$����n�܂镶�����Ԃ��g�����ꍇ
        // Debug.Log($"i={i + 10}");

        //��̕�������,���̂�string.Firmat() �Ɠ��`
        //Debug.Log("Hello Unity.");

        // �ϐ��^���ÖٓI�ɐ��_���Ă����var���֗�
        var v = 1234;�@// �����l�����^�𐄘_����
        // var v; //�G���[�A�����������邱�Ƃ��ł��Ȃ�

        

        object value = 1234;
       // Debug.Log(value);

        value = "aaaa";
       // Debug.Log(value);

        value = Vector3.zero;
       // Debug.Log(value);

        var o = Vector3.zero;
        o.x = 10;
        o.y = 29;
        o.z = 39;

        //int[] iAry;
        //iAry = new int[3];

        //y[0] = 10;
        //iAry[1] = 20;
        //iAry[2] = 30;


        //�z�񏉊����q
        //new �v�f�^[] {�l1, �l2, �l3 ...}

       //var iAry = new int[] { 10, 20, 30 };

       //�v�f����^���_�\�Ȃ�v�f�^�͏ȗ��\
       // [] ���̗v�f����{}�@�v�f�����琄�_�\
        var iAry = new[] { 10, 20, 30 };

        /*for (var i = 0; i < iAry.Length; i++)
        {
            Debug.Log($"iAry[{i}]={iAry[i]}");
        }*/

        foreach (var e in iAry)
        {
            Debug.Log($"e={e}");
        }
    }

   
}
