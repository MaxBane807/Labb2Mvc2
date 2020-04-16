using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb2Mvc2.ViewModels
{
    public class Pagination
    {
        public int currentPage { get; set; }

        public bool firstPage { get { return (currentPage == 1); } }

        public int lastPage { get; set; }

        public int postsPerPage { get; set; }
    }
}
