using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.Unity;
using Model;


namespace mp3Collader.Instance
{
    public class ExampleScenario
    {
        private Database db;

        public ExampleScenario(Database theDatabase)
        {
            db = theDatabase;
        }
    }

    public class ResolveClassThrowUnity
    {
        public ExampleScenario MyObject;
        public IUnityContainer Container;

        public void Resolv()
        {
            // Resolve the class through the Unity container.
            Container = new UnityContainer()
                            .AddNewExtension<EnterpriseLibraryCoreExtension>();
            MyObject  = Container.Resolve<ExampleScenario>();
            
        }
    }

    

}
