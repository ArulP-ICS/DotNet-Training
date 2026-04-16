using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    class Program3
    {
        static void Main()
        {

            MobilePhone phone = new MobilePhone();
            RingtonePlayer ringtone = new RingtonePlayer();
            ScreenDisplay screen = new ScreenDisplay();
            VibrationMotor vibration = new VibrationMotor();

            phone.OnRing += ringtone.PlayRingtone;
            phone.OnRing += screen.ShowCallerInfo;
            phone.OnRing += vibration.Vibrate;

            Console.WriteLine("Mobile Phone Ring Notification System using Delegates and Events");
            Console.WriteLine("1. Call Me");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice: ");

            int n = Convert.ToInt32(Console.ReadLine());

            if (n == 1)
            {
                phone.ReceiveCall();
            }
            else if (n == 2)
            {
                Console.WriteLine("Exit the program");
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }

            Console.ReadLine();

        }
    }

    class MobilePhone
    {
        public delegate void RingEventHandler();

        public event RingEventHandler OnRing;



        public void ReceiveCall()
        {
            Console.WriteLine("Incoming call...");
            if (OnRing != null)
            {
                OnRing();
            }
        }
    }
    class RingtonePlayer
    {
        public void PlayRingtone()
        {
            Console.WriteLine("Playing ringtone...");
        }
    }


    class ScreenDisplay
    {
        public void ShowCallerInfo()
        {
            Console.WriteLine("Displaying caller information...");
        }
    }


    class VibrationMotor
    {
        public void Vibrate()
        {
            Console.WriteLine("Phone is vibrating...");
        }
    }

}
