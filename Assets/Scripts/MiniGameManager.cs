using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance;

    public bool IsMiniGameActive { get; private set; }

    void Awake()
    {
        Instance = this;
        IsMiniGameActive = true; // Mini-game starts active
    }

    // Call this method to start the mini-game
    public void StartMiniGame()
    {
        IsMiniGameActive = true;
        // Additional logic for starting the mini-game
    }

    // Call this method to end the mini-game
    public void EndMiniGame()
    {
        IsMiniGameActive = false;
        // Additional logic for ending the mini-game
    }
}