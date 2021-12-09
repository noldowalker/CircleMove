using System;
using System.Collections;
using System.Collections.Generic;
using Src.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
   [SerializeField] private Slider _slider;
   [SerializeField] private TextMeshProUGUI _sliderText;

   private void Awake()
   {
      ChangeText();
      FireEvent();
   }

   private void ChangeText()
   {
      _sliderText.text = _slider.value.ToString();
      
   }
   
   public void OnValueChanged()
   {
      ChangeText();
      FireEvent();
   }

   private void FireEvent()
   {
      EventsWithData<EventDataWithFloat>.FireEvent(DTOEventTypes.SpeedChanged, new EventDataWithFloat()
      {
         Value = _slider.value,
      });
   }
}
