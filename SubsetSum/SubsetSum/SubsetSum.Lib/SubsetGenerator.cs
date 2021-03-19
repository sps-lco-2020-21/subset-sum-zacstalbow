using System.Collections.Generic;

namespace SubsetSum.Lib
{
    public class SubsetGenerator
    {
        public static IList<int> SubsetSum(IList<int> s, int p)
        {
            // using a stack for a depth-first approach. it's not clear that a queue/breadth-first would necessarily be worse 
            Stack<SubsetGenerator> st = new Stack<SubsetGenerator>();
            // add each of the single item subsets to the stack 
            for (int i = 0; i < s.Count; ++i)
            {
                if (s[i] > p)
                    continue;
                if (s[i] == p)
                    return new List<int> { s[i] };
                st.Push(new SubsetGenerator(i));
            }

            while (st.Count > 0)
            {
                SubsetGenerator n = st.Pop();
                // replace an item with all subsets made from taking the item with all subsequent items 
                // (the ones earlier will have already been generated) 
                foreach (SubsetGenerator child in n.Generate(s))
                {
                    int c = child.Sum(s);
                    // it's too big, it's a dead end 
                    if (c > p)
                        continue;
                    // if it's correct, return it 
                    if (c == p)
                        return child.BreadCrumbs(s);
                    // otherwise push it on to the stack 
                    st.Push(child);
                }
            }
            return null;
        }

        readonly SubsetGenerator _parent;
        // store the index into the list of integers, rather than the value it self. 
        readonly int _index;

        /// <summary>
        /// private constructor - only ever hit from the static function 
        /// </summary>
        /// <param name="index"></param>
        SubsetGenerator(int index)
        {
            _parent = null;
            _index = index;
        }

        SubsetGenerator(SubsetGenerator parent, int index) : this(index)
        {
            _parent = parent;
        }

        // todo: create an intermediate class (as we did with linked list) to actually store the list 
        int Sum(IList<int> listOfIntegers)
        {
            return
                listOfIntegers[_index]
                + (_parent == null ? 0 : _parent.Sum(listOfIntegers));
        }

        // 
        IEnumerable<SubsetGenerator> Generate(IList<int> listOfIntegers)
        {
            // only link to items after you 
            for (int i = _index + 1; i < listOfIntegers.Count; ++i)
            {
                yield return new SubsetGenerator(this, i);
            }
        }

        IList<int> BreadCrumbs(IList<int> listOfIntegers)
        {
            if (_parent == null)
                return new List<int> { listOfIntegers[_index] };
            IList<int> l = _parent.BreadCrumbs(listOfIntegers);
            l.Add(listOfIntegers[_index]);
            return l;
        }
    }
}
