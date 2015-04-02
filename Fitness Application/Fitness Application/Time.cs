using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Application
{
    public class Time
    {
        public int seconds { get; set; }
        public int minutes { get; set; }
        public int hours { get; set; }

        public static Boolean isSmaller(Time time1, Time time2)
        {
            if (time1.hours < time2.hours)
            {
                return true;
            }
            else
            {
                if (time1.minutes < time2.minutes)
                {
                    return true;
                }
                else
                {
                    if (time1.seconds < time2.seconds)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    
    }


}
