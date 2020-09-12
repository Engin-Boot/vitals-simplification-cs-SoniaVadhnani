using System;
using System.Diagnostics;
using System.Net.Mail;
//using VitalsCSharp;

namespace VitalsCSharp
{
    class Checker
    {

        /*static bool vitalsAreOk(float bpm, float spo2, float respRate)
        {
            if (bpm < 70 || bpm > 150)
            {
                return false;
            }
            else if (spo2 < 90)
            {
                return false;
            }
            else if (respRate < 30 || respRate > 95)
            {
                return false;
            }
            return true;
        }

        */


        #region source

        public bool vitalsAreOk(Alerting.IAlert alert, string name, float value, float lower, float upper)
        {
            Vital vitalobj = new Vital(name, value, lower, upper);
            if (!IsVitalLow(alert, vitalobj) && !IsVitalHigh(alert, vitalobj))
                return true;

            return false;
        }

        #endregion



        #region target
        public bool IsVitalLow(Alerting.IAlert alert,Vital vitalobject)
        {
            if (vitalobject.Value < vitalobject.Lower)
            {
                //call alert
                alert.SendAlert($"The {vitalobject.Name} value is {vitalobject.Value} which is too LOW.");
                return true;
               
            }

            return false;
        }

        public bool IsVitalHigh(Alerting.IAlert alert,Vital vitalobject)
        {
            if (vitalobject.Value < vitalobject.Lower)
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
            

            //alert is also passed with the name and val accordingly
            Alerting.IAlert smsalert = new Alerting.AlertBySms();
            Alerting.IAlert soundalert = new Alerting.AlertBySound();

            Checker checkerobj1 = new Checker();
            //checkerobj1.vitalsAreOk(smsalert, "spo2", 100, 95, 60);


            VitalChecker.ExpectTrue(checkerobj1.vitalsAreOk(smsalert, "spo2", 98, 90, 101));
            VitalChecker.ExpectFalse(checkerobj1.vitalsAreOk(smsalert, "spo2", 85, 90, 101));
            // ExpectFalse(vitalsAreOk(40, 91, 92));
            //Console.WriteLine("All ok");
            return 0;
        }
    }
}