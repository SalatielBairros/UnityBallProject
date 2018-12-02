using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BallMovment : MonoBehaviour
    {
        public float Speed;
        public TextMesh CountText;

        private Rigidbody _ball;
        private int _bonusCount;

        void Start()
        {
            _ball = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            _ball.AddForce(GetMovementDirection() * Speed);
        }

        private Vector3 GetMovementDirection()
        {
            float moveHorinzontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            return new Vector3(moveHorinzontal, 0.0f, moveVertical);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("BonusCube"))
            {
                var bonusCube = other.gameObject.GetComponent("BonusCube") as BonusCube;
                _bonusCount += (bonusCube != null ? bonusCube.BonusValue : 1);

                CountText.text = _bonusCount.ToString();
                Destroy(other.gameObject);
            }
        }
    }
}
