using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class InputText : MonoBehaviour
{
    InputField m_InputText;
    public Dropdown m_dropdown;
    public Dropdown m_CharName;
    private string[] m_text = new string[500];
    private string stock_text;
    public string R_text
    {
        get { return this.stock_text; }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ファイル読み込み
        StreamReader sr = new StreamReader(@"TextData.csv", Encoding.GetEncoding("Shift_JIS"));
        string line;
        int index = 0;

        while ((line = sr.ReadLine()) != null)
        {
            m_text[index] = line;
            Debug.Log(m_text[index]);
            index++;
        }
        sr.Close();

        m_InputText = GetComponent<InputField>();
        InitData();
    }

    //InputFieldの初期化
    void InitData()
    {
        m_InputText.text = " ";
    }

    //文字列保存
    public void InputData()
    {
        string TextData = m_InputText.text;
        stock_text = m_InputText.text;
        Debug.Log(TextData);

        FileData(TextData, m_dropdown.value + 1);

        InitData();
    }
    //データの書き換え処理、第一引数:書き換える文字列、第二引数：テキスト番号
    public void FileData(string text_s, int num)
    {
        //保存されている各情報の格納
        StreamReader sr = new StreamReader(@"TextData.csv", Encoding.GetEncoding("Shift_JIS"));
        string line;
        int index = 0;

        while ((line = sr.ReadLine()) != null)
        {
            m_text[index] = line;
            Debug.Log(m_text[index]);
            index++;
        }
        sr.Close();

        //各情報を格納
        string[] str = { "" + num, m_CharName.options[m_CharName.value].text, text_s };
        string str2 = string.Join(",", str);
        m_text[num - 1] = str2;

        //変更された情報の書き出し
        StreamWriter sw = new StreamWriter(@"TextData.csv", false, Encoding.GetEncoding("Shift_JIS"));
        for(int i = 0;i < 500;i++)
        {
            sw.WriteLine(m_text[i]);
        }
        sw.Close();
    }
}
