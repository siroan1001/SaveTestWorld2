
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class LevelUpButton : UdonSharpBehaviour
{
    [SerializeField] ExpText ExpText;

    public void ClickButton()
    {
        SaveData data = SaveData.GetInstance(Networking.LocalPlayer);
        if(!Utilities.IsValid(data))
        {
            return;
        }

        float num = data.GetExp();
        num++;

        data.SetExp(num);

        PushText();
    }

    public override void OnPlayerRestored(VRCPlayerApi player)
    {
        base.OnPlayerRestored(player);
        if (player.isLocal)
        {
            PushText();
        }
    }

    private void PushText()
    {
        if(!Utilities.IsValid(ExpText))
        {
            return; 
        }

        SaveData data = SaveData.GetInstance(Networking.LocalPlayer);
        if (!Utilities.IsValid(data))
        {
            return;
        }

        ExpText.SetText(data.GetExp());
    }
}
