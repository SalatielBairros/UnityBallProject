using UnityEngine;

namespace Assets.Scripts
{
  public class BallMovment : MonoBehaviour
  {
    public float speed;
    private Rigidbody ball;

    void Start()
    {
      ball = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
      ball.AddForce(GetMovementDirection() * speed);
    }

    private Vector3 GetMovementDirection()
    {
      float moveHorinzontal = Input.GetAxis("Horizontal");
      float moveVertical = Input.GetAxis("Vertical");
      return new Vector3(moveHorinzontal, 0.0f, moveVertical);
    }
  }
}
