﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Respositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfContactDal:GenericRepository<Contact>, IContactDal
    {
    }
}
