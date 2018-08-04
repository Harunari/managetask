using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ManageProgress.Startup))]

namespace ManageProgress
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // アプリケーションの構成方法の詳細については、https://go.microsoft.com/fwlink/?LinkID=316888 を参照してください
        }
    }
}
