using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    public class CameraMovement : MonoBehaviour
    {

        [Header("Camera Controller")]
        [SerializeField]
        private Transform TargetTransform;
        [SerializeField]
        private float GapZ;
        private float _rotX, _rotY;
        [SerializeField]
        private float _rotSpeed = 3f;
        [SerializeField]
        private float _minVerAngle = -45f;
        [SerializeField]
        private float _maxVerAngle = 45f;
        [SerializeField]
        private Vector2 _framingBalance;
        [SerializeField]
        private bool _invertX, _invertY;

        private float _invertXValue, _invertYValue;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // CameraMove(playerInputs.InputMouseVector);
        }

        public void CameraMove(Vector2 cameraInput)
        {
            _invertXValue = (_invertX) ? -1 : 1;
            _invertYValue = (_invertY) ? -1 : 1;

            _rotX += cameraInput.x * _invertYValue * _rotSpeed;
            _rotX = Mathf.Clamp(_rotX, _minVerAngle, _maxVerAngle);
            _rotY += cameraInput.y * _invertXValue * _rotSpeed;

            var targetRotation = Quaternion.Euler(_rotX, _rotY, 0);
            var focusPosition = TargetTransform.position + new Vector3(_framingBalance.x, _framingBalance.y);
            transform.position = focusPosition - targetRotation * new Vector3(0, 0, GapZ);
            transform.rotation = targetRotation;
        }
    }
}