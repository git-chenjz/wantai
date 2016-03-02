using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrameWork.Common
{
    public class PagedResult<T>
    {
        private readonly ReadOnlyCollection<T> _result;
        private readonly int _total;
        private readonly int _page;
        private readonly int _size;

        public PagedResult(IEnumerable<T> result, int total)
        {
            _result = new ReadOnlyCollection<T>(new List<T>(result));
            _total = total;
        }
        public PagedResult(IEnumerable<T> result, int total, int page, int size)
        {
            _result = new ReadOnlyCollection<T>(new List<T>(result));
            _total = total;
            _page = page;
            _size = size;
        }

        public PagedResult()
            : this(new List<T>(), 0)
        {
        }

        public ICollection<T> Result
        {
            get
            {
                return _result;
            }
        }

        public int PageIndex { get { return _page; } }

        public int PageSize { get { return _size; } }

        public int Total
        {
            get
            {
                return _total;
            }
        }
        public int TotalPageCount { get { return IsEmpty ? 0 : (int)Math.Ceiling(Total / (double)PageSize); } }

        public bool IsEmpty
        {
            get
            {
                return _total == 0;
            }
        }
    }
}
