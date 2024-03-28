using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectBoardScene : BaseScene
{
    [SerializeField] Transform stageButton;
    Button[] stageButtons;
    public void SetStageButtonState(int idx, bool isState)
    {
        if (idx < stageButtons.Length)
            stageButtons[idx].interactable = isState;
    }
    public void AddStageData(int idx, bool isState, int min, float sec)
    {
        if (idx < stageButtons.Length)
        {
            stageButtons[idx].interactable = isState;
            Manager.Data.GameData.SaveData(idx, isState,min,sec);
        }
    }
    private void Start()
    {
        stageButtons = new Button[stageButton.childCount];
        if(stageButtons.Length < 1)
        {
            stageButtons[0] = stageButton.GetChild(0).GetComponent<Button>();
            stageButtons[0].interactable = true;
        }
        for (int i = 1; i < stageButton.childCount; i++)
        {
            stageButtons[i] = stageButton.GetChild(i).GetComponent<Button>();
            stageButtons[i].interactable = false;
        }
        Manager.Data.LoadData();
        Manager.Data.GameData.MakeStageData(stageButton.childCount);
        LoadStageData();
        Manager.Data.GameData.isLoad = true;
    }
    public void LoadStageData()
    {
        StageDataContain[] stageDatas = Manager.Data.GameData.StageData;
        for (int i = 1; i < stageDatas.Length - 1; i++)
        {
            SetStageButtonState(i, stageDatas[i + 1].isClear);
        }
    }
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
    int i = 0;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            i++;
            AddStageData(i, true, 0, 0);
        }
    }
    private void OnDestroy()
    {
        Manager.Data.SaveData();
    }




}
