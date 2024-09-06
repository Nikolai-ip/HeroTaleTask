using MVC.Model.Battle.States;
using Signals;
using TMPro;
using UnityEngine;

namespace MVC.View
{
    public class PreparingIndicator:MonoBehaviour
    {
        private TextMeshProUGUI _textUI;
        private string _originText;

        public void Init()
        {
            _textUI = GetComponent<TextMeshProUGUI>();
            _originText = _textUI.text;
            EventBus.Subscribe<PreparingTimeSignal>(OnPreparingTime);
        }

        private void OnPreparingTime(PreparingTimeSignal signal)
        {
            _textUI.text = $"{_originText} {signal.Time}";
        }
    }
}