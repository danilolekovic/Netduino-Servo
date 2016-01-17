using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace ServoExample
{
    public class Program
    {
        public static void Main()
        {
            Servo servo = new Servo(PWMChannels.PWM_PIN_D6);
            servo.Start();
            Servo servo2 = new Servo(PWMChannels.PWM_PIN_D9);
            servo2.Start();
            InputPort button = new InputPort(Pins.ONBOARD_BTN, false, Port.ResistorMode.Disabled);
            int pos = 0;

            while (true)
            {
                if (button.Read())
                {
                    if (pos == 0)
                    {
                        servo.MoveServoLeft();
                        servo2.MoveServoLeft();
                        pos = 1;
                    }
                    else if (pos == 1)
                    {
                        servo.MoveServoRight();
                        servo2.MoveServoRight();
                        pos = 0;
                    }
                }
            }
        }
    }
}
