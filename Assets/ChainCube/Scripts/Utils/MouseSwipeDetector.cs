using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChainCube.Scripts.Utils
{
    public class MouseSwipeDetector : MonoBehaviour, ISwipeDetector
    {
        public event Action<Vector2> onSwipeStart;
        public event Action<Vector2> onSwipe;
        public event Action<Vector2> onSwipeEnd;

        private bool _isSwipe;
        private Vector3 _lastPosition = new Vector2();
        private bool IsInSwipeZone(Vector2 position)
        {
            float screenHeight = Screen.height;
            return position.y <= screenHeight * 0.8f; // 20% нижней части экрана
        }

        private void Update()
        {
            if (!Input.GetMouseButton(0))
            {
                if (_isSwipe)
                {
                    _isSwipe = false;
                    onSwipeEnd?.Invoke(_lastPosition);
                    AudioManager.Instance.PlaySFX(1);
                }

                _lastPosition = Input.mousePosition;
                return;
            }

            if (!IsInSwipeZone(Input.mousePosition))
                return; // игнорируем свайп, если не в нижней зоне

            if (!_isSwipe)
            {
                _isSwipe = true;
                onSwipeStart?.Invoke(Input.mousePosition - _lastPosition);
            }

            onSwipe?.Invoke(Input.mousePosition - _lastPosition);
            _lastPosition = Input.mousePosition;
        }

    }
}

