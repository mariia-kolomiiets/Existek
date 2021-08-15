using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork3.OwnProvider
{
    public class CartoonConfigurationSource : IConfigurationSource
    {
        public string PathCartoon { get; private set; }
        public CartoonConfigurationSource(string pathCartoon)
        {
            PathCartoon = pathCartoon;
        }
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            string pathCartoon = builder.GetFileProvider().GetFileInfo(PathCartoon).PhysicalPath;
            return new CartoonConfigurationProvider(pathCartoon);
        }
    }
}
