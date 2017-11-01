using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace Trabalho1AspNet.Models.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto() : base("strConn")
        {

        }

        public System.Data.Entity.DbSet<Trabalho1AspNet.Models.Class1> Class1 { get; set; }
    }
}