using UnityEngine;

public class DebugExt : MonoBehaviour
{
    [SerializeField] bool debugging = true;

    void DebugInEditor()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = debugging;
#else
        Debug.unityLogger.logEnabled = false;
#endif
    }

    void Awake()
    {
        DebugInEditor();
    }
}





