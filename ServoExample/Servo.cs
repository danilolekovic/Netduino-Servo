using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace ServoExample
{
    public class Servo
    {
        protected PWM pwmServo { get; set; }
        protected uint Position { get; set; }

        public Servo(Cpu.PWMChannel pin)
        {
            pwmServo = new PWM(pin, 20000, Position, PWM.ScaleFactor.Microseconds, false);
            SetPositionStraight();
            MoveServoLeft();
        }

        public void SetPositionStraight()
        {
            Position = 1500;
        }

        public void Start()
        {
            pwmServo.Start();
        }

        public void MoveServoLeft()
        {
            pwmServo.Duration = 750;
        }

        public void MoveServoRight()
        {
            pwmServo.Duration = 2250;
        }
    }
}
