# Dual Servo Example for Netduino

Controlling a servo using the original Netduino. Repository created for educational purposes.

## What You'll Need

Software:

* [Netduino SDK](http://www.netduino.com/downloads/)
* [Visual C# Express 2010](https://www.visualstudio.com/)
* [Micro Framework](http://www.netduino.com/downloads/)

Parts:

* [Netduino 1](http://www.netduino.com/netduino/specs.htm)
* One (Two For This Tutorial) TowerPro SG51R Servos
* One Standard Breadboard
* Eight Wires

## Breadboard

![See Breadboard.svg](http://i.imgur.com/WNE9Ufw.png)

## Image

![Real-life Image](http://i.imgur.com/bhiqkrP.jpg)

## Code

Servo API:
```c#
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
```

Program:
```c#
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
```
