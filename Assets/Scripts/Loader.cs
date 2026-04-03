using UnityEngine;

public static class Loader
{
    public enum Scene
    {
        GameScene,
        MainMenuScene,
        LoadingScene
    }
    private static Scene sceneToLoad;

    public static void Load(Scene sceneToLoad)
    {
        Loader.sceneToLoad = sceneToLoad;
        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }
    public static void CallBack()
    {
        Debug.Log("CallBack");
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad.ToString());
        
    }
}
