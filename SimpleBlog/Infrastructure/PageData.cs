using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBlog.Infrastructure
{
    public class PageData<T>:IEnumerable<T>
    {
        private readonly IEnumerable<T> _currentItems;
        public int TotalCount { get;private set; }
        public int Page { get;private set; }
        public int PerPage { get;private set; }
        public int TotalPages { get;private set; }

        public bool HasNextPage { get;private set; }
        public bool HasPreviosPage { get; private set; }
        public int NextPage
        {
            get
            {
                if (!HasNextPage)
                    throw new InvalidOperationException();
                return Page + 1;
            }
        }
        public int PreviousPage
        {
            get
            {
                if (!HasPreviosPage)
                    throw new InvalidOperationException();
                return Page - 1;
            }
        }
        public PageData(IEnumerable<T> currentItems,int totalcount,int page,int perpage)
        {
            _currentItems = currentItems;
            TotalCount = totalcount;
            Page = page;
            PerPage = perpage;

            TotalPages = (int)Math.Ceiling((float)TotalCount / PerPage);
            HasNextPage = Page < TotalPages;
            HasPreviosPage = Page > 1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _currentItems.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}