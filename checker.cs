using System;
using System.Diagnostics;
using System.Net.Mail;
//using VitalsCSharp;

namespace VitalsCSharp
{
    class Checker
    {
        #region source

        public bool vitalsAreOk(IAlert alert, string name, float value, float lower, float upper)
        {
            Vital vitalobj = new Vital(name, value, lower, upper);
            if (!IsVitalLow(alert, vitalobj) && !IsVitalHigh(alert, vitalobj))
                return true;

            return false;
        }

        #endregion



        #region target
        public bool IsVitalLow(IAlert alert, Vital vitalobject)
        {
            if (vitalobject.Value < vitalobject.Lower)
            {
                //call alert
                alert.SendAlert($"The {vitalobject.Name} value is {vitalobject.Value} which is too LOW.");
                return true;

            }

            return false;
        }

        public bool IsVitalHigh(IAlert alert, Vital vitalobject)
        {
            if (vitalobject.Value > vitalobject.Upper)
            {
                //call alert
                alert.SendAlert($"The {vitalobject.Name} value is {vitalobject.Value} which is too HIGH.");
                return true;
            }
            return false;
        }
        #endregion


        static int Main()
        {

            IAlert smsalert = new AlertBySms();
            IAlert soundalert = new AlertBySound();

            Checker checkerobj1 = new Checker();

            VitalChecker.ExpectTrue(checkerobj1.vitalsAreOk(smsalert, "spo2", 98, 90, 101));
            VitalChecker.ExpectFalse(checkerobj1.vitalsAreOk(smsalert, "spo2", 85, 90, 101));
            VitalChecker.ExpectFalse(checkerobj1.vitalsAreOk(smsalert, "spo2", 102, 90, 101));

            //Console.WriteLine("All ok");
            return 0;
        }
    }
}