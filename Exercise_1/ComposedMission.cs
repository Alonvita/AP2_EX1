using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public String m_name;
        public String m_type;

        private const String composedTypeStr = "Composed";
        private Stack<Func<double, double>> m_funcStack; // Functions will be added in LIFO order
                                                       // as function composition "wraps" the last function added.
        public event EventHandler<double> OnCalculate;

        
        public String Name { get {return m_name; }  set { m_name = Name; }}
        public String Type { get {return m_type; } set { m_type = Type; }}
        
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name"></param>
        public ComposedMission(String name)
        {
            Name = name;
            Type = composedTypeStr;

            // Init functions list
            m_funcStack = new Stack<Func<double, double>>();
        }


        /// <summary>
        /// Add.
        ///     adds a new delegation to the funcStack.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public ComposedMission Add(Func<double, double> func)
        {
            m_funcStack.Push(func);

            return this;
        }

        
        /// <summary>
        /// Calculate.
        ///     calls RecursivelyApplyFunc and invokes the EventHandler.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Calculate(double value)
        {
            // Clone the Stack
            var clonedStack = new Stack<Func<double, double>>(new Stack<Func<double, double>>(m_funcStack));


            double result = this.RecursivelyApplyFunc(value, clonedStack);

            this.OnCalculate?.Invoke(this, result);

            return result;
        }


        /// <summary>
        /// RecursivelyApplyFunc.
        ///     Recursively applies all delegated functions from the stack on the given value.
        ///     
        ///     The function pops the stack and applies it on the next call of the function.
        ///     Stopping condition is when the stack size == 1. In this case we apply the 
        ///     last function on the given value and start tracing back.
        ///     
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="funcStack"></param>
        /// <returns></returns>
        private double RecursivelyApplyFunc(double value, Stack<Func<double, double>> funcStack)
        {
            // Reached the end of the stack -> returh f(value)
            if (funcStack.Count == 1)
                return funcStack.Peek()(value);

            // apply the next function on the returned result.
            return funcStack.Pop()(RecursivelyApplyFunc(value, funcStack));
        }
    }
}
