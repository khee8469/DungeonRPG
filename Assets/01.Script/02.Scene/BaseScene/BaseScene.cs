using System.Collections;
using UnityEngine;
public  abstract partial class BaseScene : MonoBehaviour
{
    [SerializeField] public int changeImgIdx { get; protected set; }

    public abstract IEnumerator LoadingRoutine();
}
