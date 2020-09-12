using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsCSharp
{
        public interface IAlert
        {

             void SendAlert(string message);
        }

        public class AlertBySms : IAlert
        {
             public void SendAlert(string message)
            {
                Console.WriteLine($"SMS : {message}");
            }
        }

        public class AlertBySound : IAlert
        {
             
             public void SendAlert(string message)
            {
                Console.WriteLine($"Sound : {message}");
            }
        }   
}
