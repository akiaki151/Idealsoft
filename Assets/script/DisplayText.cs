using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;


public class DisplayText : MonoBehaviour
{
    public Text uiText;   // uiTextへの参照
    public Dropdown m_dropdown;
    public InputField inputtext;

    private string[][] m_stock_text = new string[500][];

    // Start is called before the first frame update
    void Start()
    {
        //StreamWriter sw = new StreamWriter(@"TextData.csv",false, Encoding.GetEncoding("Shift_JIS"));
        //for (int i = 0; i < 500; i++)
        //{
        //    //各情報を格納
        //    string[] str = { "" + (i + 1), "名無し", "入力してください" };
        //    string str2 = string.Join(",", str);
        //    sw.WriteLine(str2);
        //}
        //sw.Close();
        // ファイル読み込み
        // 引数説明：第1引数→ファイル読込先, 第2引数→エンコード
        StreamReader sr = new StreamReader(@"TextData.csv", Encoding.GetEncoding("Shift_JIS"));
        string line;
        int num = 0;
        // 行がnullじゃない間(つまり次の行がある場合は)、処理をする
        while ((line = sr.ReadLine()) != null)
        {
            string split_text = line;
            m_stock_text[num] = split_text.Split(","[0]);
            // コンソールに出力
            Debug.Log(line);
            num++;
        }
        // StreamReaderを閉じる
        sr.Close();
    }

    // Update is called once per frame
    void Update()
    {
        SelectText(m_dropdown.value);
    }

    public void SelectText(int index)
    {
        //Debug.Log(inputtext.R_text[index]);
        uiText.text = m_stock_text[index][2];
        Debug.Log(uiText.text);
    }
}
