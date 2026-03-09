using UnityEngine.AddressableAssets;

public static class BootScript
{
    //[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Boot()
    {
        Addressables.InitializeAsync().WaitForCompletion();
        AssetsManager.LoadScene("game");
    }
}