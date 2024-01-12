using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpBarChart : MonoBehaviour
{
    public Image column1;
    public Image column2;
    public Image column3;
    public Image column4;
    public Text percentageA;
    public Text percentageB;
    public Text percentageC;
    public Text percentageD;

    // Gọi hàm này để cập nhật giá trị của các cột với tổng là 100%
    void UpdateColumnValues()
    {
        // Tạo giá trị ngẫu nhiên cho mỗi cột

        int value1 = Random.Range(1, 100);
        int value2 = Random.Range(1, 100 - value1);
        int value3 = Random.Range(1, 100 - value1 - value2);
        int value4 = 100 - value1 - value2 - value3;
        // Cập nhật giá trị của các cột
        percentageA.text = value1.ToString() + "%";
        percentageB.text = value2.ToString() + "%";
        percentageC.text = value3.ToString() + "%";
        percentageD.text = value4.ToString() + "%";
        Debug.Log(value1);
        Debug.Log(value2);
        Debug.Log(value3);
        Debug.Log(value4);



        SetColumnValues(value1, value2, value3, value4);
    }

    // Cập nhật giá trị cho mỗi cột
    void SetColumnValues(int value1, int value2, int value3, int value4)
    {
        float total = value1 + value2 + value3 + value4;
        float a = Screen.height;
        float b = (a * (1 / 10));
        float columnHeight = Screen.height * (0.5f); // Chiều cao tối đa mà bạn muốn cột tăng lên

        // Cập nhật giá trị của các cột
        column1.rectTransform.sizeDelta = new Vector2(column1.rectTransform.sizeDelta.x, (value1 / total) * columnHeight);
        column2.rectTransform.sizeDelta = new Vector2(column2.rectTransform.sizeDelta.x, (value2 / total) * columnHeight);
        column3.rectTransform.sizeDelta = new Vector2(column3.rectTransform.sizeDelta.x, (value3 / total) * columnHeight);
        column4.rectTransform.sizeDelta = new Vector2(column4.rectTransform.sizeDelta.x, (value4 / total) * columnHeight);

        float yOffset = Screen.height * 0.2f; // Giả sử bạn muốn các cột nằm ở phía dưới 1/4 của màn hình
        column1.rectTransform.anchoredPosition = new Vector2(column1.rectTransform.anchoredPosition.x, -yOffset + column1.rectTransform.sizeDelta.y / 2f);
        column2.rectTransform.anchoredPosition = new Vector2(column2.rectTransform.anchoredPosition.x, -yOffset + column2.rectTransform.sizeDelta.y / 2f);
        column3.rectTransform.anchoredPosition = new Vector2(column3.rectTransform.anchoredPosition.x, -yOffset + column3.rectTransform.sizeDelta.y / 2f);
        column4.rectTransform.anchoredPosition = new Vector2(column4.rectTransform.anchoredPosition.x, -yOffset + column4.rectTransform.sizeDelta.y / 2f);

    }

    // Gọi hàm này từ bất kỳ nơi nào bạn muốn cập nhật giá trị của các cột
    void Start()
    {
        UpdateColumnValues();
    }
}
