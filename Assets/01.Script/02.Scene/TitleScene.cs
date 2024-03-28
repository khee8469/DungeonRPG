using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    public override IEnumerator LoadingRoutine()
    {
        yield return null;
    }
    public void ChangeStageSelect()
    {
        Manager.Scene.LoadScene("01.StageSelectBoard");
    }

}
