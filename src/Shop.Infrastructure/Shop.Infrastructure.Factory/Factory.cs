using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Factory
{
    static public class Factory
    {
        static IUnityContainer _objectContainer;
        static IUnityContainer _repositoryContainer;
        static IUnityContainer _managerContainer;

        static Factory()
        {
            var section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;

            _objectContainer = new UnityContainer();
            _repositoryContainer = new UnityContainer();
            _managerContainer = new UnityContainer();


            if (section != null)
            {
                ContainerElement objectElement = section.Containers["objects"];
                ContainerElement repositoryElement = section.Containers["repositories"];
                ContainerElement managerElement = section.Containers["managers"];

                if (objectElement != null && repositoryElement != null && managerElement != null)
                {
                    objectElement.Configure(_objectContainer);
                    repositoryElement.Configure(_repositoryContainer);
                    managerElement.Configure(_managerContainer);
                }
            }
        }

        public static T GetComponent<T>()
        {
            return _objectContainer.Resolve<T>();
        }

        public static T GetRepository<T>()
        {
            return _repositoryContainer.Resolve<T>();
        }

        public static T GetManager<T>()
        {
            return _managerContainer.Resolve<T>();
        }
    }    
}