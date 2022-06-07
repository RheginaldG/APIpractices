using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Practice.StepDefinitions
{
    public abstract class BaseSteps
    {
        public ScenarioContext _scenarioContext;

        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
    }
}
