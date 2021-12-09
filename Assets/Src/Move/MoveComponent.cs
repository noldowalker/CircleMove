using UnityEngine;

namespace Src.Move
{
    public class MoveComponent : MonoBehaviour
    {
        private Vector2 _target;
        [SerializeField]
        private float _speed;
        
        void Start()
        {
            RemoveTarget();
        }

        public void MakeStep()
        {
            if (_target.Equals(Vector2.negativeInfinity))
            {
                return;
            }

            float step = _speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, _target, step);

            if (_target.Equals(transform.position))
            {
                RemoveTarget();
            }
        }
        
        public void RemoveTarget()
        {
            _target = Vector2.negativeInfinity;
        }
        
        public bool IsHaveTarget()
        {
            return !_target.Equals(Vector2.negativeInfinity);
        }
        
        public void NewTarget(Vector2 target)
        {
            _target = target;
        }

        public void SetSpeed(float newSpeed)
        {
            _speed = newSpeed;
        }
    }
}
