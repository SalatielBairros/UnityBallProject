using Assets.Scripts.Utils;
using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallMovment : MonoBehaviour
    {
        public float Speed;
        public TextMesh CountText;

        private Rigidbody _ball;
        private int _bonusCount;
        private double _percentDone;

        private int BonusCubeCount
        {
            get { return ((GameStart)GetComponent("GameStart")).Spawned; }
        }


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
            if (!other.gameObject.CompareTag("BonusCube")) return;
            BonusCube bonusCube = GetBonusCubeComponent(other);
            Destroy(other.gameObject);

            _bonusCount += (bonusCube != null ? bonusCube.BonusValue : 1);
            ValidateBonusCount();
            //ChangeColorByBonusCount();
        }

        private void ChangeColorByBonusCount()
        {
            _percentDone = Math.Round((double)(BonusCubeCount / _bonusCount * 100), 2);

            if (_percentDone >= 100)
            {
                SetColor(new Color(255, 251, 107));
            }
            else if (_percentDone > 80)
            {
                SetColor(new Color(131, 60, 255));
            }
        }

        private void ValidateBonusCount()
        {
            if (_bonusCount < 0)
            {
                _bonusCount = 0;
                GameActions.ResetGame();
            }
            else
            {
                CountText.text = _bonusCount.ToString();
            }
        }

        private static BonusCube GetBonusCubeComponent(Collider other)
        {
            return other.gameObject.GetComponent("BonusCube") as BonusCube;
        }

        private void SetColor(Color color)
        {
            ((Light)this.GetComponent("Light")).color = color;
        }
    }
}
