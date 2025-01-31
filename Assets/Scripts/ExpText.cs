
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class ExpText : UdonSharpBehaviour
{
    [SerializeField] Text text;

    public void SetText(float num)
    {
        string str;
        str = "経験値：" + num.ToString();

        text.text = str;
    }
}
