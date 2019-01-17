using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using QuizApp.Repositories.Abstract;
using QuizApp.Repositories.Concrete;
using QuizApp.Services.Abstract;
using QuizApp.Services.Concrete;

namespace QuizApp
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        public void AddBindings()
        {
            _kernel.Bind<QuizAppDbContext>()
                .ToSelf().InSingletonScope();

            _kernel.Bind<IQuestionRepository>()
                .To<QuestionRepository>();

            _kernel.Bind<IQuestionService>()
                .To<QuestionService>();

            _kernel.Bind<IAnswerRepository>()
                .To<AnswerRepository>();

            _kernel.Bind<IAnswerService>()
                .To<AnswerService>();
        }
    }
}