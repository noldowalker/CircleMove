using Src.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Src.UserInput
{
    public class InputSystem : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
                EventsWithData<EventDataWithCoords>.FireEvent(DTOEventTypes.WorldClick, new EventDataWithCoords()
                {
                    Coordinates = Camera.main.ScreenToWorldPoint(Input.mousePosition),
                });
            }
        }
    }
}
