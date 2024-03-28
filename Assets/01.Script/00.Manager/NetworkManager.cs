using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using UnityEngine;
using PN = Photon.Pun.PhotonNetwork;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    static PhotonView pv;
    public float Progress { get; private set; }
    static string changeSceneName;
    public static NetworkManager instance { get; private set; }
    public Action Connect;
    private void Start()
    {
        pv = GetComponent<PhotonView>();
        if (instance != null)
            ReleaseInstance();
        else
            instance = this;
    }
    public void ChangeRoom(string sceneName)
    {
        RoomOptions options = new RoomOptions() { MaxPlayers = 5 };
        PN.JoinOrCreateRoom(sceneName, options, null);
    }

    public override void OnJoinedRoom()
    {
        Progress = 0;
        Connect?.Invoke();
    }

    public IEnumerator ChangeScene(string sceneName)
    {
        if (PN.IsMasterClient)
            PN.LoadLevel(sceneName);
        else
            pv.RPC("RequestSceneRPC", RpcTarget.MasterClient);

        while (Progress < 1)
        {
            Progress = PN.LevelLoadingProgress;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        Progress = 1;
    }

    [PunRPC]
    void RequestSceneRPC(PhotonMessageInfo info)
    {
        if (PN.IsMasterClient)
        {
            string currentScene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            PN.LoadLevel(currentScene);
        }
    }

    public static void CreateInstance()
    {
        GameObject obj = PN.Instantiate("NetworkManager", Vector3.zero, Quaternion.identity);
        instance = obj?.GetComponent<NetworkManager>();
    }

    public static void ReleaseInstance()
    {
        if (pv != null)
            PN.Destroy(pv);
        if (instance == null)
            return;
        if (instance != null)
            Destroy(instance.gameObject);
        instance = null;
    }
}
