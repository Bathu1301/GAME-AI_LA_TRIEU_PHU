using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskDialog : MonoBehaviour
{
    // Start is called before the first frame update
    public void Show(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
