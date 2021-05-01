using DataAceess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaMishaVisage
{
    public interface IDataView
    {
        void LoadData(DatabaseConfiguration databaseConfiguration);
    }
}
