using System;
using System.Collections.Generic;

[Serializable]
public struct StageDataContain
{
    public bool isClear;
    public int min;
    public float sec;
    public void SetData(bool state, int min, float sec)
    {
        this.isClear = state;
        this.min = min;
        this.sec = sec;
    }
}
public partial class GameData
{
    public StageDataContain[] StageData;
    public bool isLoad;
    public void SaveData(int idx, bool state, int min, float sec)
    {
        if (idx >= StageData.Length)
            return;
        StageData[idx].SetData(state, min, sec);
    }
    public void MakeStageData(int count)
    {
        if (StageData == null)
            StageData = new StageDataContain[count];
    }

}

