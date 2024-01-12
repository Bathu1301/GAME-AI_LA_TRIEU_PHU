using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBarChartButton : MonoBehaviour
{
    public void OnButtonClick()
    {
        UIManager.Ins.dialogBarChart.Show(false);
    }
}
