using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    private int i = 100;
   
    void Start()
    {
        //System.Int32 型
         i = 20; // 整数型の変数
        //floatの実体はsingle型
        float u = 3f;

        //+ 演算子による文字列結合
        //  Debug.Log("i="+i);

        int a = 90;
        var c = 20;

        c = a;
        //$から始まる文字列補間を使った場合
        // Debug.Log($"i={i + 10}");

        //上の文字列補間,実体はstring.Firmat() と同義
        //Debug.Log("Hello Unity.");

        // 変数型を暗黙的に推論してくれるvarが便利
        var v = 1234;　// 初期値かた型を推論する
        // var v; //エラー、初期化をすることができない

        

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


        //配列初期化子
        //new 要素型[] {値1, 値2, 値3 ...}

       //var iAry = new int[] { 10, 20, 30 };

       //要素から型推論可能なら要素型は省略可能
       // [] 内の要素数も{}　要素数から推論可能
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
