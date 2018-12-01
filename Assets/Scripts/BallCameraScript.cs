using UnityEngine;

/// <summary>
/// This script associates the camera with the player (ball), keeping the same distance between both for all game.   
/// </summary>
public class BallCameraScript : MonoBehaviour
{
    /// <summary>
    /// The player of the game (in this case, the ball)
    /// </summary>
    public GameObject Player;

    /// <summary>
    /// Distance between the player and the camera.
    /// </summary>
    private Vector3 offset;

    void Start()
    {
        //Get the offset (the initial distance) between camera and player. 
        offset = transform.position - Player.transform.position;
    }

    /// <summary>
    /// LateUpdate happens each frame after all update methods of all gameobjects were called.
    /// </summary>
    void LateUpdate()
    {
        //Keep the distance between the camera and the player the same.
        transform.position = Player.transform.position + offset;
    }
}
