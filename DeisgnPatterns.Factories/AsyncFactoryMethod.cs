using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeisgnPatterns.Factories
{

    // asynchronous example
    public class AsyncFactoryMethod
    {
        private AsyncFactoryMethod()
        {
            //
        }

        private async Task<AsyncFactoryMethod> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<AsyncFactoryMethod> CreateAsync()
        {
            var result = new AsyncFactoryMethod();
            return result.InitAsync();
        }
    }


}
