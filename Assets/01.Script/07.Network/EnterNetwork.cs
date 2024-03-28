using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using PN = Photon.Pun.PhotonNetwork;

public class EnterNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] int verson;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Button enterButton;
    [SerializeField] TextMeshProUGUI text;
    void Start()
    {
        //Screen.SetResolution(640, 360,false);
        text.text = "닉네임을 입력하세요.";
        enterButton.interactable = false;
        PN.GameVersion = verson.ToString();
        PN.ConnectUsingSettings();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        text.text = "접속에 실패하였습니다.";
    }
    public override void OnConnectedToMaster()
    {
        enterButton.interactable = true;
    }

    public void SetCheckNickName()
    {
        text.text = "사용가능한 닉네임입니다.";
        PN.LocalPlayer.NickName = inputField.text;
    }
    public void EnterStage()
    {
        text.text = "접속 중 입니다.";
        Manager.Scene.LoadScene("01.Lobby");
        enterButton.interactable = false;
    }
    public override void OnJoinedRoom()
    {
        
    }

}
