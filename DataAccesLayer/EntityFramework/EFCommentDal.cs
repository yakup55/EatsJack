﻿using DataAccesLayer.Abstract;
using DataAccesLayer.Repository;
using EntityLayers.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.EntityFramework
{
    public class EFCommentDal:GenericRepository<Comment>,ICommentDal
    {
    }
}
