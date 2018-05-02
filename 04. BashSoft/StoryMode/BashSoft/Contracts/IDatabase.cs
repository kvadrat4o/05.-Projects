using System;
using System.Collections.Generic;
using System.Text;

namespace BashSoft.Contracts
{
    public interface IDatabase : IOrderedTaker, IFilteredTaker, IRequester
    {
        void UnloadData();

        void LoadData(string fileName);
    }
}
