using Signals;
using UnityEngine;

namespace MVC.Controller
{
    public class ButtonInputController : MonoBehaviour
    {
        [SerializeField] private ActionType _actionType;

        public void OnButtonClicked()
        {
            EventBus.Invoke(new ActionSignal(_actionType));
        }
    }
}