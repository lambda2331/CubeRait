using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace Cube {
    public class WindsorControllerActivator : IHttpControllerActivator {
        private readonly IWindsorContainer m_container;

        public WindsorControllerActivator(IWindsorContainer container) {
            this.m_container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType) {
            var controller = (IHttpController)this.m_container.Resolve(controllerType);

            request.RegisterForDispose(new Release(() => this.m_container.Release(controller)));

            return controller;
        }

        private class Release : IDisposable {
            private readonly Action m_release;

            public Release(Action release) {
                this.m_release = release;
            }

            public void Dispose() {
                this.m_release();
            }
        }
    }
}
