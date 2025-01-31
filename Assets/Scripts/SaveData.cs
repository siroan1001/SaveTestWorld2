
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class SaveData : UdonSharpBehaviour
{
    // 保存するデータ
    [UdonSynced]
    [SerializeField] private float Exp;

    public static SaveData GetInstance(VRCPlayerApi player)
    {
        GameObject[] playerObjectList = Networking.GetPlayerObjects(player);    //ワールド内に存在するPlayerObjectを取得しリストに格納
        if (!Utilities.IsValid(playerObjectList))
        {//リストに何も格納できなかった場合NULLを返す
            return null;
        }

        foreach (GameObject playerObject in playerObjectList)
        {
            if (!Utilities.IsValid(playerObject))
            {//オブジェクトが非アクティブ（＝自分のじゃない）なら戻る
                continue;
            }

            SaveData foundScript = playerObject.GetComponentInChildren<SaveData>();
            if (!Utilities.IsValid(foundScript))
            {//SaveDataスクリプトがアタッチされていなかったら戻る
                continue;
            }

            return foundScript;
        }

        return null;
    }


    public float GetExp()
    {
        return Exp;
    }

    public void SetExp(float count)
    {
        Exp = count;
        Debug.Log("exp:" + Exp);

        // 同期変数の変更を同期させることで自動的にUserDataが更新される
        RequestSerialization();
    }
}
