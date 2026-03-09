using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

public static class AssetsManager
{
    public static T Load<T>(string address) where T : UnityEngine.Object {
        var task = Addressables.LoadAssetAsync<T>(address);
        T asset = task.WaitForCompletion();
        if (task.Status == AsyncOperationStatus.Succeeded) return asset;
        Debug.LogError($"[Assets Manager] Failed to load \"{address}\" of type \"{typeof(T).Name}\".");
        return null;
    }
    public static void Load<T>(string address, Action<T> onLoaded) where T : UnityEngine.Object {
        T asset = Load<T>(address);
        if (asset != null) onLoaded?.Invoke(asset);
    }
    public static void LoadScene(string name, LoadSceneMode mode = LoadSceneMode.Single) => Addressables.LoadSceneAsync($"scenes/{name}", mode).Completed += handle => {
        if (handle.Status != AsyncOperationStatus.Succeeded) Debug.LogError($"[Assets Manager] Failed to load scene \"{name}\".");
    };
}