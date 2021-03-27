using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeaAndChocolateLibrary
{
    public class TeaBlendRepository
    {
        private Dictionary<string, TeaBlend> _blends;
        public TeaBlendRepository()
        {
            _blends = new Dictionary<string, TeaBlend>();
        }

        public IEnumerable<string> BlendNames => _blends.Keys;

        public TeaBlend GeTeaBlend()
        {
            return _blends.First().Value;
        }

    }
}
