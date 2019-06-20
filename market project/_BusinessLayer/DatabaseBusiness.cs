﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BusinessLayer
{
    public abstract class DatabaseBusiness<T> where T: class
    {
        public abstract List<T> List();
        public abstract void Create(T t);
        public abstract T Read(int id);
        public abstract void Update(T t);
        public abstract void Delete(T t);
        public abstract void Delete(int id);
    }
}
