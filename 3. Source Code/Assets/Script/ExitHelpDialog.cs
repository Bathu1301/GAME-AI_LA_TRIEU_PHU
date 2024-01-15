using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHelpDialog : MonoBehaviour
{
    public void OnButtonClick()
    {
        UIManager.Ins.askdialog.Show(false);
    }
}
