using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointsContainerCollisionDetector), typeof(PointsContainer))]
    public class CollisionMergePointsContainer : MonoBehaviour
    {
        private PointsContainer _pointsContainer;
        private PointsContainerCollisionDetector _detector;

        private void Start()
        {
            _pointsContainer = GetComponent<PointsContainer>();
            _detector = GetComponent<PointsContainerCollisionDetector>();
            Subscribe();
        }

        private void OnPointsContainerCollision(PointsContainer col)
        {
            if (col.points == _pointsContainer.points)
            {
                long oldPoints = _pointsContainer.points;
                int scoreToAdd = (int)_pointsContainer.points / 2;
                ScoreCounter.Instance.AddScore(scoreToAdd);
                _pointsContainer.points *= 2;
                Destroy(col.gameObject);
                AudioManager.Instance.PlaySFX(0);
                // Добавим очки: половина новой суммы
                //int scoreToAdd = (int)_pointsContainer.points / 2;
                //ScoreCounter.Instance.AddScore(scoreToAdd);
            }
        }

        private void Subscribe()
        {
            _detector.onCollisionContinue += OnPointsContainerCollision;
        }

        private void Unsubscribe()
        {
            _detector.onCollisionContinue -= OnPointsContainerCollision;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}
