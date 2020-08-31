using MainApp.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace MainApp.Queries
{
    public class Querier
    {
        private DatabaseContext dbContext;

        public Querier( DatabaseContext _dbContext ){
            dbContext = _dbContext;
        }
    }
}