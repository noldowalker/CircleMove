using System;
using System.Collections.Generic;
using System.Linq;
using Src.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Src.Move
{
    public class MoveSystem : MonoBehaviour
    {
        [SerializeField]
        private MoveComponent _playerEntity;
        
        private Queue<Vector2> _wayPoints;
        
        void Start()
        {
            _wayPoints = new Queue<Vector2>();
            EventsWithData<EventDataWithCoords>.Sub(DTOEventTypes.WorldClick, OnMouseInWorldClick);
            EventsWithData<EventDataWithFloat>.Sub(DTOEventTypes.SpeedChanged, OnPlayerSpeedChangeCall);
        }

        void Update()
        {
            ProcessPlayer();
        }

        private void ProcessPlayer()
        {
            if (_playerEntity.IsHaveTarget())
            {
                _playerEntity.MakeStep();
                return;
            }
            
            if (_wayPoints.Count > 0)
            {
                _playerEntity.NewTarget(_wayPoints.Peek());
                _wayPoints.Dequeue();
            }
        }
        
        public void OnMouseInWorldClick(EventDataWithCoords data)
        {
            _wayPoints.Enqueue((Vector2)data.Coordinates);
        }

        public void OnPlayerSpeedChangeCall(EventDataWithFloat data)
        {
            _playerEntity.SetSpeed(data.Value);
        }
        
        private void OnDestroy()
        {
            EventsWithData<EventDataWithCoords>.Unsub(DTOEventTypes.WorldClick, OnMouseInWorldClick);
            EventsWithData<EventDataWithFloat>.Unsub(DTOEventTypes.SpeedChanged, OnPlayerSpeedChangeCall);
        }
    }
}
