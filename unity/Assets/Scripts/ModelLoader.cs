using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ModelLoader : MonoBehaviour
{
    public string modelUrl;

    IEnumerator Start()
    {
        yield return DownloadModel();
    }

    IEnumerator DownloadModel()
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(modelUrl))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result == UnityWebRequest.Result.Success)
            {
                // TODO: load model from uwr.downloadHandler.data
            }
            else
            {
                Debug.LogError("Failed to download model: " + uwr.error);
            }
        }
    }
}
