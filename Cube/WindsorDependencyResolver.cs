using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Castle.Windsor;

namespace Cube {
    internal sealed class WindsorDependencyResolver : IDependencyResolver {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container) {
            if(container == null) throw new ArgumentNullException("container");

            this._container = container;
        }

        public object GetService(Type t) {
            return this._container.Kernel.HasComponent(t) ? this._container.Resolve(t) : null;
        }

        public IEnumerable<object> GetServices(Type t) {
            return this._container.ResolveAll(t).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope() {
            return new WindsorDependencyScope(this._container);
        }

        public void Dispose() { }
    }
}
