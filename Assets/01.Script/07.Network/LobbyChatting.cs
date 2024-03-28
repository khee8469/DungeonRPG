using Photon.Pun;
using TMPro;
using UnityEngine;

public class LobbyChatting : MonoBehaviourPun
{
    [SerializeField] int pontSize = 36;
    [SerializeField] Transform texts;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] PhotonView pv;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && pv.IsMine)
        {
            if(inputField.text != "")
            {
                FinishInput();
            }
        }
    }
    public void FinishInput()
    {
        inputField.DeactivateInputField();
        string userInput = $"{PhotonNetwork.LocalPlayer.NickName} : {inputField.text}";
        if(pv == null)
            pv = GetComponent<PhotonView>();
        pv.RPC("EnterText", RpcTarget.All, userInput);
        inputField.text = "";
    }

    private void OnEnable()
    {
        inputField.pointSize = pontSize;
        for (int i = 0; i < texts.childCount; i++)
        {
            GameObject obj = texts.GetChild(i).gameObject;
            TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                text.text = "";
                text.fontSize = pontSize;
            }
        }
    }

    [PunRPC]
    public void EnterText(string msg)
    {
        GameObject obj = texts.GetChild(texts.childCount - 1).gameObject;
        TextMeshProUGUI text = obj.GetComponent<TextMeshProUGUI>();
        if (text != null)
        {
            text.text = msg;
            text.transform.SetAsFirstSibling();
        }
    }
}
