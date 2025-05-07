using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointsContainer))]
    public class RandomPointsGenerator : MonoBehaviour
    {
        [SerializeField] private byte _minDegree = 1;

        [SerializeField] private byte _maxDegree = 4;
        
        private PointsContainer _pointsContainer;

        private const byte defaultMinDegree = 1;
        private const byte defaultMaxDegree = 4;

        private void Start()
        {
            NormalizeDegree();
            _pointsContainer = GetComponent<PointsContainer>();

            int degree;

            // Только если диапазон включает 1 и 2 — применяем веса
            if (_minDegree <= 1 && _maxDegree >= 2)
            {
                int chance = Random.Range(0, 100);
                degree = (chance < 75) ? 1 : 2;
            }
            else
            {
                // Обычная генерация в диапазоне, если кастомный диапазон
                degree = Random.Range(_minDegree, _maxDegree);
            }

            _pointsContainer.points = (int)Mathf.Pow(2, degree);
        }


        private void NormalizeDegree()
        {
            if (_maxDegree > _minDegree) return;
            
            Debug.LogError("Установлены некорректные значения минимальной и максимальной степени");
            _minDegree = defaultMinDegree;
            _maxDegree = defaultMaxDegree;
        }
    }
}
