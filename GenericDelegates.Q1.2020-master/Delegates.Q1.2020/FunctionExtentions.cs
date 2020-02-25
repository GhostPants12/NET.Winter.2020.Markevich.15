using System;

namespace Delegates.Q1._2020
{
    public static class FunctionExtensions
    {
        /// <summary>
        ///   Combines several predicates using logical AND operator 
        /// </summary>
        /// <param name="predicates">array of predicates</param>
        /// <returns>
        ///   Returns a new predicate that combine the specified predicated using AND operator
        /// </returns>
        /// <example>
        ///   var result = CombinePredicatesWithAnd(new Predicate<string>[] {
        ///            x => !string.IsNullOrEmpty(x),
        ///            x => x.StartsWith("START"),
        ///            x => x.EndsWith("END"),
        ///            x => x.Contains("#")
        ///        });
        ///   should return the predicate that identical to 
        ///   x=> (!string.IsNullOrEmpty(x)) && x.StartsWith("START") && x.EndsWith("END") && x.Contains("#")
        ///
        ///   The following example should create predicate that returns true if int value between -10 and 10:
        ///   var result = CombinePredicatesWithAnd(new Predicate<int>[] {
        ///            x => x > -10,
        ///            x => x < 10
        ///       });
        /// </example>
        public static Predicate<T> CombinePredicatesWithAnd<T>(Predicate<T>[] predicates)
        {
            Predicate<T> returnPredicate = delegate(T obj)
            {
                bool result = true;
                for (int i = 0; i < predicates.Length; i++)
                {
                    result &= predicates[i].Invoke(obj);
                }

                return result;
            };
            return returnPredicate;
        }
    }
}
