using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleThesaurus
{
    class SearchOnFileK
    {
        static SearchOnFileK searchOnK;

        private SearchOnFileK() { }

        public SearchOnFileK getInstance()
        {
            if (searchOnK == null)
                searchOnK = new SearchOnFileK();
            return searchOnK;
        }



    }
}
