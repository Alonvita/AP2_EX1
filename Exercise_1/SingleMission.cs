using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        public String m_name;
        public String m_type;
        private Func<double, double> m_func;
        private const String singleTypeStr = "Single";
        public event EventHandler<double> OnCalculate;

        public String Name { get {return m_name; }  set { m_name = Name; } }
        public String Type { get {return m_type; } set { m_type = Type; } }

        /// <summary>
        /// SingleMission
        /// </summary>
        /// <param name="func"></param>
        /// <param name="name"></param>
        public SingleMission(Func<double, double> func, String name)
        {
            Name = name;
            Type = singleTypeStr;
            m_func = func;
        }

        /// <summary>
        /// Calculate.
        ///     apply the delegated function on value, and invokes the EventHandler.
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Calculate(double value)
        {   
            double result =  m_func(value);

            this.OnCalculate?.Invoke(this, result);

            return result;
        }
    }
}
