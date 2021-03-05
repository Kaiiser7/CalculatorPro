using System;
using System.Collections.Generic;
using NUnit.Framework;
namespace CalcLibrary
{
    [TestFixture]
    public class CalculatorTests
    {
        double add, sub, mul, div, result;
        string name;
        [SetUp]
        public void SetUpMethod()
        {
            add = 0;
            sub = 0;
            mul = 0;
            div = 0;
            name = "Breaking Bad";
        }

        // Tests for Addition

        [Test]
        public void CalculatorAddMethod()
        {
            Calculator calc = new Calculator();
            add = calc.Addition(40, 20);
            Assert.AreEqual(60, add);
        }

        [Test]
        [TestCase(20, 25, 45)]
        [Repeat(3)]
        [MaxTime(200)]
        public void CalculatorAddMethod(int x, int y, int expected)
        {
            Calculator calc = new Calculator();
            add = calc.Addition(x, y);
            Assert.AreEqual(expected, add);
        }

        [Test]
        public void CalculatorAddAssertMethod()
        {
            Calculator calc = new Calculator();
            add = calc.Addition(25, 35);
            Assert.IsTrue(add > 50);
            Assert.True(add > 50);
            Assert.IsFalse(add < 50);
            Assert.False(add < 50);
        }

        [Test]
        public void CalculatorAddConstraintMethod()
        {
            Calculator calc = new Calculator();
            add = calc.Addition(25, 35);
            Assert.That(add, Is.EqualTo(60));
            Assert.That(add, Is.GreaterThan(0));
            Assert.That(add, Is.GreaterThanOrEqualTo(50));
            Assert.That(add, Is.LessThan(100));
            Assert.That(add, Is.LessThanOrEqualTo(100));
            Assert.That(add, Is.InRange(0, 100));
            Assert.That(name, Is.EqualTo("Breaking Bad"));
        }

        // Tests for String

        [Test]
        public void CalculatorStringConstraintMethod()
        {
            Assert.That(name, Is.EqualTo("Breaking Bad"));
            Assert.That(name, Is.Not.EqualTo("Heisenberg"));
            Assert.That(name, Does.Contain("Br"));
            Assert.That(name, Does.Contain("reaki").IgnoreCase);
            Assert.That(name, Does.Not.Contain("Pinkman").IgnoreCase);
            Assert.That(name, Does.Match("Breaking"));
            Assert.That(name, Does.Match("breaking").IgnoreCase);
            string number = "12345";
            string pattern = "^[0-9]{5}$";
            Assert.That(number, Does.Match(pattern));
        }

        // Tests for Subtraction

        [Test]
        public void CalculateSubstract()
        {
            Calculator calc = new Calculator();
            sub = calc.Subtraction(40, 60);
            Assert.AreEqual(-20, sub);
        }

        [Test]
        [TestCase(80, 40, 40)]
        [TestCase(45, 55, -10)]
        public void CalculatorSubParameter(int x, int y, int expected)
        {
            Calculator calc = new Calculator();
            sub = calc.Subtraction(x, y);
            Assert.AreEqual(expected, sub);
        }

        // Tests for Multipication

        [Test]
        public void CalculateMultiplication()
        {
            Calculator calc = new Calculator();
            mul = calc.Multiplication(4, 6);
            Assert.AreEqual(24, mul);
        }

        [Test]
        [TestCase(8, 2, 16)]
        [TestCase(5, 5, 25)]
        public void CalculatorMulParameter(int x, int y, int expected)
        {
            Calculator calc = new Calculator();
            mul = calc.Multiplication(x, y);
            Assert.AreEqual(expected, mul);
        }

        // Tests for Division

        [Test]
        public void CalculateDivision()
        {
            Calculator calc = new Calculator();
            div = calc.Division(24, 6);
            Assert.AreEqual(4, div);
        }
        [Test]
        [TestCase(8, 2, 4)]
        [TestCase(5, 0, 0)]
        public void CalculatorDivParameter(int x, int y, int expected)
        {
            Calculator calc = new Calculator();
            try
            {
                if (y == 0)
                {
                    div = calc.Division(x, y);
                    Assert.Fail("Division by zero");
                }
                else
                {
                    div = calc.Division(x, y);
                    Assert.AreEqual(expected, div);
                }
            }
            catch (ArgumentException e)
            {
                List<string> messages = new List<string> { e.Message };
                Assert.Contains("Second Parameter Can't be Zero", messages);
            }
        }

        [Test]
        public void TestAddAndClear()
        {
            Calculator calc = new Calculator();
            add = calc.Addition(20,30);
            Assert.AreEqual(50, add);
            calc.AllClear();
            result = calc.GetResult;
            Assert.AreEqual(0, result);
        }

        [TearDown]
        public void CleanUpMethod()
        {
            add = 0;
            sub = 0;
            mul = 0;
            div = 0;
            name = "";
        }
    }
}