using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.ViewModels
{
    public class PageViewModel
    {
        public int CurrentPageNumber { get; private set; }
        public int TotalPages { get; private set; }

        public PageViewModel(int count, int pageNumber, int pageSize)
        {
            CurrentPageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }

        public int PreviousPagesCount
        {
            get
            {
                return CurrentPageNumber - 1;
            } 
        }

        public int NextPagesCount
        {
            get
            {
                return TotalPages - CurrentPageNumber;
            }
        }

        public int BeforeCurrentPage
        {
            get
            {
                if (CurrentPageNumber - 2 > 1)
                    return 2;
                else if (CurrentPageNumber - 2 == 1)
                    return 1;
                else
                    return 0;
            }
        }

        public int AfterCurrentPage
        {
            get
            {
                if (CurrentPageNumber + 2 < TotalPages)
                    return 2;
                else if (CurrentPageNumber + 2 == TotalPages)
                    return 1;
                else
                    return 0;
            }
        }

        public bool BeforeGap
        {
            get
            {
                if (CurrentPageNumber - 2 > 2)
                    return true;
                else
                    return false;
            }
        }

        public bool AfterGap
        {
            get
            {
                if (TotalPages - CurrentPageNumber > 3)
                    return true;
                else
                    return false;
            }
        }
    }
}
