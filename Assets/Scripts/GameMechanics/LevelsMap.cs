using UnityEngine;

public class LevelsMap : MonoBehaviour
{
    [SerializeField] private LevelData[] levels;

    private LevelData currentLevel;
    private int level;

    public LevelData GetCurrentLevel()
    {
        if (currentLevel == null)
        {
            currentLevel = levels[0];
            level = 0;
        }
        return currentLevel;
    }

    public void OpenNextLevel()
    {
        level++;
        if (level >= levels.Length)
        {
            currentLevel = levels[0];
            level = 0;
        }
        else
        {
            currentLevel = levels[level];
        }
    }
}
