using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using Simple.Mocking.SetUp.Actions;
using Simple.Mocking.SetUp.Proxies;


namespace Simple.Mocking.UnitTests.Actions
{
	[TestFixture]
	public class ExecutesActionTests : ActionTestsBase
	{
		[Test]
		public void ExecuteFor()
		{
			var value = new object();
			var invocation = CreateInvocation();

			Func<object> func = () => value;

			new ExecutesAction(func).ExecuteFor(invocation);

			Assert.AreSame(value, invocation.ReturnValue);
		}		

		[Test]
		public void ExecuteForWithParametersArgument()
		{
			var value = new object();
			var invocation = CreateInvocation();

			Func<IList<object>, object> func =
				parameters =>
				{
					parameters[0] = value;
					return value;
				};

			new ExecutesAction(func).ExecuteFor(invocation);

			Assert.AreSame(value, invocation.ParameterValues[0]);
			Assert.AreSame(value, invocation.ReturnValue);
		}
	}
}