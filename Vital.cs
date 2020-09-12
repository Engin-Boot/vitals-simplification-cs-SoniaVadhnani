using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsCSharp
{
   public class Vital
    {
        //Alerting.IAlert alert;
        string vitalName;
        float value, lower, upper;
        public Vital(string name, float val,float low,float up)
        {
            //this.alert = alert;
            this.vitalName = name;
            this.value = val;
            this.lower = low;
            this.upper = up;
        }

        public string Name
        {
            get
            {
                return this.vitalName;
            }
        }

        public float Value
        {
            get
            {
                return this.value;
            }
        }

        public float Lower
        {
            get
            {
                return this.lower;
            }
        }

        public float Upper
        {
            get
            {
                return this.upper;
            }
        }
    }
}
