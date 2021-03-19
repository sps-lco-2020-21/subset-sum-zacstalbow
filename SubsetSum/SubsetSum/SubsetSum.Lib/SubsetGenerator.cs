using System.Collections.Generic;

namespace SubsetSum.Lib
{
    public class SubsetGenerator
    {
        public static IList<int> SubsetSum(IList<int> s, int p)
        {
            Stack<SubsetGenerator> st = new Stack<SubsetGenerator>();
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
                foreach (SubsetGenerator child in n.Generate(s))
                {
                    int c = child.Sum(s);
                    if (c > p)
                        continue;
                    if (c == p)
                        return child.BreadCrumbs(s);
                    st.Push(child);
                }
            }
            return null;
        }

        readonly SubsetGenerator _parent;
        readonly int _index;

        SubsetGenerator(int index)
        {
            _parent = null;
            _index = index;
        }

        SubsetGenerator(SubsetGenerator parent, int index) : this(index)
        {
            _parent = parent;
        }

        int Sum(IList<int> listOfIntegers)
        {
            return
                listOfIntegers[_index]
                + (_parent == null ? 0 : _parent.Sum(listOfIntegers));
        }

        IEnumerable<SubsetGenerator> Generate(IList<int> listOfIntegers)
        {
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
