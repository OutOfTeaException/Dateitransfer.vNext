using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dateitransfer.vNext.Service.Bootstrap
{
    public class DateitransferKernel
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            // Alle Module in der Assembly laden
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel;
        }
    }
}
