using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MatrixCalculator;

namespace UnitTestProject
{
  [TestClass]
  public class MatrixCalculatorTests
  {
    [TestMethod]
    public void TestAdditionMethod()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 10, 9, 8 }, { 7, 6, 5 }, { 4, 3, 2 } });
      SquareMatrix expectedResult = new SquareMatrix(new int[3, 3] { { 10, 10, 10 }, { 10, 10, 10 }, { 10, 10, 10 } });

      SquareMatrix actualResult = firstMatrix + secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestSubtractionMethod()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 10, 10, 10 }, { 10, 10, 10 }, { 10, 10, 10 } });
      SquareMatrix expectedResult = new SquareMatrix(new int[3, 3] { { -10, -9, -8 }, { -7, -6, -5 }, { -4, -3, -2 } });

      SquareMatrix actualResult = firstMatrix - secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMultipyMethod()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 10, 10, 10 }, { 10, 10, 10 }, { 10, 10, 10 } });
      SquareMatrix expectedResult = new SquareMatrix(new int[3, 3] { { 0, 10, 20 }, { 30, 40, 50 }, { 60, 70, 80 } });

      SquareMatrix actualResult = firstMatrix * secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestLessThanTrue()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      bool expectedResult = true;

      bool actualResult = firstMatrix < secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestLessThanOrEqualTrue()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      bool expectedResult = true;

      bool actualResult = firstMatrix <= secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestLessThanFalse()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      bool expectedResult = false;

      bool actualResult = firstMatrix < secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestLessThanOrEqualFalse()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      bool expectedResult = false;

      bool actualResult = firstMatrix <= secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMoreThanTrue()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      bool expectedResult = true;

      bool actualResult = firstMatrix > secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMoreThanOrEqualTrue()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      bool expectedResult = true;

      bool actualResult = firstMatrix >= secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMoreThanFalse()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      bool expectedResult = false;

      bool actualResult = firstMatrix > secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestMoreThanOrEqualFalse()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      bool expectedResult = false;

      bool actualResult = firstMatrix >= secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestEquallyTrue()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      bool expectedResult = true;

      bool actualResult = firstMatrix == secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestEquallyFalse()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      bool expectedResult = false;

      bool actualResult = firstMatrix == secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestNotEquallyFalse()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      SquareMatrix secondMatrix = new SquareMatrix(new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 92 } });
      bool expectedResult = false;

      bool actualResult = firstMatrix != secondMatrix;
      Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestCalculateDeterminant()
    {
      SquareMatrix firstMatrix = new SquareMatrix(new int[3, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
      int expectedResult = 0;

      int actualResult = SquareMatrix.CalculateDeterminant(firstMatrix); ;
      Assert.AreEqual(expectedResult, actualResult);
    }
  }
}
