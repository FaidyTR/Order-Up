using Unity.VisualScripting;
using UnityEngine;

public class CallBack : MonoBehaviour
{
    private bool FistUpdate = true;
    private void Update()
    {
        if (FistUpdate)
        {
            Loader.CallBack();
            FistUpdate = false;
        }
    }
}
