using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int currentBlocksCount;

    public void AddBlock()
    {
        currentBlocksCount++;
    }

    public void DeleteBlock()
    {
        currentBlocksCount--;
        if (currentBlocksCount == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextLevel();
        }
    }
}
