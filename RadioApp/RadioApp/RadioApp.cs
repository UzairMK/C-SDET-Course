using System;

namespace RadioApp
{
    public class Radio
    {
        private int _channel = 1;
        private bool _on;

        public int Channel 
        {
            get { return _channel; }
            set { _channel = value > 0 && value <= 4 && _on ? value : _channel; } 
        }

        public string Play()
        {
            return _on ? $"Playing channel {_channel}" : "Radio is off";
        }

        public void TurnOn()
        {
            _on = true;
        }
        public void TurnOff()
        {
            _on = false;
        }
    }
    // implement a class Radio that corresponds to the Class diagram 
    //   and specification in the Radio_Mini_Project document
}