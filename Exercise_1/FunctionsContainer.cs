/**
 * Alon Vita
 * 311233431
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excercise_1
{
    /**
     * FunctionsContainer Class.
     *      FunctionsContainer holds a dictionary of string -> function, where the only type
     *      of functions currently supported are of the type: public int Function(int val) { ... }.
     */
    class FunctionsContainer
        {
            private Func<double, double> defaultFunc = val => val;
            private Dictionary<string, Func<double, double>> functionsDict;

            /// <summary>
            /// Constructor.
            /// </summary>
            public FunctionsContainer()
            {
                // Init container
                this.functionsDict = new Dictionary<String, Func<double, double>>();
            }

            /// <summary>
            /// getAllMissions.
            ///     returns a list containing all of the dictionary's Keys.
            /// 
            /// </summary>
            /// <returns>
            ///     List<string> of all function names
            /// </returns>
            public List<string> getAllMissions()
            {                
                return functionsDict.Select(entry => entry.Key).ToList();
            }

            /// <summary>
            /// /**
            /// Indexer.
            ///     Input: string -- functionName
            ///     get: the function associated with the given function name
            ///     set: set a new entry to the functionsDict, where value is: public int Function(int val) { ... }
            /// </summary>
            /// <param name="functionName"></param>
            public Func<double, double> this[string functionName]
            {
                get
                { 
                    if (!this.functionsDict.ContainsKey(functionName)) 
                    {
                        // add a new entry with the default func.
                        this.functionsDict[functionName] = this.defaultFunc;
                    }
                        

                    return this.functionsDict[functionName];
                }
                set 
                { 
                    // contains -> remove
                    if(this.functionsDict.ContainsKey(functionName))
                        this.functionsDict.Remove(functionName);
                    
                    // add
                    this.functionsDict.Add(functionName, value);
                }
            }
        }
}