using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneName
{
    public const string SceneFarm = "PlayableLand";
    public const string SceneChicken = "PlayableChicken";
    public const string ScenePig = "PlayablePig";
    public const string PickFarm = "PickFarm";
}
public class PickFarm : MonoBehaviour
{
    private void Awake()
    {
        DataManager.S.Init();
    }

    public void OpenSceneLand()
    {
        SceneManager.LoadScene(SceneName.SceneFarm);
    }

    public void OpenSceneChicken()
    {
        SceneManager.LoadScene(SceneName.SceneChicken);
    }

    public void OpenScenePig()
    {
        SceneManager.LoadScene(SceneName.ScenePig);
    }
}
