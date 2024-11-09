﻿namespace LMS_1.Sharing
{
    public class BookParams
    {
        public int MaxPageSize { get; set; } = 15;

        private int _pageSize = 6;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
        public int PageNumber { get; set; } = 1;

        public string? Search { get; set; }
    }
}
