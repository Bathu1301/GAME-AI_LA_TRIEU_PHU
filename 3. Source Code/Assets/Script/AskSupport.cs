using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class AskSupport : MonoBehaviour
{
    public Text first;
    public Text second;
    public Text third;

    // Start is called before the first frame update
    void Start()
    {
        Main();
    }


    public void Main()
    {
        // Mảng chứa 6 câu dạng string
        string[] cacCau = new string[]
        {
            "chọn A",
            "chọn B",
            "chọn C",
            "chọn D",
        };

        // Tạo một đối tượng Random
        Random random = new Random();

        // Lấy 3 câu ngẫu nhiên
        for (int i = 0; i < 3; i++)
        {
            // Sử dụng phương thức Next của đối tượng Random để lấy một chỉ số ngẫu nhiên
            int index = random.Next(cacCau.Length);
            first.text ="Khán giả 1 "+ cacCau[index].ToString();

        }

        for (int i = 0; i < 3; i++)
        {
            // Sử dụng phương thức Next của đối tượng Random để lấy một chỉ số ngẫu nhiên
            int index = random.Next(cacCau.Length);
            second.text = "Khán giả 2 " + cacCau[index].ToString();

        }

        for (int i = 0; i < 3; i++)
        {
            // Sử dụng phương thức Next của đối tượng Random để lấy một chỉ số ngẫu nhiên
            int index = random.Next(cacCau.Length);
            third.text = "Khán giả 3 " + cacCau[index].ToString();

        }
    }
}
